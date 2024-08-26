using ResturangSystem.Models;

namespace ResturangSystem.Data.Repos.IRepos
{
    public interface IResturangRepo
    {
        Task<IEnumerable<Restaurang>> GetResturangerAsync();
        Task<Restaurang> GetResturangAsync(int id);
        Task<Restaurang> CreateResturangAsync(Restaurang resturang);
        Task<Restaurang> UpdateResturangAsync(Restaurang resturang);
        Task<Restaurang> DeleteResturangAsync(int id);
    }
}
