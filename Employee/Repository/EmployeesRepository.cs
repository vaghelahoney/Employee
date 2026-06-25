using Employee.IRepository;
using Employee.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly AppDbContext _context;

        public EmployeesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Employees.FindAsync(id);
            if (product != null)
            {
                _context.Employees.Remove(product);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<IEnumerable<Employees>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employees?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Employees employees)
        {
            _context.Employees.Update(employees);
            await _context.SaveChangesAsync();

            return true;
        }

       public async Task<Employees> AddAsync(Employees employees)
        {
            try
            {

                await _context.Employees.AddAsync(employees);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            

            return employees;
        }

            
        public async Task<bool> UniqProductCode(string productCode ,int id)
        {
            return await _context.Employees.AnyAsync(e => e.ProductCode == productCode && e.Id != id);
        }
    }
}
