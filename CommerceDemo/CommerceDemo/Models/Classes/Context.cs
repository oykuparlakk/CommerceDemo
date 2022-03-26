using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CommerceDemo.Models.Classes
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Outgoing> Outgoings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<SalesMove> SalesMoves { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
    }
}