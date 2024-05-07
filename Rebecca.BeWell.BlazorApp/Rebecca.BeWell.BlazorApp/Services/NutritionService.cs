using Microsoft.EntityFrameworkCore;
using Rebecca.BeWell.BlazorApp.Shared.Data;
using Rebecca.BeWell.BlazorApp.Shared.Data.Models;
using Rebecca.BeWell.BlazorApp.Services.Interfaces;
using System.Diagnostics;

namespace Rebecca.BeWell.BlazorApp.Services
{
    public class NutritionService : INutritionService
    {
        private IProfileService _profileService;
        private ApplicationDbContext _context;

        public NutritionService(ApplicationDbContext context, IProfileService profileService)
        {
            _context = context;
            _profileService = profileService;
        }
       

        public async Task<List<NutritionType>?> GetNutritionTypes()
        {

            List<NutritionType?> nutritionTypes = await _context.NutritionTypes.ToListAsync();

            return nutritionTypes;

        }

        public async Task<Nutrition?> GetNutritionById(int Id)
        {

            Nutrition? nutrition = await _context.Nutritions.SingleOrDefaultAsync(x => x.Id == Id);

            return nutrition;

        }


        public async Task<List<Nutrition>?> GetNutritionsByUserId(string UserId)
        {

            Profile profile = await _context.Profiles.SingleOrDefaultAsync(p => p.UserID == UserId);

            return profile?.Nutritions;

        }

        public async Task<bool> CreateNutrition(Nutrition nutrition, string userID)
        {
            try
            {
                NutritionType nutritionType = await _context.NutritionTypes.SingleOrDefaultAsync(a => a.Name == nutrition.NutritionType.Name);
                nutrition.NutritionType = nutritionType;

                Profile profile = await _profileService.GetProfileByUserId(userID);

                List<Nutrition> nutritions = profile.Nutritions;

                nutritions.Add(nutrition);

                profile.Nutritions = nutritions;

                _context.Nutritions.Add(nutrition);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {


                return false;


            }
        }
        public async Task<bool> UpdateNutrition(Nutrition nutrition)
        {
            try
            {
                Nutrition? a = await _context.Nutritions.SingleOrDefaultAsync(x => x.Id == nutrition.Id);


                a.NutritionType = a.NutritionType;
                a.Description = nutrition.Description;
                a.TimeStamp = nutrition.TimeStamp;
                a.Calories = nutrition.Calories;


                await _context.SaveChangesAsync();


                return true;

            }
            catch (Exception ex)
            {


                return false;
            }
        }

        public async Task<bool> DeleteNutrition(int Id)
        {
            try
            {

                Nutrition? nutrition = await _context.Nutritions.SingleOrDefaultAsync(x => x.Id == Id);

                _context.Nutritions.Remove(nutrition);
                await _context.SaveChangesAsync();


                return true;

            }
            catch (Exception ex)
            {


                return false;
            }
        }




    }
}







