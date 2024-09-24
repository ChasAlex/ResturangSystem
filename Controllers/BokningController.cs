using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResturangSystem.Models;
using ResturangSystem.Models.DTO;
using ResturangSystem.Models.Viewmodels;
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
                var bokningToReturn = new List<ListAllBokningViewModel>();
                var bokningar = await _bokningService.GetAllBokningAsync();

                foreach(var book in bokningar)
                {   
                    var kund = await _kundService.GetKundIdAsync(book.KundId);
                    var bord = await _bordService.GetBordIdAsync(book.BordId);

                    var bookingToadd = new ListAllBokningViewModel
                    {   

                        BokningId = book.BokningId,
                        Antal = book.Antal,
                        Namn = kund.Namn,
                        Datum = DateOnly.FromDateTime(book.Datetime),
                        BordNummer = bord.Bordsnummer
                    };
                    bokningToReturn.Add(bookingToadd);

                }

                

                return Ok(bokningToReturn);
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
                var kund = new KundDTO { Namn = dto.Namn, Email = dto.Email };
                var kundId = await _kundService.AddKundAsync(kund);


                // Hitta bord Id från bord nummer
                var bordId = await _bordService.FindBordByBordsnummerAsync(dto.Bordnummer);


                //Lägg till bokning
                var bokning = new BokningDTO { Antal = dto.Antal, KundId = kundId, BordId = bordId, Datetime = dto.Datum };
                var addedBookning = await _bokningService.AddBokningAsync(bokning);

                var bokningToReturn = new ListAllBokningViewModel
                {
                    BokningId = addedBookning.BokningId,
                    Antal = addedBookning.Antal,
                    Namn = dto.Namn,
                    Datum = DateOnly.FromDateTime(addedBookning.Datetime),
                    BordNummer = dto.Bordnummer
                };
                return Ok(bokningToReturn);



            }
            catch (Exception e) { return StatusCode(StatusCodes.Status500InternalServerError, e.Message); }



            
        }




        [HttpPut("/update")]
        public async Task<IActionResult> UpdateBokning([FromBody]UpdateBokningDTO bokning)
        {
            try
            {
                var result = await _bokningService.UpdateBokningAsync(bokning);

                var resultToReturn = new ListAllBokningViewModel
                {
                    BokningId = result.BokningId,
                    Antal = result.Antal,
                    Namn = bokning.Namn,
                    Datum = DateOnly.FromDateTime(result.Datetime),
                    BordNummer = bokning.Bordnummer
                };

                return Ok(resultToReturn);
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
