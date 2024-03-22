using Rebecca.BeWell.BlazorApp.Shared.Data.Models;

namespace Rebecca.BeWell.BlazorApp.Services.Interfaces
{
    public interface IActivityService
    {
        Task<bool> CreateActivity(Activity activity);
        Task<bool> DeleteActivity(int Id);
        Task<List<Activity>?> GetActivitiesByUserId(string UserId);
        Task<Activity?> GetActivityById(int Id);
        Task<bool> UpdateActivity(Activity activity);
    }
}