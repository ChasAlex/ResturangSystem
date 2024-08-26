using ResturangSystem.Models;

namespace ResturangSystem.Data.Repos.IRepos
{
    public interface IKundRepo
    {
        Task<IEnumerable<Kund>> GetKunderAsync();
        Task<Kund> GetKundAsync(int id);
        Task<Kund> CreateKundAsync(Kund kund);
        Task<Kund> UpdateKundAsync(Kund kund);
        Task<Kund> DeleteKundAsync(int id);
    }
}
