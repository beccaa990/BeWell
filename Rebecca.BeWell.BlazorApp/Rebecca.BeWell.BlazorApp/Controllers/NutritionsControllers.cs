using Microsoft.AspNetCore.Mvc;
using Rebecca.BeWell.BlazorApp.Shared.Data.Models;
using Rebecca.BeWell.BlazorApp.Services;
using Rebecca.BeWell.BlazorApp.Services.Interfaces;
using System.Diagnostics;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebecca.BeWell.BlazorApp.Controllers
{
    [Route("api/Nutritions")]
    [ApiController]
    public class NutritionsControllers : ControllerBase
    {

    private readonly INutritionService _nutritionService;

        public NutritionsControllers(INutritionService nutritionService)
        {
            _nutritionService = nutritionService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetNutritionById(int Id)
        {
           Nutrition nutrition = await _nutritionService.GetNutritionById(Id);

            return Ok(nutrition);
        }


        [HttpGet("user/{userid}")]

        public async Task<IActionResult> GetNutritionsByUserId(string userId)
        {
            List<Nutrition> nutrition = await _nutritionService.GetNutritionsByUserId(userId);

            return Ok(nutrition);
        }

        [HttpGet("GetNutritionTypes")]

        public async Task<IActionResult> GetNutritionTypes()
        {
            List<Shared.Data.Models.NutritionType> nutritionTypes = await _nutritionService.GetNutritionTypes();

            return Ok(nutritionTypes.OrderBy(o => o.Name));


        }

        // POST api/Activity/Update
        [HttpPost("update")]
        public async Task<IActionResult> Update(Nutrition nutrition)
        {

            bool isUpdated = await  _nutritionService.UpdateNutrition(nutrition);

            return Ok(isUpdated);
        }

        // POST api/Activity/Create
        [HttpPost("create")]
        public async Task<IActionResult> Create(Nutrition nutrition)
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool isCreated = await _nutritionService.CreateNutrition(nutrition, userId);
     
            return Ok(isCreated);
        }


        // DELETE api/<NutritionsController>/5
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDelete = await _nutritionService.DeleteNutrition(id);

            return Ok(isDelete);
        }
    }
}
