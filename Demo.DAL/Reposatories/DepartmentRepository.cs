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

    public class DepartmentRepository(ApplicationDbContext _context) : IDepartmentRepository
    // High Level Model
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
        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }
        //UPDATE DEPRATMENT
        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }
        // Delete Department
        public int Remove(Department department)
        {
            _context.Departments.Remove(department);
            return _context.SaveChanges();

        }
        //Assign new Manager For Depramtnet



    }
}

