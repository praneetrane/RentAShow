using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentAShow.Models;
using System.Data.Entity;

namespace RentAShow.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        List<Customer> customers = new List<Customer>
            {

            };
        // GET: /Customers/
        [Route("Customers/CustomerList")]
        public ActionResult CustomerList()
        {

            //var customerList = GetAllCustomers();
            // var customerList = _context.Customers;

            var customerList = _context.Customers.Include(c=>c.MemberShipType).ToList();
            return View(customerList);
        }

        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.Include(c=>c.MemberShipType).SingleOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}