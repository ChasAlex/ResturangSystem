using ResturangSystem.Data.Repos.IRepos;
using ResturangSystem.Models;
using ResturangSystem.Models.DTO;
using ResturangSystem.Service.IServices;

namespace ResturangSystem.Service
{
    public class KundService : IKundService
    {
        private readonly IKundRepo _kundRepo;

        public KundService(IKundRepo kundRepo)
        {
            _kundRepo = kundRepo;
        } 


        public async Task<int> AddKundAsync(KundDTO kund)
        {
            var kundToAdd = new Kund
            {
                
                Namn = kund.Namn,
                Email = kund.Email,
                Bokningar = kund.Bokningar
            };

            var kundToReturn = await _kundRepo.CreateKundAsync(kundToAdd);
            return kundToReturn.KundId;

        }

        public async Task DeleteKundAsync(int id)
        {
            await _kundRepo.DeleteKundAsync(id);
        }

        public async Task<IEnumerable<KundDTO>> GetAllKundAsync()
        {
            var kundList = await _kundRepo.GetKunderAsync();

            return kundList.Select(k => new KundDTO
            {
                KundId = k.KundId,
                Namn = k.Namn,
                Email = k.Email,
                Bokningar = k.Bokningar
            });


        }

        public async Task<KundDTO> GetKundIdAsync(int id)
        {
            var kund = await _kundRepo.GetKundAsync(id);
            
            return new KundDTO
            {
                KundId = kund.KundId,
                Namn = kund.Namn,
                Email = kund.Email,
                Bokningar = kund.Bokningar
            };
        }

        public async Task UpdateKundAsync(KundDTO kund)
        {
            var kundToUpdate = new Kund
            {
               
                Namn = kund.Namn,
                Email = kund.Email,
                Bokningar = kund.Bokningar
            };

            await _kundRepo.UpdateKundAsync(kundToUpdate);
        }


        
    }
}
