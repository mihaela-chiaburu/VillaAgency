using System.Collections.Generic;
using System.Data.Entity;
using eUseControl.BusinessLogic.Core;
using System.Linq;
using System.Web;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.Villa;

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
        using (var db = new ReviewsContext())
        {
            return db.Reviews.Include(r => r.User).ToList();
        }
    }

    public void AddReview(Review review)
    {
        using (var db = new ReviewsContext())
        {
            db.Reviews.Add(review);
            db.SaveChanges();
        }
    }

    public Review GetReviewById(int id)
    {
        using (var db = new ReviewsContext())
        {
            return db.Reviews.Include(r => r.User).FirstOrDefault(r => r.Id == id);
        }
    }

    public void DeleteReview(int id)
    {
        using (var db = new ReviewsContext())
        {
            var review = db.Reviews.Find(id);
            if (review != null)
            {
                db.Reviews.Remove(review);
                db.SaveChanges();
            }
        }
    }

    public List<VillaDbTable> GetAllProperties()
    {
        using (var db = new VillaContext())
        {
            return db.Villas.ToList();
        }
    }

    public void AddVisitRequest(VisitRequest request)
    {
        using (var db = new VisitContext())
        {
            db.VisitRequests.Add(request);
            db.SaveChanges();
        }
    }

    public List<VisitRequest> GetAllVisits()
    {
        using (var db = new VisitContext())
        {
            return db.VisitRequests.Include(v => v.Property).ToList();
        }
    }


}
