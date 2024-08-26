using Microsoft.EntityFrameworkCore;
using ResturangSystem.Data.Repos.IRepos;
using ResturangSystem.Models;

namespace ResturangSystem.Data.Repos
{
    public class ResturangRepo : IResturangRepo
    {
        private readonly ResturangContext _context;

        public ResturangRepo(ResturangContext context)
        {
            _context = context;
        }

        public async Task<Restaurang> CreateResturangAsync(Restaurang resturang)
        {
            try
            {
                await _context.Restaurang.AddAsync(resturang);
                await _context.SaveChangesAsync();
                return resturang;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<Restaurang> DeleteResturangAsync(int id)
        {
            try
            {
                var RestToDelete = await _context.Restaurang.FindAsync(id);
                if (RestToDelete != null)
                {
                    _context.Restaurang.Remove(RestToDelete);
                    await _context.SaveChangesAsync();
                    return RestToDelete;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<Restaurang> GetResturangAsync(int id)
        {
            try
            {
                return await _context.Restaurang.FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<IEnumerable<Restaurang>> GetResturangerAsync()
        {
            try
            {
                return await _context.Restaurang.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<Restaurang> UpdateResturangAsync(Restaurang resturang)
        {
            try
            {
                _context.Restaurang.Update(resturang);
                await _context.SaveChangesAsync();
                return resturang;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }
    }
}
