﻿using Microsoft.EntityFrameworkCore;
using Rebecca.BeWell.BlazorApp.Shared.Data;
using Rebecca.BeWell.BlazorApp.Shared.Data.Models;
using Rebecca.BeWell.BlazorApp.Services.Interfaces;

namespace Rebecca.BeWell.BlazorApp.Services
{
    public class ActivityService : IActivityService
    {
        private ApplicationDbContext _context;
        private IProfileService _profileService;

        public ActivityService(ApplicationDbContext context, IProfileService profileService)
        {
            _context = context;
            _profileService = profileService;
        }


        public async Task<List<Activity>?> GetActivities()
        {

            List<Activity?> activity = await _context.Activities.ToListAsync();

            return activity;

        }
        public async Task<List<ActivityType>?> GetActivityTypes()
        {

            List<ActivityType?> activityTypes = await _context.ActivityTypes.ToListAsync();

            return activityTypes;

        }


        public async Task<Activity?> GetActivityById(int Id)
        {

            Activity? activity = await _context.Activities.SingleOrDefaultAsync(x => x.Id == Id);

            return activity;

        }

        public async Task<List<Activity>?> GetActivitiesByUserId(string UserId)
        {

            Profile profile = await _context.Profiles.SingleOrDefaultAsync(p => p.UserID == UserId);

            return profile?.Activities;

        }

        public async Task<bool> CreateActivity(Activity activity, string userID)
        {
            try
            {
                ActivityType activityType = await _context.ActivityTypes.SingleOrDefaultAsync(a => a.Name == activity.ActivityType.Name);
                activity.ActivityType = activityType;

                Intensity intensity = await _context.Intensities.SingleOrDefaultAsync(a => a.Name == activity.Intensity.Name);
                activity.Intensity = intensity;

                Profile profile = await _profileService.GetProfileByUserId(userID);

                List<Activity> activities = profile.Activities;

                activities.Add(activity);

                profile.Activities = activities;

                _context.Activities.Add(activity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateActivity(Activity activity)
        {
            try
            {
                Activity? a = await _context.Activities.SingleOrDefaultAsync(x => x.Id == activity.Id);


                a.Mins = activity.Mins;
                a.ActivityType = activity.ActivityType;
                a.Intensity = activity.Intensity;
                a.TimeStamp = activity.TimeStamp;
                a.Intensity = a.Intensity;
                a.Start = activity.Start;
                a.End = activity.End;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {


                return false;
            }
        }

        public async Task<bool> DeleteActivity(int Id)
        {
            try
            {

                Activity? activity = await _context.Activities.SingleOrDefaultAsync(x => x.Id == Id);

                _context.Activities.Remove(activity);
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
