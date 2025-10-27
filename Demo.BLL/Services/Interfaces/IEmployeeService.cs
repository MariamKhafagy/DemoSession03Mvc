using Demo.BLL.DTOs.DepartmentDTOs;
using Demo.BLL.DTOs.EmployessDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetAllEmployess(bool withTracking = false);
        EmployeeDetailsDto? GetEmployeeById(int id);
        int AddEmployee(CreateEmployeeDto employeeDto);
        int UpdateEmployeeDto(UpdateEmployeeDto employeeDto);
        bool DeleteEmployee(int id);
       
        
       
    }
}
