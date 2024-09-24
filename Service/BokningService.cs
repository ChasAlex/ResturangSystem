using ResturangSystem.Data.Repos.IRepos;
using ResturangSystem.Models;
using ResturangSystem.Models.DTO;
using ResturangSystem.Models.Viewmodels;
using ResturangSystem.Service.IServices;

namespace ResturangSystem.Service
{
    public class BokningService : IBokningService
    {   
        private readonly IBokningRepo _bokningRepo;
        private readonly IKundService _kundService;
        private readonly IBordService _bordService;

        public BokningService(IBokningRepo bokningRepo, IKundService kundService, IBordService bordService)
        {
            _bokningRepo = bokningRepo;
            _kundService = kundService;
            _bordService = bordService;
        }

        public async Task<BokningDTO> AddBokningAsync(BokningDTO bok)
        {
           var bokToAdd = new Bokning
           {
               Antal = bok.Antal,
               KundId = bok.KundId,
               BordId = bok.BordId,
               Datum = bok.Datetime


           };
            var savedBooking =await _bokningRepo.CreateBokningAsync(bokToAdd);

            return new BokningDTO
            {
                BokningId = savedBooking.BokningId,
                Antal = savedBooking.Antal,
                KundId = savedBooking.KundId,
                BordId = savedBooking.BordId,
                Datetime = savedBooking.Datum

            };

            

        }

        public async Task DeleteBokningAsync(int id)
        {
            await _bokningRepo.DeleteBokningAsync(id);
        }

        public async Task<IEnumerable<BokningDTO>> GetAllBokningAsync()
        {
            var bokningList = await _bokningRepo.GetBokningarAsync();
            return bokningList.Select(b => new BokningDTO
            {
                BokningId = b.BokningId,
                Antal = b.Antal,
                KundId = b.KundId,
                BordId = b.BordId,
                Datetime = b.Datum

            });
        }

        public async Task<BokningDTO> GetBokningIdAsync(int id)
        {
            var bokning =  await _bokningRepo.GetBokningAsync(id);

            return new BokningDTO
            {
                BokningId = bokning.BokningId,
                Antal = bokning.Antal,
                KundId = bokning.KundId,
                BordId = bokning.BordId
            };

        }

        public async Task<BokningDTO> UpdateBokningAsync(UpdateBokningDTO bok)
        {
           var bokning = await _bokningRepo.GetBokningPLUSAsync(bok.BokningId);

            if (bokning == null)
            {
                throw new InvalidOperationException("Bokning not found.");
            }
            bokning.Kund.Namn = bok.Namn;
            bokning.Bord.Bordsnummer = bok.Bordnummer;
            bokning.Antal = bok.Antal;
            bokning.Datum = bok.Datum;



            
            await _bokningRepo.UpdateBokningAsync(bokning);
            return new BokningDTO { BokningId = bokning.BokningId, Antal = bokning.Antal, KundId = bokning.KundId, BordId = bokning.BordId, Datetime = bokning.Datum };
        }
    }
}
