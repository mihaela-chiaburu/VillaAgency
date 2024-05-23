using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
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

}
