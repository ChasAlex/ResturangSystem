using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturangSystem.Models.DTO;
using ResturangSystem.Service.IServices;

namespace ResturangSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenyController : ControllerBase
    {
        private readonly IMenyService _menyService;

        public MenyController(IMenyService menyService)
        {
            _menyService = menyService;
        }



        [HttpGet("/getAllMeny")]
        public async Task<IActionResult> GetAllMenyAsync()
        {
            var meny = await _menyService.GetAllMenyAsync();
            return Ok(meny);
        }

        [HttpGet("/getMeny/{id}")]
        public async Task<IActionResult> GetMenyIdAsync(int id)
        {
            var meny = await _menyService.GetMenyIdAsync(id);
            return Ok(meny);
        }

        [HttpPost("/addMeny")]
        public async Task<IActionResult> AddMenyAsync(MenyDTO meny)
        {
            await _menyService.AddMenyAsync(meny);
            return Ok();
        }

        [HttpPut("/updateMeny")]
        public async Task<IActionResult> UpdateMenyAsync(MenyDTO meny)
        {
            await _menyService.UpdateMenyAsync(meny);
            return Ok();
        }

        [HttpDelete("/deleteMeny/{id}")]
        public async Task<IActionResult> DeleteMenyAsync(int id)
        {
            await _menyService.DeleteMenyAsync(id);
            return Ok();
        }


    }
}
