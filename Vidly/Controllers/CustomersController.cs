using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentAShow.Models;

namespace RentAShow.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer>
            {

            };
        // GET: /Customers/
        [Route("Customers/CustomerList")]
        public ActionResult CustomerList()
        {

            var customerList = GetAllCustomers();
            
            return View(customerList);
        }

        public ActionResult Details(int id)
        {
            Customer customer = GetAllCustomers().Where(x => x.Id == id).FirstOrDefault();

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        private IEnumerable<Customer> GetAllCustomers()
        {
            try
            {
                return new List<Customer>{
                    new Customer{Id=1, Name="Mike"},
                    new Customer{Id=2,Name="Jonathan"}
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting customer details: " + ex.Message);
            }
        }
    }
}