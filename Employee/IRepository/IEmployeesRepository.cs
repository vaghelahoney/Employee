using Employee.Model;

namespace Employee.IRepository
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employees>> GetAllAsync();
        Task<Employees?> GetByIdAsync(int id);
        Task<Employees> AddAsync(Employees product);
        Task <bool> UpdateAsync(Employees product);
        Task<bool> DeleteAsync(int id);

        Task<bool> UniqProductCode(string productCode ,int id);

        
    }
}
