
namespace Demo.DAL.Reposatories
{
    public interface IDepartmentRepository
    {
        int Add(Department department);
        IEnumerable<Department> Getall(bool withTracking = false);
        Department? GetById(int id);
        int Remove(Department department);
        int Update(Department department);
    }
}