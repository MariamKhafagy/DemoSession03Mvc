using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.Shared;
using Demo.DAL.Reposatories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Reposatories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext _context) : IGenericRepository<TEntity> where TEntity: BaseEntity
    {
        public TEntity? GetById(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            return entity;
        }
        //Get  ALL DepartmentS
        //

        public IEnumerable<TEntity> Getall(bool withTracking = false)
        {
            if (withTracking) return _context.Set<TEntity>().ToList();
            else return _context.Set<TEntity>().AsNoTracking().ToList();
        }
        //ADD Department
        public int Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges();
        }
        //UPDATE DEPRATMENT
        public int Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return _context.SaveChanges();
        }
        // Delete Department
        public int Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges();

        }
        //Assign new Manager For Depramtnet


    }
}
