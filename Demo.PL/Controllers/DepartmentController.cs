using Demo.BLL;

namespace Demo.PL.Controllers
{
    public class DepartmentController
    {
        //DepartmentService departmentService Used Acros All Actions
        // EmployeeService --> Assign Manager : This Service Needed Only For Ine Action 
        public DepartmentController(DepartmentService departmentService) //Call Service Department Service
        {

        
        }//Ask Clr To Create object From DepartmentService


    }
}
