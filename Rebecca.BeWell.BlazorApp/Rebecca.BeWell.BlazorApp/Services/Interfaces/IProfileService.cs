using Rebecca.BeWell.BlazorApp.Data.Models;

namespace Rebecca.BeWell.BlazorApp.Services.Interfaces
{
    public interface IProfileService
    {
        Task<bool> CreateProfile(Profile profile);
        //Task<bool> DeleteProfile(int Id);
        Task<Profile?> GetProfileById(int Id);
        Task<Profile?> GetProfileByUserId(string UserId);
        Task<bool> UpdateProfile(Profile profile);
    }
}
