using Microsoft.AspNetCore.Mvc;
using Rebecca.BeWell.BlazorApp.Shared.Data.Models;
using Rebecca.BeWell.BlazorApp.Services;
using Rebecca.BeWell.BlazorApp.Services.Interfaces;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebecca.BeWell.BlazorApp.Controllers
{
    [Route("api/Activities")]
    [ApiController]
    public class ActivitiesControllercs : ControllerBase
    {

        private readonly IActivityService _activityService;

        public ActivitiesControllercs(IActivityService activityService)
        {
            _activityService = activityService;
        }


        [HttpGet("GetActivities")]

        public async Task<IActionResult> GetActivities()
        {
            List< Shared.Data.Models.Activity> activities = await _activityService.GetActivities();

            return Ok(activities);
        }

        [HttpGet("GetActivityTypes")]

        public async Task<IActionResult> GetActivityTypes()
        {
            List<Shared.Data.Models.ActivityType> activityTypes = await _activityService.GetActivityTypes();

            return Ok(activityTypes.OrderBy(o => o.Name));


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int Id)
        {
            Shared.Data.Models.Activity activity = await _activityService.GetActivityById(Id);

            return Ok(activity);
        }



        [HttpGet("user/{userid}")]

        public async Task<IActionResult> GetActivitiesByUserId(string userId)
        {

            List<Shared.Data.Models.Activity> activity = await _activityService.GetActivitiesByUserId(userId);

            return Ok(activity);
        }




        // POST api/Activity/Update
        [HttpPost]
        public async Task<IActionResult> Update(Shared.Data.Models.Activity activity)
        {

            bool isUpdated = await _activityService.UpdateActivity(activity);

            return Ok(isUpdated);
        }

        // POST api/Activity/Create
        [HttpPost]
        public async Task<IActionResult> Create(Shared.Data.Models.Activity activity)
        {

            bool isCreated = await _activityService.CreateActivity(activity);

            return Ok(isCreated);
        }


        // DELETE api/<ActivitiesControllercs>/5
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDelete = await _activityService.DeleteActivity(id);

            return Ok(isDelete);
        }
    }
}
