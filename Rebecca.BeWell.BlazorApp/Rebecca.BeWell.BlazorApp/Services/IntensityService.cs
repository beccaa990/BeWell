using Microsoft.EntityFrameworkCore;
using Rebecca.BeWell.BlazorApp.Data.Models;
using Rebecca.BeWell.BlazorApp.Data;
using Rebecca.BeWell.BlazorApp.Services.Interfaces;

namespace Rebecca.BeWell.BlazorApp.Services
{

    public class IntensityService: IIntensityService
    {
        private ApplicationDbContext _context;

        public IntensityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Intensity?> GetIntensityById(int Id)
        {

            Intensity? intensity = await _context.Intensities.SingleOrDefaultAsync(x => x.Id == Id);

            return intensity;

        }


        public async Task<List<Intensity?>> GetIntensities(int Id)
        {
            List<Intensity?> intensities = await _context.Intensities.ToListAsync();

            return intensities;
        }

        public Task<bool> CreateIntensity(Intensity intensity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIntensity(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Intensity>?> GetIntensitiesByUserId(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateIntensity(Intensity intensity)
        {
            throw new NotImplementedException();
        }




        //public async Task<List<Intensity>?> GetIntensitiesByUserId(string UserId)
        //{

        //    Profile profile = await _context.Profiles.SingleOrDefaultAsync(p => p.UserID == UserId);

        //    return profile?.Intensities;

        //}

        //public async Task<bool> CreateIntensity(Intensity intensity)
        //{
        //    try
        //    {

        //        _context.Intensities.Add(intensity);
        //        await _context.SaveChangesAsync();


        //        return true;

        //    }
        //    catch (Exception ex)
        //    {


        //        return false;
        //    }
        //}
        //public async Task<bool> UpdateIntensity(Intensity intensity)
        //{
        //    try
        //    {
        //        Intensity? a = await _context.Intensities.SingleOrDefaultAsync(x => x.Id == intensity.Id);


        //        a.Name = intensity.Name;


        //        await _context.SaveChangesAsync();


        //        return true;

        //    }
        //    catch (Exception ex)
        //    {


        //        return false;
        //    }
        //}

        //public async Task<bool> DeleteIntensity(int Id)
        //{
        //    try
        //    {

        //        Intensity? intensity = await _context.Intensities.SingleOrDefaultAsync(x => x.Id == Id);

        //        _context.Intensities.Remove(intensity);
        //        await _context.SaveChangesAsync();


        //        return true;

        //    }
        //    catch (Exception ex)
        //    {


        //        return false;
        //    }
        //}




    }
}
