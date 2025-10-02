using Demo.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Reposatories
{
    //Primry Constructor .Net9 Feature

    public class DepartmentRepository(ApplicationDbContext context) // High Level Model
    {



        //CRUD
        //Get Department ID

        // ApplicationDbContext context = new ApplicationDbContext(); //Low Level Model so i cannot use it when i use High Level  Model



        private readonly ApplicationDbContext _context = context; //Null

        public Department? GetById(int id)
        { 
         var department = _context.Departments.Find(id);
            return department;
        }
        //Get  ALL DepartmentS 
        //ADD Department
        //UPDATE DEPRATMENT
        // Delete Department
        //Assign new Manager For Depramtnet
     



    }
}
