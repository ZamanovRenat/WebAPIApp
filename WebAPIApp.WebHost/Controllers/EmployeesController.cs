using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIApp.Core.Abstractions.Repositories;
using WebAPIApp.Core.Domain.Administration;
using WebAPIApp.DataAccess.Data;
using WebAPIApp.DataAccess.Repositories;
using WebAPIApp.WebHost.Mappers;
using WebAPIApp.WebHost.Models;

namespace WebAPIApp.WebHost.Controllers
{
    /// <summary>
    /// Сотрудники
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Role> _rolesRepository;
        private readonly IEmployeeMapper _employeeMapper;

        public EmployeesController(IRepository<Employee> employeeRepository,
            IRepository<Role> rolesRepository, IEmployeeMapper employeeMapper)
        {
            _employeeRepository = employeeRepository;
            _rolesRepository = rolesRepository;
            _employeeMapper = employeeMapper;
        }
        /// <summary>
        /// Получить данные всех сотрудников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<EmployeeShortResponse>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var employeesModelList = employees.Select(x =>
                new EmployeeShortResponse()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FullName = x.FullName,
                }).ToList();

            return employeesModelList;
        }

        /// <summary>
        /// Получить данные сотрудника по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmployeeResponse>> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            var employeeModel = new EmployeeResponse()
            {
                Id = employee.Id,
                Email = employee.Email,
                Roles = employee.Roles.Select(x => new RoleItemResponse()
                {
                    Name = x.Name,
                    Description = x.Description
                }).ToList(),
                FullName = employee.FullName,
                AppliedPromocodesCount = employee.AppliedPromocodesCount
            };

            return employeeModel;
        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync(CreateOrEditEmployeeRequest model)
        {
            var rolesRepository = new InMemoryRepository<Role>(FakeDataFactory.Roles);

            var roles = await rolesRepository.GetByCondition(x =>
                model.RoleNames.Contains(x.Name)) as List<Role>;

            var employee = EmployeeStaticMapper.MapFromModel(model, roles);

            try
            {
                await _employeeRepository.CreateAsync(employee);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return CreatedAtAction(nameof(GetEmployeeByIdAsync), new { id = employee.Id }, null);
        }

        /// <summary>
        /// Изменить сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateEmployeeAsync(Guid id, CreateOrEditEmployeeRequest model)
        {
            Employee employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return BadRequest();
            }
            var roles = await _rolesRepository.GetByCondition(x =>
                model.RoleNames.Contains(x.Name)) as List<Role>;

            employee = EmployeeStaticMapper.MapFromModel(model, roles, employee);

            try
            {
                await _employeeRepository.UpdateAsync(employee);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            Employee toDelete = await _employeeRepository.GetByIdAsync(id);

            if (toDelete == null)
            {
                return NotFound();
            }
            try
            {
                await _employeeRepository.DeleteAsync(toDelete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }
    }
}
