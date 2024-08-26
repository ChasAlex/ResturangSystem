using ResturangSystem.Data.Repos.IRepos;
using ResturangSystem.Models;
using ResturangSystem.Models.DTO;
using ResturangSystem.Service.IServices;

namespace ResturangSystem.Service
{
    public class BokningService : IBokningService
    {   
        private readonly IBokningRepo _bokningRepo;

        public BokningService(IBokningRepo bokningRepo)
        {
            _bokningRepo = bokningRepo;
        }

        public async Task AddBokningAsync(BokningDTO bok)
        {
           var bokToAdd = new Bokning
           {
               Antal = bok.Antal,
               KundId = bok.KundId,
               BordId = bok.BordId,
               Datum = DateTime.Now


           };
            await _bokningRepo.CreateBokningAsync(bokToAdd);



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

        public async Task UpdateBokningAsync(BokningDTO bok)
        {
           var bokToUpdate = new Bokning
           {
               Antal = bok.Antal,
               KundId = bok.KundId,
               BordId = bok.BordId,
               Datum = DateTime.Now
           };
        }
    }
}
