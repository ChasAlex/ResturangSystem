using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturangSystem.Models.DTO;
using ResturangSystem.Service.IServices;

namespace ResturangSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KundController : ControllerBase
    {

        private readonly IKundService _kundService;

        public KundController(IKundService kundService)
        {
            _kundService = kundService;
        }

        [HttpGet("/getAllKund")]
        public async Task<IActionResult> GetAllKundAsync()
        {
            var kund = await _kundService.GetAllKundAsync();
            return Ok(kund);
        }

        [HttpGet("/getKund/{id}")]
        public async Task<IActionResult> GetKundIdAsync(int id)
        {
            var kund = await _kundService.GetKundIdAsync(id);
            return Ok(kund);
        }

        [HttpPost("/addKund")]
        public async Task<IActionResult> AddKundAsync(KundDTO kund)
        {
            await _kundService.AddKundAsync(kund);
            return Ok();
        }

        [HttpPut("/updateKund")]
        public async Task<IActionResult> UpdateKundAsync(KundDTO kund)
        {
            await _kundService.UpdateKundAsync(kund);
            return Ok();
        }

        [HttpDelete("/deleteKund/{id}")]
        public async Task<IActionResult> DeleteKundAsync(int id)
        {
            await _kundService.DeleteKundAsync(id);
            return Ok();
        }
    }
}
