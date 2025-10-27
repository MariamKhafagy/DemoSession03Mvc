using Demo.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeesController(IEmployeeService _employeeService) : Controller
    {
        public IActionResult Index()
        {
            var employee = _employeeService.GetAllEmployess();
            return View(employee);
        }
    }
}
