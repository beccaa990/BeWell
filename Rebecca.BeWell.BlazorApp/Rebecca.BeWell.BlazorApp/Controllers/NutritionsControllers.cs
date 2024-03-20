using Microsoft.AspNetCore.Mvc;
using Rebecca.BeWell.BlazorApp.Data.Models;
using Rebecca.BeWell.BlazorApp.Services;
using Rebecca.BeWell.BlazorApp.Services.Interfaces;
using System.Diagnostics;

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
            Data.Models.Nutrition nutrition = await _nutritionService.GetNutritionById(Id);

            return Ok(nutrition);
        }


        [HttpGet("user/{userid}")]

        public async Task<IActionResult> GetNutritionsByUserId(string userId)
        {
            List<Data.Models.Nutrition> nutrition = await _nutritionService.GetNutritionsByUserId(userId);

            return Ok(nutrition);
        }


        // POST api/Activity/Update
        [HttpPost]
        public async Task<IActionResult> Update(Data.Models.Nutrition nutrition)
        {

            bool isUpdated = await  _nutritionService.UpdateNutrition(nutrition);

            return Ok(isUpdated);
        }

        // POST api/Activity/Create
        [HttpPost]
        public async Task<IActionResult> Create(Data.Models.Nutrition nutrition)
        {

            bool isCreated = await _nutritionService.CreateNutrition(nutrition);

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
