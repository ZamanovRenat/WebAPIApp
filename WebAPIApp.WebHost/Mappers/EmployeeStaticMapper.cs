using System;
using System.Collections.Generic;
using WebAPIApp.Core.Domain.Administration;
using WebAPIApp.WebHost.Models;

namespace WebAPIApp.WebHost.Mappers
{
    public class EmployeeStaticMapper
    {
        public static Employee MapFromModel(CreateOrEditEmployeeRequest model, List<Role> roles,
            Employee employee = null)
        {
            if (employee == null)
            {
                employee = new Employee();
                employee.Id = Guid.NewGuid();
            }

            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.AppliedPromocodesCount = model.AppliedPromocodesCount;
            employee.Email = model.Email;
            employee.Roles = roles;

            return employee;
        }
    }
}
