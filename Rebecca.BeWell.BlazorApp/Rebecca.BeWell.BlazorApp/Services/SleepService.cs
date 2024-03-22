using Microsoft.EntityFrameworkCore;
using Rebecca.BeWell.BlazorApp.Shared.Data.Models;
using Rebecca.BeWell.BlazorApp.Shared.Data;
using Rebecca.BeWell.BlazorApp.Services.Interfaces;

namespace Rebecca.BeWell.BlazorApp.Services
{
    public class SleepService : ISleepService
    {
        private ApplicationDbContext _context;
        public SleepService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Sleep?> GetSleepById(int Id)
        {

            Sleep? sleep = await _context.Sleeps.SingleOrDefaultAsync(x => x.Id == Id);

            return sleep;

        }
        public async Task<List<Sleep>?> GetSleepsByUserId(string UserId)
        {

            Profile profile = await _context.Profiles.SingleOrDefaultAsync(p => p.UserID == UserId);

            return profile?.Sleeps;

        }
        public async Task<bool> CreateSleep(Sleep sleep)
        {
            try
            {

                _context.Sleeps.Add(sleep);
                await _context.SaveChangesAsync();


                return true;

            }
            catch (Exception ex)
            {


                return false;
            }
        }
        public async Task<bool> UpdateSleep(Sleep sleep)
        {
            try
            {
                Sleep? a = await _context.Sleeps.SingleOrDefaultAsync(x => x.Id == sleep.Id);


                a.Description = sleep.Description;
                a.TimeStamp = sleep.TimeStamp;
                a.Mins = sleep.Mins;


                await _context.SaveChangesAsync();


                return true;

            }
            catch (Exception ex)
            {


                return false;
            }
        }

        public async Task<bool> DeleteSleep(int Id)
        {
            try
            {

                Sleep? sleep = await _context.Sleeps.SingleOrDefaultAsync(x => x.Id == Id);

                _context.Sleeps.Remove(sleep);
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








   