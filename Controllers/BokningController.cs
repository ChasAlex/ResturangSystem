using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturangSystem.Models.DTO;
using ResturangSystem.Service.IServices;

namespace ResturangSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BokningController : ControllerBase
    {
        private readonly IBokningService _bokningService;

        public BokningController(IBokningService bokningService)
        {
            _bokningService = bokningService;
        }

        [HttpGet("/getAll")]
        public async Task<IActionResult> GetBokningar()
        {
            try
            {
                var bokningar = await _bokningService.GetAllBokningAsync();
                return Ok(bokningar);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("/get/{id}")]
        public async Task<IActionResult> GetBokning(int id)
        {
            try
            {
                var bokning = await _bokningService.GetBokningIdAsync(id);
                return Ok(bokning);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("/add")]
        public async Task<IActionResult> CreateBokning(BokningDTO bokning)
        {
            try
            {
                await _bokningService.AddBokningAsync(bokning);
                return Ok(bokning);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("/update")]
        public async Task<IActionResult> UpdateBokning(BokningDTO bokning)
        {
            try
            {
                await _bokningService.UpdateBokningAsync(bokning);
                return Ok(bokning);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("/delte/{id}")]
        public async Task<IActionResult> DeleteBokning(int id)
        {
            try
            {
                await _bokningService.DeleteBokningAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }           
    }
}
