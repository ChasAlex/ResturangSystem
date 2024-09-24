using ResturangSystem.Models;

namespace ResturangSystem.Data.Repos.IRepos
{
    public interface IBokningRepo
    {
        Task<IEnumerable<Bokning>> GetBokningarAsync();
        Task<Bokning> GetBokningAsync(int id);
        Task<Bokning> CreateBokningAsync(Bokning bokning);
        Task<Bokning> UpdateBokningAsync(Bokning bokning);
        Task<Bokning> DeleteBokningAsync(int id);
        Task<Bokning> GetBokningPLUSAsync(int id);
    }
}
