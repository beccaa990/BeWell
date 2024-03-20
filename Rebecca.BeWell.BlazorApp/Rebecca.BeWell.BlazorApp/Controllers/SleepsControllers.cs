using Microsoft.AspNetCore.Mvc;
using Rebecca.BeWell.BlazorApp.Data.Models;
using Rebecca.BeWell.BlazorApp.Services;
using Rebecca.BeWell.BlazorApp.Services.Interfaces;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebecca.BeWell.BlazorApp.Controllers
{
    [Route("api/Sleeps")]
    [ApiController]
    public class SleepsControllers : ControllerBase
    {

    private readonly ISleepService _sleepService;

        public SleepsControllers(ISleepService sleepService)
        {
            _sleepService = sleepService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSleepById(int Id)
        {
            Data.Models.Sleep sleep = await _sleepService.GetSleepById(Id);

            return Ok(sleep);
        }




        // POST api/Activity/Update
        [HttpPost]
        public async Task<IActionResult> Update(Data.Models.Sleep sleep)
        {

            bool isUpdated = await  _sleepService.UpdateSleep(sleep);

            return Ok(isUpdated);
        }

        // POST api/Activity/Create
        [HttpPost]
        public async Task<IActionResult> Create(Data.Models.Sleep sleep)
        {

            bool isCreated = await _sleepService.CreateSleep(sleep);

            return Ok(isCreated);
        }


        // DELETE api/<SleepsControllers>/5
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDelete = await _sleepService.DeleteSleep(id);

            return Ok(isDelete);
        }
    }
}
