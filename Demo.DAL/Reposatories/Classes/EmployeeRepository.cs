using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Reposatories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Reposatories.Classes
{
  public class EmployeeRepository(ApplicationDbContext _context) 
                                   : GenericRepository<Employee>(_context),IEmployeeReposirtory
        //High Level Model
    {

        //CRUD
        //Get Employee ID



    }
}
