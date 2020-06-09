using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentAShow.Models;
using System.Data.Entity;
using RentAShow.ViewModels;

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

        public ActionResult New()
        {
            var memberShipTypes = _context.MemberShipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                Customer= new Customer(),
                MemberShipTypes = memberShipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if (customer.Id==0)
            _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDB.Name = customer.Name;
                customerInDB.BirthDate = customer.BirthDate;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            _context.SaveChanges();

            return RedirectToAction("CustomerList", "Customers");
        }

        // GET: /Customers/
        [Route("Customers/CustomerList")]
        public ActionResult CustomerList()
        {

            //var customerList = GetAllCustomers();
            // var customerList = _context.Customers;

            var customerList = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customerList);
        }

        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }
            
    }
}
