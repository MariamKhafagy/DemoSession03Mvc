using Demo.BLL.DTOs;
using Demo.BLL.Services;
using Demo.PL.ViewModels.DepartmentViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    //(IDepartmentService _departmentService)
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<HomeController> _logger;

        public DepartmentController(IDepartmentService departmentService ,
                                     ILogger<HomeController> logger,
                                     IWebHostEnvironment environment)
        {
           _departmentService = departmentService;
            _environment = environment;
            _logger = logger;
        }

        //Get BaseUrl/Departmetns/Index
        [HttpGet]
        public IActionResult Index() 
        { 
            var departments=_departmentService.GetAllDepartments();

            return View(departments);
 
        }

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int res = _departmentService.AddDepartment(departmentDto);
                    if (res > 0) return RedirectToAction(nameof(Index));//xxxxx
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can't Be Added");
                        return View(departmentDto);
                    }
                }
                catch (Exception ex)
                {
                    //log Exception

                    if (_environment.IsDevelopment())
                    {
                        //1) Development => log Error In Console And Retunr the Same View With The Error Message (From the Heart of the Exception) 

                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(departmentDto);
                    }
                    else 
                    {
                        //2) Development => log Error In File | Table And Retunr the Same View With The Error Message  
                       // _logger.LogError(ex.Message);
                        return View(departmentDto);
                    }


                }

            }
            else return View(departmentDto);

        }
        #endregion

        #region Details 

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest(); //400
            var department = _departmentService.GetById(id.Value);

            if (department is null) return NotFound();//404

            return View(department);
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int ?id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetById(id.Value); 
            //Detailed Department Dto 

            if (department is null) return NotFound();




            var deptViewModel = new DepartmentEditViewModel()
            {
            
                Name = department.Name,
                Code = department.Code,
                DateOfCreation = department.DateOfCreation,
                Description = department.Description
            };
            return View(deptViewModel); //Wait For Department Edit View Model

            
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id, DepartmentEditViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            try
            {
                var updateDepDto = new UpdatedDepartmentDto()
                {
                    Id=id,
                    Code = viewModel.Code,
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    DateOfCreation = viewModel.DateOfCreation
                };
                var res = _departmentService.UpdateDepartment(updateDepDto);
                if (res > 0) return RedirectToAction(nameof(Index));
                return View(viewModel);
            }
            catch (Exception ex)
            {

                //log Exception

                if (_environment.IsDevelopment())
                {
                    //1) Development => log Error In Console And Retunr the Same View With The Error Message (From the Heart of the Exception) 

                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(viewModel);
                }
                else
                {
                    //2) Development => log Error In File | Table And Retunr the Same View With The Error Message  
                    // _logger.LogError(ex.Message);
                    return View(viewModel);
                }
            }
        }
        #endregion

        #region Delete

        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{ 
        // if(!id.HasValue) return BadRequest();
        //    var dept = _departmentService.GetById(id.Value);


        //    if (dept is null) return NotFound();

        //    return View(dept);
        //}



        [HttpPost]
        public IActionResult Delete(int id )
        {
            if (id == 0) return BadRequest();
            try
            {
                bool isDeleted = _departmentService.DeleteDepartment(id);
                if (isDeleted)
                    return RedirectToAction(nameof(Index));
                else ModelState.AddModelError(string.Empty, "Department Can't Be Deleted");
                return RedirectToAction(nameof(Delete),new {id});
            }
            catch(Exception ex)
            {

                //log Exception

                if (_environment.IsDevelopment())
                {
                    //1) Development => log Error In Console And Retunr the Same View With The Error Message (From the Heart of the Exception) 

                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //2) Development => log Error In File | Table And Retunr the Same View With The Error Message  
                    // _logger.LogError(ex.Message);
                    return View("ErrorView",ex);
                }
            }

           
           
        

        }

        #endregion
    }
}

 