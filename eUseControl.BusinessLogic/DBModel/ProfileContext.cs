using System.Data.Entity;
using System.Linq;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.DBModel
{
    public class ProfileContext : DbContext
    {
        public ProfileContext() : base("name=eUseControlVillaAgency2")
        {
        }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        public UserProfile GetUserProfile(int userId)
        {
            var profile = UserProfiles.FirstOrDefault(p => p.UserId == userId);
            if (profile == null)
            {
                // Log that no profile was found
                System.Diagnostics.Debug.WriteLine($"No profile found for UserId: {userId}");
            }
            else
            {
                // Log the details of the profile found
                System.Diagnostics.Debug.WriteLine($"Profile found for UserId: {userId}, ProfileId: {profile.Id}");
            }
            return profile;
        }

        public void UpdateUserProfile(UserProfile profile)
        {
            var existingProfile = UserProfiles.FirstOrDefault(p => p.UserId == profile.UserId);
            if (existingProfile != null)
            {
                existingProfile.FirstName = profile.FirstName;
                existingProfile.LastName = profile.LastName;
                existingProfile.ProfileImage = profile.ProfileImage;
                existingProfile.Age = profile.Age;
                existingProfile.Biography = profile.Biography;
            }
            else
            {
                UserProfiles.Add(profile);
            }
            SaveChanges();
        }

    }
}
