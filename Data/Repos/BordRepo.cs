using Microsoft.EntityFrameworkCore;
using ResturangSystem.Data.Repos.IRepos;
using ResturangSystem.Models;
using ResturangSystem.Models.DTO;

namespace ResturangSystem.Data.Repos
{
    public class BordRepo : IBordRepo
    {
        private readonly ResturangContext _context;

        public BordRepo(ResturangContext context)
        {
            _context = context;
        }


        public async Task<Bord> CreateBordAsync(Bord bord)
        {
            try
            {
                await _context.Bord.AddAsync(bord);
                await _context.SaveChangesAsync();
                return bord;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<Bord> DeleteBordAsync(int id)
        {
            try
            {
                var BordToDelete = await _context.Bord.FindAsync(id);
                if (BordToDelete != null)
                {
                    _context.Bord.Remove(BordToDelete);
                    await _context.SaveChangesAsync();
                    return BordToDelete;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<IEnumerable<Bord>> GetAllBordAsync()
        {
            try
            {
                return await _context.Bord.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<List<Bord>> GetAvailableTablesAsync(AvailableTableDTO dto)
        {
            try
            {
                return await _context.Bord
            .Where(b => b.Platser >= dto.Antal
                        && b.BoolBokad == false
                        && b.Bokningar.All(bokning => bokning.Datum != dto.datum))
            .ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return new List<Bord>();
            }
        }

        public async Task<Bord> GetBordAsync(int id)
        {
            try
            {
                return await _context.Bord.FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }

        public async Task<Bord> UpdateBordAsync(Bord bord)
        {
            try
            {
                _context.Bord.Update(bord);
                await _context.SaveChangesAsync();
                return bord;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
        }
    }
}
