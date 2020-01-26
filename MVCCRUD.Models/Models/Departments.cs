using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCCRUD.Models.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentId { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string DepartmentName { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        public string Description { get; set; }        

        [Column(TypeName = "DATETIME")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
