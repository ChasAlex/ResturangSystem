using ResturangSystem.Models.DTO;
using ResturangSystem.Models.Viewmodels;

namespace ResturangSystem.Service.IServices
{
    public interface IBokningService
    {
        Task<IEnumerable<BokningDTO>> GetAllBokningAsync();
        Task<BokningDTO> GetBokningIdAsync(int id);
        Task<BokningDTO> AddBokningAsync(BokningDTO bok);
        Task <BokningDTO> UpdateBokningAsync(UpdateBokningDTO bok);
        Task DeleteBokningAsync(int id);
        
        
    }
}
