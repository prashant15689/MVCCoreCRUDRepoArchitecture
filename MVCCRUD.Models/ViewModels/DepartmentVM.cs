using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVCCRUD.Models.ViewModels
{
    public class DepartmentVM
    {
        public string DepartmentName { get; set; }

        public string Description { get; set; }
    }
}
