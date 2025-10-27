using Demo.BLL.DTOs.DepartmentDTOs;

namespace Demo.BLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto? GetById(int id);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);
    }
}