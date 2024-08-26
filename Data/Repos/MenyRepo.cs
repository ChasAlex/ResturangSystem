using Microsoft.EntityFrameworkCore;
using ResturangSystem.Data.Repos.IRepos;
using ResturangSystem.Models;

namespace ResturangSystem.Data.Repos
{
    public class MenyRepo : IMenyRepo
    {
        private readonly ResturangContext _context;

        public MenyRepo(ResturangContext context)
        {
            _context = context;
        }

        public async Task<Meny> CreateMenyAsync(Meny meny)
        {
            try
            {
                await _context.Meny.AddAsync(meny);
                await _context.SaveChangesAsync();
                return meny;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<Meny> DeleteMenyAsync(int id)
        {
            try
            {
                var MenyToDelete = await _context.Meny.FindAsync(id);
                if (MenyToDelete != null)
                {
                    _context.Meny.Remove(MenyToDelete);
                    await _context.SaveChangesAsync();
                    return MenyToDelete;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<Meny> GetMenyAsync(int id)
        {
            try
            {
                return await _context.Meny.FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<IEnumerable<Meny>> GetMenyerAsync()
        {
            try
            {
                return await _context.Meny.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<Meny> UpdateMenyAsync(Meny meny)
        {
            try
            {
                _context.Meny.Update(meny);
                await _context.SaveChangesAsync();
                return meny;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }
    }
}
