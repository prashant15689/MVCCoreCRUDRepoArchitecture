using MVCCRUD.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVCCRUD.Models.ViewModels
{
    public class EmployeeVM
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Email can not be empty!")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Department can not be empty!")]
        public Departments Departments { get; set; }
    }
}
