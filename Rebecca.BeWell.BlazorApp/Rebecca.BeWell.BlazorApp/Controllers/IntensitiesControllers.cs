using Microsoft.AspNetCore.Mvc;
using Rebecca.BeWell.BlazorApp.Shared.Data.Models;
using Rebecca.BeWell.BlazorApp.Services;
using Rebecca.BeWell.BlazorApp.Services.Interfaces;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebecca.BeWell.BlazorApp.Controllers
{
    [Route("api/Intensities")]
    [ApiController]
    public class IntensitiesControllers : ControllerBase
    {

    private readonly IIntensityService _intensityService;

        public IntensitiesControllers(IIntensityService intensityService)
        {
            _intensityService = intensityService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetIntensityById(int Id)
        {
            Intensity intensity = await _intensityService.GetIntensityById(Id);

            return Ok(intensity);
        }


        [HttpGet]

        public async Task<IActionResult> GetIntensities()
        {
            List<Intensity> intensity = await _intensityService.GetIntensities();

            return Ok(intensity);
        }

        [HttpGet("user/{userid}")]

        public async Task<IActionResult> GetIntensitiesByUserId(string userId)
        {
            List<Intensity> intensity = await _intensityService.GetIntensitiesByUserId(userId);

            return Ok(intensity);
        }


        // POST api/Intensity/Update
        [HttpPost]
        public async Task<IActionResult> Update(Intensity intensity)
        {

            bool isUpdated = await  _intensityService.UpdateIntensity(intensity);

            return Ok(isUpdated);
        }

        // POST api/Intensity/Create
        [HttpPost]
        public async Task<IActionResult> Create(Intensity intensity)
        {

            bool isCreated = await _intensityService.CreateIntensity(intensity);

            return Ok(isCreated);
        }


        // DELETE api/<IntensitiesControllers>/5
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDelete = await _intensityService.DeleteIntensity(id);

            return Ok(isDelete);
        }
    }
}
