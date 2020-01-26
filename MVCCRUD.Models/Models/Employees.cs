using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCCRUD.Models.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        public string FirstName { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        public string LastName { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR(15)")]
        public string Mobile { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        public string Address { get; set; }

        [Column(TypeName = "DATETIME")]
        [DisplayFormat(ApplyFormatInEditMode =true, ConvertEmptyStringToNull =true, DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }        
        public int DepartmentId { get; set; }        
        [ForeignKey("DepartmentId")]
        public virtual Departments Departments { get; set; }        
    }
}
