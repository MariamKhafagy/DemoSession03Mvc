using Demo.BLL.DTOs;
using Demo.BLL.Factories;
using Demo.DAL.Data.Contexts;
using Demo.DAL.Models;
using Demo.DAL.Reposatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {

        //GEt All Departments 
        //Data Transfer Object the Location of that in the BLL
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var depts = _departmentRepository.Getall();
            var departmentsToReturn = depts.Select(d => d.ToDepartmentDto());//Extention Method
            return departmentsToReturn; // there will be an error here it says cannot implicity convert type DepartmentDTo  so  in need to Do (Mapping)
        }


        public DepartmentDetailsDto? GetById(int id)
        {
            var dept = _departmentRepository.GetById(id);
            //    if (dept is null) return null;
            //    else
            //    {
            //        var deptToreturn = new DepartmentDetailsDto()
            //        {
            //            Id=dept.Id,
            //            Code=dept.Code,
            //            Name=dept.Name,
            //            CreatedBy=dept.CreatedBy,
            //            LastModifiedBy=dept.LastModifiedBy,
            //            IsDeleted=dept.IsDeleted,
            //            DateOfCreation=DateOnly.FromDateTime(dept.CreatedOn),
            //            LastModifiedOn=DateOnly.FromDateTime(dept.LastModifiedOn),




            //        };

            //        return deptToreturn;
            //    }


            //Manual Mapping
            //-Constructor Mapping
            //-Extention Method

            //AutoMapper

            //return dept is null ? null : new DepartmentDetailsDto()
            //{

            //    Id = dept.Id,
            //    Code = dept.Code,
            //    Name = dept.Name,
            //    CreatedBy = dept.CreatedBy,
            //    LastModifiedBy = dept.LastModifiedBy,
            //    IsDeleted = dept.IsDeleted,
            //    DateOfCreation = DateOnly.FromDateTime(dept.CreatedOn),
            //    LastModifiedOn = DateOnly.FromDateTime(dept.LastModifiedOn),






            //};

            //return dept is null ? null : new DepartmentDetailsDto(dept); //Constructor Mapping
            return dept is null ? null : dept.ToDepartmentDetailsDto(); //Extention MEthod Mapping


        }

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var entity = departmentDto.ToEntity();
            return _departmentRepository.Add(entity);
        }

        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var entity = departmentDto.ToEntity();
            return _departmentRepository.Update(entity);
        }

        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);

            if (department is null) return false;
            else
            {
                var res = _departmentRepository.Remove(department);
                return res > 0 ? true : false;

            }
        }

    }
}
