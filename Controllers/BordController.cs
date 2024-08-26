using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturangSystem.Models.DTO;
using ResturangSystem.Service.IServices;

namespace ResturangSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BordController : ControllerBase
    {
        private readonly IBordService _bordService;

        public BordController(IBordService bordService)
        {
            _bordService = bordService;
        }

        [HttpGet("/getAllBord")]
        public async Task<IActionResult> GetAllBordAsync()
        {
            var bord = await _bordService.GetAllBordAsync();
            return Ok(bord);
        }

        [HttpGet("/getBord/{id}")]
        public async Task<IActionResult> GetBordIdAsync(int id)
        {
            var bord = await _bordService.GetBordIdAsync(id);
            return Ok(bord);
        }

        [HttpPost("/addBord")]
        public async Task<IActionResult> AddBordAsync(BordDTO bord)
        {
            await _bordService.AddBordAsync(bord);
            return Ok();
        }

        [HttpPut("/updateBord")]

        public async Task<IActionResult> UpdateBordAsync(BordDTO bord)
        {
            await _bordService.UpdateBordAsync(bord);
            return Ok();
        }


        [HttpDelete("/deleteBord/{id}")]
        public async Task<IActionResult> DeleteBordAsync(int id)
        {
            await _bordService.DeleteBordAsync(id);
            return Ok();
        }

        [HttpPost("/getAvailableBords")]
        public async Task<IActionResult> GetAvailableBordsAsync([FromBody] AvailableTableDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("DTO cannot be null");
            }

            var availableBord = await _bordService.GetAvailableBordsAsync(dto);
            return Ok(availableBord);
        }

    }
}
