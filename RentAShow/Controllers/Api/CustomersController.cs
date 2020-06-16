using AutoMapper;
using RentAShow.DTOs;
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

    //Added CustomerDTO and mapped using Automapper 68| Automapper
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }
        //Get Api/customers
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _dbContext.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }

        //Get Api/customers/1

        public CustomerDTO GetCustomer(int ID)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == ID);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Customer,CustomerDTO>(customer) ;
        }

        //POST Api/customers
        [HttpPost]
        public CustomerDTO CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            customerDTO.Id = customer.Id;
            return customerDTO;
        }

        //PUT Api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                      throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
           

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDTO, customerInDB);

            //----Not Required since we used Automapper
            //customerInDB.Name = customer.Name;
            //customerInDB.BirthDate = customer.BirthDate;
            //customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //customerInDB.MembershipTypeId = customer.MembershipTypeId;

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
