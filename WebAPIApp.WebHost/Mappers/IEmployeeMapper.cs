using System.Threading.Tasks;
using WebAPIApp.Core.Domain.Administration;
using WebAPIApp.WebHost.Models;

namespace WebAPIApp.WebHost.Mappers
{
    public interface IEmployeeMapper
    {
        Task<Employee> MapFromModelAsync(CreateOrEditEmployeeRequest model,
            Employee employee = null);
    }
}
