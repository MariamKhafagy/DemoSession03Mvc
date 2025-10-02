using Demo.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Reposatories
{
    //Primry Constructor .Net9 Feature

    public class DepartmentRepository(ApplicationDbContext _context) // High Level Model
    {



        //CRUD
        //Get Department ID

     




        public Department? GetById(int id)
        { 
         var department = _context.Departments.Find(id);
            return department;
        }
        //Get  ALL DepartmentS
        //

        public IEnumerable<Department> Getall(bool withTracking = false)
        { 
          if (withTracking) return _context.Departments.ToList();
          else return _context.Departments.AsNoTracking().ToList();
        }
        //ADD Department
        //UPDATE DEPRATMENT
        // Delete Department
        //Assign new Manager For Depramtnet
     



    }
}
