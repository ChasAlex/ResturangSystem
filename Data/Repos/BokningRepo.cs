using Microsoft.EntityFrameworkCore;
using ResturangSystem.Data.Repos.IRepos;
using ResturangSystem.Models;

namespace ResturangSystem.Data.Repos
{
    public class BokningRepo : IBokningRepo
    {   
        private readonly ResturangContext _context;

        public BokningRepo(ResturangContext context)
        {
            _context = context;
        }



        public async Task<Bokning> CreateBokningAsync(Bokning bokning)
        {
            try
            {
                await _context.Bokning.AddAsync(bokning);
                await _context.SaveChangesAsync();
                return bokning;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<Bokning> DeleteBokningAsync(int id)
        {
            try
            {
                var BokingToDelete = await _context.Bokning.FindAsync(id);
                if (BokingToDelete != null)
                {
                    _context.Bokning.Remove(BokingToDelete);
                    await _context.SaveChangesAsync();
                    return BokingToDelete;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<IEnumerable<Bokning>> GetBokningarAsync()
        {
            try
            {
                return await _context.Bokning.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<Bokning> GetBokningAsync(int id)
        {
            try
            {
                return await _context.Bokning.FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<Bokning> UpdateBokningAsync(Bokning bokning)
        {
            try
            {
                _context.Bokning.Update(bokning);
                await _context.SaveChangesAsync();
                return bokning;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }
    }
}
