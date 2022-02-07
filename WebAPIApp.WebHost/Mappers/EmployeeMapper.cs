using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIApp.Core.Abstractions.Repositories;
using WebAPIApp.Core.Domain.Administration;
using WebAPIApp.WebHost.Models;

namespace WebAPIApp.WebHost.Mappers
{
    public class EmployeeMapper : IEmployeeMapper
    {
        private readonly IRepository<Role> _rolesRepository;

        public EmployeeMapper(IRepository<Role> rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public async Task<Employee> MapFromModelAsync(CreateOrEditEmployeeRequest model, Employee employee = null)
        {
            if (employee == null)
            {
                employee = new Employee();
                employee.Id = Guid.NewGuid();
            }

            var roles = await _rolesRepository.GetByCondition(x =>
                ((IList)model.RoleNames).Contains(x.Name)) as List<Role>;

            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.AppliedPromocodesCount = model.AppliedPromocodesCount;
            employee.Email = model.Email;
            employee.Roles = roles;

            return employee;
        }
    }
}
