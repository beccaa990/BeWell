using Rebecca.BeWell.BlazorApp.Shared.Data.Models;

namespace Rebecca.BeWell.BlazorApp.Services.Interfaces
{
    public interface IActivityService
    {
        Task<List<Activity>?> GetActivities();
        Task<bool> CreateActivity(Activity activity, string userID);
        Task<bool> DeleteActivity(int Id);
        Task<List<Activity>?> GetActivitiesByUserId(string UserId);
        Task<Activity?> GetActivityById(int Id);
        Task<bool> UpdateActivity(Activity activity);
        Task<List<ActivityType>?> GetActivityTypes();

    }
}