using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Reposatories.Interfaces
{
    public interface IEmployeeReposirtory:IGenericRepository<Employee>
    {
        
    }
}
