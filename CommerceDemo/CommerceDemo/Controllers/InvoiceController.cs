using CommerceDemo.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceDemo.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context _context = new Context();
        public ActionResult Index()
        {
            var invoiceList = _context.Invoices.ToList();
            return View(invoiceList);
        }
        [HttpGet]
        public ActionResult Add_Invoice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_Invoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update_Invoince(int id)
        {
            var invoince = _context.Invoices.Find(id);
            return View("Update_Invoince", invoince);
        }

        public ActionResult Update_Post_Invoince(Invoice invoice)
        {
            var _invoice = _context.Invoices.Find(invoice.Id);
            _invoice.InvoiceOrderNumber = invoice.InvoiceOrderNumber;
            _invoice.InvoiceSerialNumber = invoice.InvoiceSerialNumber;
            _invoice.Receiver = invoice.Receiver;
            _invoice.Submitter = invoice.Submitter;
            _invoice.TaxAdministration = invoice.TaxAdministration;
            _invoice.Date = invoice.Date;
            _invoice.Hour = invoice.Hour;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Detail_Invoice(int id)
        {
            List<InvoiceItem> result = _context.InvoiceItems
                                          .Where(x => x.InvoiceId == id)
                                          .ToList();

            return View(result);
        }
        [HttpGet]
        public ActionResult Add_InvoiceItems()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_InvoiceItems(InvoiceItem invoiceItem)
        {
            _context.InvoiceItems.Add(invoiceItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}