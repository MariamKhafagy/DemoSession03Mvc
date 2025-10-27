using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Reposatories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Reposatories.Classes
{
    //Primry Constructor .Net9 Feature

    public class DepartmentRepository(ApplicationDbContext _context) 
                                      :GenericRepository<Department>(_context), IDepartmentRepository
    // High Level Model
    {

        //CRUD
        //Get Department ID
     
      
       

    }
}

