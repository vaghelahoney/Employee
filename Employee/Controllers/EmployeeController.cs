using Employee.IRepository;
using Employee.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeesRepository _repository;

        public EmployeeController(IEmployeesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]   
        public async Task<IActionResult> GetAll()
        {
            var employees = await _repository.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("CheckCode/{productCode}/{id}")]
        public async Task<IActionResult> GetProductCode([FromRoute] string productCode, [FromRoute] int id)
        {
            var employees = await _repository.UniqProductCode(productCode, id);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]  int id)
        {
            var employees = await _repository.GetByIdAsync(id);
            if (employees == null) return NotFound();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEmployees([FromBody] Employees employee )
        {
            var employees = await _repository.AddAsync(employee);
            if (employees == null) return NotFound();
            return Ok(employees);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployees([FromBody] Employees employee)
        {
            var employees = await _repository.UpdateAsync(employee);
            if (employees == null) return NotFound();
            return Ok(employees);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeltetEmployees([FromRoute] int id)
        {
            var employees = await _repository.DeleteAsync(id);
            if (employees == null) return NotFound();
            return Ok(employees);
        }

    }
}
