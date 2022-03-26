using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommerceDemo.Models.Classes
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "You can write up to 30 characters.")]
        public string CustomerName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "You can not leave this field blank!")]
        public string Address { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Password { get; set; }
        public bool Status { get; set; }
        public ICollection<SalesMove> SalesMoves { get; set; }
    }
}