using eUseControl.Domain.Entities;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.Villa;
using System.Collections.Generic;
using System.Web;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginResp UserLogin(ULoginData data);
        URegisterResp UserRegister(URegisterData data);
        HttpCookie GenCookie(string loginCredential);
        UserMinimal GetUserByCookie(string apiCookieValue);
        UserProfile GetUserProfile(int userId);
        void UpdateUserProfile(UserProfile profile);
        List<Review> GetAllReviews();
        void AddReview(Review review);
        Review GetReviewById(int id); 
        void DeleteReview(int id);
        List<VillaDbTable> GetAllProperties();
        void AddVisitRequest(VisitRequest request);
    }
}
