using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.netCoreMVCCRUD.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Column(TypeName = "nvarchar(250")]
        [Required]
        public String FullName { get; set; }
        [Column(TypeName = "varchar(10")]
        public string EmpCode { get; set; }
        [Column(TypeName = "varchar(100")]
        public string Position { get; set; }
        [Column(TypeName = "varchar(100")]
        public string OfficeLocation { get; set; }

    }
}
