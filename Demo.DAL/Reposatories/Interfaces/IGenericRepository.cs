using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Reposatories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity:BaseEntity 
    {
        int Add(TEntity entity);
        IEnumerable<TEntity> Getall(bool withTracking = false);
        TEntity? GetById(int id);
        int Remove(TEntity entity);
        int Update(TEntity entity);
    }
}
