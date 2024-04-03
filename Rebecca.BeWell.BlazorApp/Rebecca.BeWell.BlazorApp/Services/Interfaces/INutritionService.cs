using Rebecca.BeWell.BlazorApp.Shared.Data.Models;

namespace Rebecca.BeWell.BlazorApp.Services.Interfaces
{
    public interface INutritionService
    {
        Task<bool> CreateNutrition(Nutrition nutrition);
        Task<bool> DeleteNutrition(int Id);
        Task<Nutrition?> GetNutritionById(int Id);
        Task<List<Nutrition>?> GetNutritionsByUserId(string UserId);
        Task<bool> UpdateNutrition(Nutrition nutrition);
        Task<List<NutritionType>?> GetNutritionTypes();

    }
}