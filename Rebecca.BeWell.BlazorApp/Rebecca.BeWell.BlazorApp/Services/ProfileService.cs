using Microsoft.EntityFrameworkCore;
using Rebecca.BeWell.BlazorApp.Shared.Data.Models;
using Rebecca.BeWell.BlazorApp.Shared.Data;
using Rebecca.BeWell.BlazorApp.Services.Interfaces;

namespace Rebecca.BeWell.BlazorApp.Services
{
    public class ProfileService: IProfileService
    {
        private ApplicationDbContext _context;

        public ProfileService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Profile?> GetProfileById(int Id)
        {

            Profile? profile = await _context.Profiles.SingleOrDefaultAsync(x => x.Id == Id);

            return profile;

        }
        public async Task<Profile?> GetProfileByUserId(string UserId)
        {
            Profile profile = await _context.Profiles.SingleOrDefaultAsync(p => p.UserID == UserId);

            return profile;

        }
        public async Task<bool> CreateProfile(Profile profile)
        {
            try
            {

                _context.Profiles.Add(profile);
                await _context.SaveChangesAsync();


                return true;

            }
            catch (Exception ex)
            {


                return false;
            }
        }
        public async Task<bool> UpdateProfile(Profile profile)
        {
            try
            {
                Profile? a = await _context.Profiles.SingleOrDefaultAsync(x => x.Id == profile.Id);


                a.UserID = a.UserID;
                a.Weight = profile.Weight;
                a.Height= profile.Height;
                a.Activities = a.Activities;
                a.Nutritions = a.Nutritions;
                a.Sleeps = a.Sleeps;


                await _context.SaveChangesAsync();


                return true;

            }
            catch (Exception ex)
            {


                return false;
            }
        }

        public async Task<bool> DeleteProfile(int id)
        {
            try
            {
                Profile? profile = await _context.Profiles.SingleOrDefaultAsync(x => x.Id == id);

                _context.Profiles.Remove(profile);
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
