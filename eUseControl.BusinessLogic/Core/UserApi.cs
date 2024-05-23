using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using System.Web;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.User;
using eUseControl.Helpers;
using System.Data.Entity.Infrastructure;
using eUseControl.Domain.Enums;
using System.Collections.Generic;

namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
        internal ULoginResp UserLoginAction(ULoginData data)
        {
            UDbTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credential))
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LastIp = data.LoginIp;
                    result.Level = data.Level;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                var userMinimal = new UserMinimal
                {
                    Id = result.Id,  // Ensure the ID is set
                    Username = result.Username,
                    Email = result.Email,
                    LastLogin = result.LastLogin ?? DateTime.Now,
                    LasIp = result.LastIp,
                    Level = result.Level ?? URole.User
                };
                return new ULoginResp { Status = true, UserMinimal = userMinimal };
            }
            else
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == pass);
                }

                if (result == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LastIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                var userMinimal = new UserMinimal
                {
                    Id = result.Id,  // Ensure the ID is set
                    Username = result.Username,
                    Email = result.Email,
                    LastLogin = result.LastLogin ?? DateTime.Now,
                    LasIp = result.LastIp,
                    Level = result.Level ?? URole.User
                };
                return new ULoginResp { Status = true, UserMinimal = userMinimal };
            }
        }


        internal URegisterResp UserRegisterAction(URegisterData data)
        {
            try
            {
                using (var db = new UserContext())
                {
                    if (db.Users.Any(u => u.Email == data.Email))
                    {
                        return new URegisterResp { Status = false, StatusMsg = "The email is already in use." };
                    }

                    if (db.Users.Any(u => u.Username == data.Username))
                    {
                        return new URegisterResp { Status = false, StatusMsg = "The username is already in use." };
                    }

                    var hashedPassword = LoginHelper.HashGen(data.Password);

                    var newUser = new UDbTable
                    {
                        Username = data.Username,
                        Email = data.Email,
                        Password = hashedPassword,
                        RegistrationDateTime = data.RegistrationDateTime,
                        RegistrationIp = data.RegistrationIp
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();
                }

                return new URegisterResp { Status = true };
            }
            catch (DbUpdateException ex)
            {
                // Log the inner exception for debugging purposes
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    System.Diagnostics.Debug.WriteLine(innerException.Message);
                    innerException = innerException.InnerException;
                }

                return new URegisterResp { Status = false, StatusMsg = "An error occurred while saving the user. Please try again later." };
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                System.Diagnostics.Debug.WriteLine(ex.Message);

                return new URegisterResp { Status = false, StatusMsg = "An unexpected error occurred. Please try again later." };
            }
        }

        public void UpdateUserProfile(UserProfile profile)
        {
            using (var db = new ProfileContext())
            {
                var existingProfile = db.UserProfiles.FirstOrDefault(p => p.UserId == profile.UserId);
                if (existingProfile != null)
                {
                    existingProfile.FirstName = profile.FirstName;
                    existingProfile.LastName = profile.LastName;
                    existingProfile.ProfileImage = profile.ProfileImage;
                    existingProfile.Age = profile.Age;
                    existingProfile.Biography = profile.Biography;

                    db.Entry(existingProfile).State = EntityState.Modified;
                }
                else
                {
                    db.UserProfiles.Add(profile);
                }
                db.SaveChanges();
            }
        }



        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDbTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;
            Mapper.Initialize(cfg => cfg.CreateMap<UDbTable, UserMinimal>());
            var userminimal = Mapper.Map<UserMinimal>(curentUser);

            return userminimal;
        }

        public List<Review> GetAllReviews()
        {
            using (var db = new ProfileContext())
            {
                return db.Reviews.Include(r => r.User).ToList();
            }
        }

        public void AddReview(Review review)
        {
            using (var db = new ProfileContext())
            {
                db.Reviews.Add(review);
                db.SaveChanges();
            }
        }

    }
}
