using ResturangSystem.Data.Repos.IRepos;
using ResturangSystem.Models;
using ResturangSystem.Models.DTO;
using ResturangSystem.Service.IServices;

namespace ResturangSystem.Service
{
    public class MenyService : IMenyService
    {
        private readonly IMenyRepo _menyRepo;


        public MenyService(IMenyRepo menyRepo)
        {
            _menyRepo  = menyRepo;
        }



        public async Task AddMenyAsync(MenyDTO meny)
        {
            var menyToAdd = new Meny
            {
                MenyId = meny.MenyId,
                Namn = meny.Namn,
                Pris = meny.Pris,
                Tillgänglig = meny.Tillgänglig,
                Restaurang = meny.Restaurang

            };
            
            await _menyRepo.CreateMenyAsync(menyToAdd);

        }

        public async Task DeleteMenyAsync(int id)
        {
            await _menyRepo.DeleteMenyAsync(id);
        }

        public async Task<IEnumerable<MenyDTO>> GetAllMenyAsync()
        {
            var MenyList = await _menyRepo.GetMenyerAsync();

            return MenyList.Select(m => new MenyDTO
            {
                MenyId = m.MenyId,
                Namn = m.Namn,
                Pris = m.Pris,
                Tillgänglig = m.Tillgänglig,
                Restaurang = m.Restaurang

            });

        }

        public async Task<MenyDTO> GetMenyIdAsync(int id)
        {
            var meny = await _menyRepo.GetMenyAsync(id);

            return new MenyDTO
            {
                MenyId = meny.MenyId,
                Namn = meny.Namn,
                Pris = meny.Pris,
                Tillgänglig = meny.Tillgänglig,
                Restaurang = meny.Restaurang
            };

        }

        public async Task UpdateMenyAsync(MenyDTO meny)
        {
            var menyToUpdate = new Meny
            {
                MenyId = meny.MenyId,
                Namn = meny.Namn,
                Pris = meny.Pris,
                Tillgänglig = meny.Tillgänglig,
                Restaurang = meny.Restaurang
            };

            await _menyRepo.UpdateMenyAsync(menyToUpdate);

        }
    }
}
