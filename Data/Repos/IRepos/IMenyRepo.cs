using ResturangSystem.Models;

namespace ResturangSystem.Data.Repos.IRepos
{
    public interface IMenyRepo
    {
        Task<IEnumerable<Meny>> GetMenyerAsync();
        Task<Meny> GetMenyAsync(int id);
        Task<Meny> CreateMenyAsync(Meny meny);
        Task<Meny> UpdateMenyAsync(Meny meny);
        Task<Meny> DeleteMenyAsync(int id);
    }
}
