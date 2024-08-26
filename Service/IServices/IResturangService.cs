using ResturangSystem.Models.DTO;

namespace ResturangSystem.Service.IServices
{
    public interface IResturangService
    {
        Task<IEnumerable<ResturangDTO>> GetAllResturangAsync();
        Task<ResturangDTO> GetResturangIdAsync(int id);
        Task AddResturangAsync(ResturangDTO resturang);
        Task UpdateResturangAsync(ResturangDTO resturang);
        Task DeleteResturangAsync(int id);
    }
}
