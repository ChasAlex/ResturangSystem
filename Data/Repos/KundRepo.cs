using Microsoft.EntityFrameworkCore;
using ResturangSystem.Data.Repos.IRepos;
using ResturangSystem.Models;

namespace ResturangSystem.Data.Repos
{
    public class KundRepo : IKundRepo
    {

        private readonly ResturangContext _context;

        public KundRepo(ResturangContext context)
        {
            _context = context; 
        }



        public async Task<Kund> CreateKundAsync(Kund kund)
        {
            try
            {
                await _context.Kund.AddAsync(kund);
                await _context.SaveChangesAsync();
                return kund;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error - " +e);
                return null;
            }
        }

        public async Task<Kund> DeleteKundAsync(int id)
        {

            try
            {
                var userToDelete = await _context.Kund.FindAsync(id);
                if (userToDelete != null)
                {
                    _context.Kund.Remove(userToDelete);
                    await _context.SaveChangesAsync();
                    return userToDelete;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
            
        }

        public async Task<Kund> GetKundAsync(int id)
        {
            try
            {
                return await _context.Kund.FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
            
        }

        public async Task<IEnumerable<Kund>> GetKunderAsync()
        {
            try
            {
                return await _context.Kund.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }
            
        }

        public async Task<Kund> UpdateKundAsync(Kund kund)
        {
            try
            {
                _context.Kund.Update(kund);
                await _context.SaveChangesAsync();
                return kund;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error - " + e);
                return null;
            }

            
        }
    }
}
