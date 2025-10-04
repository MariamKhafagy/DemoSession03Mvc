using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService): Controller
    {
        //Get BaseUrl/Departmetns/Index
        [HttpGet]
        public IActionResult Index() 
        { 
            var departments=_departmentService.GetAllDepartments();
            return View(departments);
 
        }
    }
}

 