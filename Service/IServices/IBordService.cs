using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResturangSystem.Models.DTO;

namespace ResturangSystem.Service.IServices
{
    public interface IBordService
    {
        Task<IEnumerable<BordDTO>> GetAllBordAsync();
        Task<BordDTO> GetBordIdAsync(int id);
        Task AddBordAsync(BordDTO bord);
        Task UpdateBordAsync(BordDTO bord);
        Task DeleteBordAsync(int id);
        Task<List<AvailableBokningDTO>> GetAvailableBordsAsync(AvailableTableDTO dto);


    }
}
