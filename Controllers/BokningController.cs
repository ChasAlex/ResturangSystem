using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResturangSystem.Models;
using ResturangSystem.Models.DTO;
using ResturangSystem.Service.IServices;
using System.Runtime.CompilerServices;

namespace ResturangSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BokningController : ControllerBase
    {
        private readonly IBokningService _bokningService;
        private readonly IKundService _kundService;
        private readonly IBordService _bordService;


        public BokningController(IBokningService bokningService, IKundService kundService, IBordService bordService)
        {
            _bokningService = bokningService;
            _kundService = kundService;
            _bordService = bordService;
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
                var bokning = await _bokningService.GetBokningIdAsync(id);
                
                if(bokning == null) { return NotFound(); }
                return Ok(bokning);
        }

        [HttpPost("/add")]
        public async Task<IActionResult> CreateBokning([FromBody]CreateBokningDTO dto)
        {
            try {
                // Skapa kund, returnera kundId
                var kund = new KundDTO { Namn = dto.Name, Email = dto.Email };
                var kundId = await _kundService.AddKundAsync(kund);


                // Hitta bord Id från bord nummer
                var bordId = await _bordService.FindBordByBordsnummerAsync(dto.Bordsnummer);


                //Lägg till bokning
                var bokning = new BokningDTO { Antal = dto.Antal, KundId = kundId, BordId = bordId, Datetime = dto.Datum };
                await _bokningService.AddBokningAsync(bokning);

                return Created();



            }
            catch (Exception e) { return StatusCode(StatusCodes.Status500InternalServerError, e.Message); }



            
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
