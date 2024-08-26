using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturangSystem.Models.DTO;
using ResturangSystem.Service.IServices;

namespace ResturangSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturangController : ControllerBase
    {
        private readonly IResturangService _resturangService;

        public ResturangController(IResturangService resturangService)
        {
            _resturangService = resturangService;
        }


        [HttpGet("/getAllResturang")]
        public async Task<IActionResult> GetAllResturangAsync()
        {
            var resturang = await _resturangService.GetAllResturangAsync();
            return Ok(resturang);
        }

        [HttpGet("/getResturang/{id}")]
        public async Task<IActionResult> GetResturangIdAsync(int id)
        {
            var resturang = await _resturangService.GetResturangIdAsync(id);
            return Ok(resturang);
        }

        [HttpPost("/addResturang")]
        public async Task<IActionResult> AddResturangAsync(ResturangDTO resturang)
        {
            await _resturangService.AddResturangAsync(resturang);
            return Ok();
        }

        [HttpPut("/updateResturang")]
        public async Task<IActionResult> UpdateResturangAsync(ResturangDTO resturang)
        {
            await _resturangService.UpdateResturangAsync(resturang);
            return Ok();
        }

        [HttpDelete("/deleteResturang/{id}")]
        public async Task<IActionResult> DeleteResturangAsync(int id)
        {
            await _resturangService.DeleteResturangAsync(id);
            return Ok();
        }


    }
}
