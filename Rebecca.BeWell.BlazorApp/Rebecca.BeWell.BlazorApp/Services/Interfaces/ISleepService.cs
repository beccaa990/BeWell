﻿using Rebecca.BeWell.BlazorApp.Shared.Data.Models;

namespace Rebecca.BeWell.BlazorApp.Services.Interfaces
{
    public interface ISleepService
    {
        Task<bool> CreateSleep(Sleep sleep, string userID);
        Task<bool> DeleteSleep(int Id);
        Task<Sleep?> GetSleepById(int Id);
        Task<List<Sleep>?> GetSleepsByUserId(string UserId);
        Task<bool> UpdateSleep(Sleep sleep);
    }
}