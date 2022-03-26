using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommerceDemo.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(10)]
        public string InvoiceSerialNumber { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string InvoiceOrderNumber { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxAdministration { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Submitter { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set; }
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Hour { get; set; }

        public decimal Total { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}