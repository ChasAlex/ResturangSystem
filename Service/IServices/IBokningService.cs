using ResturangSystem.Models.DTO;

namespace ResturangSystem.Service.IServices
{
    public interface IBokningService
    {
        Task<IEnumerable<BokningDTO>> GetAllBokningAsync();
        Task<BokningDTO> GetBokningIdAsync(int id);
        Task AddBokningAsync(BokningDTO bok);
        Task UpdateBokningAsync(BokningDTO bok);
        Task DeleteBokningAsync(int id);
        
        
    }
}
