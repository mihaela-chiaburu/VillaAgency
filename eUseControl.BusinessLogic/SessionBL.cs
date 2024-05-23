using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class SessionBL : UserApi, ISession
{
    public ULoginResp UserLogin(ULoginData data)
    {
        return UserLoginAction(data);
    }

    public URegisterResp UserRegister(URegisterData data)
    {
        return UserRegisterAction(data);
    }

    public HttpCookie GenCookie(string loginCredential)
    {
        return Cookie(loginCredential);
    }

    public UserMinimal GetUserByCookie(string apiCookieValue)
    {
        return UserCookie(apiCookieValue);
    }

    public UserProfile GetUserProfile(int userId)
    {
        using (var db = new ProfileContext())
        {
            return db.GetUserProfile(userId);
        }
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
