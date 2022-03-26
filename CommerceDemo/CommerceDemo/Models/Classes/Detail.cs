using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommerceDemo.Models.Classes
{
    public class Detail
    {
        [Key]
        public int DetailId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string productName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string productInformation { get; set; }
       
    }
}