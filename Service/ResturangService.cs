using ResturangSystem.Data.Repos.IRepos;
using ResturangSystem.Models;
using ResturangSystem.Models.DTO;
using ResturangSystem.Service.IServices;

namespace ResturangSystem.Service
{
    public class ResturangService : IResturangService
    {
        private readonly IResturangRepo _resturangRepo;

        public ResturangService(IResturangRepo resturangRepo)
        {
            _resturangRepo = resturangRepo;
        }


        public async Task AddResturangAsync(ResturangDTO resturang)
        {
            var restToAdd = new Restaurang
            {
                RestaurangId = resturang.RestaurangId,
                Namn = resturang.Namn,
                Bord = resturang.Bord,
                Meny = resturang.Meny
            };

            await _resturangRepo.CreateResturangAsync(restToAdd);

        }

        public async Task DeleteResturangAsync(int id)
        {
            await _resturangRepo.DeleteResturangAsync(id);
        }

        public async Task<IEnumerable<ResturangDTO>> GetAllResturangAsync()
        {
            var restList = await _resturangRepo.GetResturangerAsync();

            return restList.Select(r => new ResturangDTO
            {
                RestaurangId = r.RestaurangId,
                Namn = r.Namn,
                Bord = r.Bord,
                Meny = r.Meny
            });
        }

        public async Task<ResturangDTO> GetResturangIdAsync(int id)
        {
            var rest = await _resturangRepo.GetResturangAsync(id);

            return new ResturangDTO
            {
                RestaurangId = rest.RestaurangId,
                Namn = rest.Namn,
                Bord = rest.Bord,
                Meny = rest.Meny
            };
        }

        public async Task UpdateResturangAsync(ResturangDTO resturang)
        {
            var restToUpdate = new Restaurang
            {
                RestaurangId = resturang.RestaurangId,
                Namn = resturang.Namn,
                Bord = resturang.Bord,
                Meny = resturang.Meny
            };  
            await _resturangRepo.UpdateResturangAsync(restToUpdate);
        }
    }
}
