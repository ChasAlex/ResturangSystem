using ResturangSystem.Models;
using ResturangSystem.Models.DTO;

namespace ResturangSystem.Data.Repos.IRepos
{
    public interface IBordRepo
    {
        Task<IEnumerable<Bord>> GetAllBordAsync();
        Task<Bord> GetBordAsync(int id);
        Task<Bord> CreateBordAsync(Bord bord);
        Task<Bord> UpdateBordAsync(Bord bord);
        Task<Bord> DeleteBordAsync(int id);
        Task<List<Bord>> GetAvailableTablesAsync(AvailableTableDTO dto);
        Task<Bord> FindBordByBordsnummerAsync(int bordsnummer);
    }
}
