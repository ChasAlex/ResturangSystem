using ResturangSystem.Models.DTO;

namespace ResturangSystem.Service.IServices
{
    public interface IKundService
    {
        Task<IEnumerable<KundDTO>> GetAllKundAsync();
        Task<KundDTO> GetKundIdAsync(int id);
        Task AddKundAsync(KundDTO kund);
        Task UpdateKundAsync(KundDTO kund);
        Task DeleteKundAsync(int id);
    }
}
