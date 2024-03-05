using Microsoft.EntityFrameworkCore;
using Rebecca.BeWell.BlazorApp.Data;
using Rebecca.BeWell.BlazorApp.Data.Models;
using Rebecca.BeWell.BlazorApp.Services.Interfaces;

namespace Rebecca.BeWell.BlazorApp.Services
{
    public class NutritionService : INutritionService
    {
        private ApplicationDbContext _context;
        public NutritionService(ApplicationDbContext context)
        {
            _context = context;
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

        public async Task<bool> CreateNutrition(Nutrition nutrition)
        {
            try
            {

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


                a.Name = nutrition.Name;
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







