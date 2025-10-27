using AutoMapper;
using Demo.BLL.DTOs.EmployessDTOs;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Reposatories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.Classes
{
    public class EmployeeService(IEmployeeReposirtory _employeeRepository,Mapper _mapper) : IEmployeeService
    {
        public IEnumerable<EmployeeDTO> GetAllEmployess(bool withTracking = false)
        {
            var employees = _employeeRepository.Getall();
            //                 Manual Mapping
            //var employeesDto= employees.Select(emp=>new EmployeeDTO()
            //    { 
            //      Id = emp.Id,
            //      Name = emp.Name,
            //      Age = emp.Age,
            //      Email = emp.Email,
            //      EmployeeType=emp.EmployeeType.ToString(),
            //      Gender=emp.Gender.ToString(),
            //      IsActive=emp.IsActive,
            //      Salary=emp.Salary,


            //     });

            //        Auto Mapping                            
            //                            Destination               Sourse              //From the Sourse object to the Destinstion object
            var employeesDto = _employeeRepository.Getall(); //here i need to inject the Mapper 
            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(employees);
        }


        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee= _employeeRepository.GetById(id);
            return employee is null ? null :  _mapper.Map<EmployeeDetailsDto>(employee); //Auto Maping will do everything Underbenith

            //             Manual Mapping

            // var employeeDto = new EmployeeDetailsDto()
            // {
            //Id = employee.Id,
            //Name = employee.Name,
            //Age= employee.Age,
            //Gender= employee.Gender.ToString(),
            //Email= employee.Email,
            //EmployeeType=employee.EmployeeType.ToString(),  
            //IsActive = employee.IsActive,
            //Salary= employee.Salary,
            //PhoneNumber= employee.PhoneNumber,
            //CreatedBy= employee.CreatedBy,
            //CreatedOn= employee.CreatedOn,
            //HiringDate=DateOnly.FromDateTime(employee.HiringDate),
            //LastModifiedBy= employee.LastModifiedBy,
            //LastModifiedOn= employee.LastModifiedOn,







            // };




        }

        public int AddEmployee(CreateEmployeeDto employeeDto)
        {
            var employee=_mapper.Map<Employee>(employeeDto);
            return _employeeRepository.Add(employee);
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is null) return false;
            else
            { 
             employee.IsDeleted = true;
                return _employeeRepository.Update(employee) > 0 ? true : false;
            
            }
           
        }

        public int UpdateEmployeeDto(UpdateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return _employeeRepository.Update(employee);
        }
    }
}
