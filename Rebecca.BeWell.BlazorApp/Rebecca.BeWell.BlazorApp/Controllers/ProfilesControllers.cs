using Microsoft.AspNetCore.Mvc;
using Rebecca.BeWell.BlazorApp.Shared.Data.Models;
using Rebecca.BeWell.BlazorApp.Services;
using Rebecca.BeWell.BlazorApp.Services.Interfaces;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebecca.BeWell.BlazorApp.Controllers
{
    [Route("api/Profiles")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {

    private readonly IProfileService _profileService;

        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileById(int Id)
        {
            Profile profile = await _profileService.GetProfileById(Id);

            return Ok(profile);
        }


        [HttpGet("user/{userid}")]

        public async Task<IActionResult> GetProfilesByUserId(string userId)
        {
            Profile profile = await _profileService.GetProfileByUserId(userId);

            return Ok(profile);
        }


        // POST api/Activity/Update
        [HttpPost]
        public async Task<IActionResult> Update(Profile profile)
        {

            bool isUpdated = await  _profileService.UpdateProfile(profile);

            return Ok(isUpdated);
        }

        // POST api/Activity/Create
        [HttpPost]
        public async Task<IActionResult> Create(Profile profile)
        {

            bool isCreated = await _profileService.CreateProfile(profile);

            return Ok(isCreated);
        }


        // DELETE api/<ProfilesControllers>/5
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDelete = await _profileService.DeleteProfile(id);

            return Ok(isDelete);
        }
    }
}
