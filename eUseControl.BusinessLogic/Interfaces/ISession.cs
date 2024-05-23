using eUseControl.Domain.Entities.User;
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
       // UserMinimal GetUserByCredentials(string credential);
    }
}
