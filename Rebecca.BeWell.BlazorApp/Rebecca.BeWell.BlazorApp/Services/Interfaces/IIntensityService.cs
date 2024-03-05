using Rebecca.BeWell.BlazorApp.Data.Models;

namespace Rebecca.BeWell.BlazorApp.Services.Interfaces
{
    public interface IIntensityService
    {
        Task<bool> CreateIntensity(Intensity intensity);
        Task<bool> DeleteIntensity(int Id);
        Task<Intensity?> GetIntensityById(int Id);
        Task<List<Intensity>?> GetIntensitiesByUserId(string UserId);
        Task<bool> UpdateIntensity(Intensity intensity);
    }
}