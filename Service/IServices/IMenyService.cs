using ResturangSystem.Models.DTO;

namespace ResturangSystem.Service.IServices
{
    public interface IMenyService
    {
        Task<IEnumerable<MenyDTO>> GetAllMenyAsync();
        Task<MenyDTO> GetMenyIdAsync(int id);
        Task AddMenyAsync(MenyDTO meny);
        Task UpdateMenyAsync(MenyDTO meny);
        Task DeleteMenyAsync(int id);
    }
}
