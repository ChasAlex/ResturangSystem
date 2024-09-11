using ResturangSystem.Data.Repos.IRepos;
using ResturangSystem.Models;
using ResturangSystem.Models.DTO;
using ResturangSystem.Service.IServices;

namespace ResturangSystem.Service
{
    public class BordService : IBordService
    {
        private readonly IBordRepo _bordRepo;

        public BordService(IBordRepo bordRepo)
        {
            _bordRepo = bordRepo;
        }

        public async Task AddBordAsync(BordDTO bord)
        {
            var bordToAdd = new Bord
            {
                
                Bordsnummer = bord.Bordsnummer,
                Platser = bord.Platser,
                BoolBokad = bord.BoolBokad,
                RestaurangId = bord.RestaurangId,
                Bokningar = new List<Bokning>(),



            };

            await _bordRepo.CreateBordAsync(bordToAdd);
        }

        public async Task DeleteBordAsync(int id)
        {
            await _bordRepo.DeleteBordAsync(id);
        }

        public async Task<IEnumerable<BordDTO>> GetAllBordAsync()
        {
            var bordList = await _bordRepo.GetAllBordAsync();
            return bordList.Select(b => new BordDTO
            {
                
                Bordsnummer = b.Bordsnummer,
                Platser = b.Platser,
                BoolBokad = b.BoolBokad,
               
            });
        }

        public async Task<List<AvailableBokningDTO>> GetAvailableBordsAsync(AvailableTableDTO dto)
        {
            var availableBord = await _bordRepo.GetAvailableTablesAsync(dto);

            // Ensure the collection is not null
            if (availableBord == null)
            {
                return new List<AvailableBokningDTO>();
            }

            return availableBord.Select(b => new AvailableBokningDTO
            {
                BordsNummer = b.Bordsnummer
                
            }).ToList();
        }



        public async Task<BordDTO> GetBordIdAsync(int id)
        {
            var bord = await _bordRepo.GetBordAsync(id);

            return new BordDTO
            {
                
                Bordsnummer = bord.Bordsnummer,
                Platser = bord.Platser,
                BoolBokad = bord.BoolBokad
                
            };
        }

        public async Task UpdateBordAsync(BordDTO bord)
        {
            var UpdatedBord = new Bord
            {
                
                Bordsnummer = bord.Bordsnummer,
                Platser = bord.Platser,
                BoolBokad = bord.BoolBokad
            };
            await _bordRepo.UpdateBordAsync(UpdatedBord);

        }

        public async Task<int> FindBordByBordsnummerAsync(int bordsnummer)
        {
            var bord = await _bordRepo.FindBordByBordsnummerAsync(bordsnummer);
            return bord.BordId;
        }
    }
}
