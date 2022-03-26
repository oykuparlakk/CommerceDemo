using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommerceDemo.Models.Classes
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Display(Name ="Employee Name Surname")]
        public string EmployeeName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(70)]
        public string Email { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [Display(Name = "Employee Image")]
        public string EmployeeImage { get; set; }
        public ICollection<SalesMove> SalesMoves { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}