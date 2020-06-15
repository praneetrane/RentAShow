using RentAShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RentAShow.Controllers.Api
{
    //Added during- 65 | Building an API
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }
        //Get Api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        //Get Api/customers/1

        public Customer GetCustomer(int ID)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == ID);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }

        //POST Api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return customer;
        }

        //PUT Api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                      throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDB.Name = customer.Name;
            customerInDB.BirthDate = customer.BirthDate;
            customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDB.MembershipTypeId = customer.MembershipTypeId;

            _dbContext.SaveChanges();
        }

        //DELETE Api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Customers.Remove(customerInDB);
            _dbContext.SaveChanges();
        }

    }
}
