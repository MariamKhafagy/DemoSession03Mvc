using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTOs.DepartmentDTOs
{
    public class CreatedDepartmentDto
    {
        [MaxLength(10)]
        public string Name  { get; set; }
        public string  Code { get; set; }

        [Display(Name ="DateOfCreation")]
        public DateOnly DateOfCreation { get; set; }

        public string? Description { get; set; } 
    }
}
