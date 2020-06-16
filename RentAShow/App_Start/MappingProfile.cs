using AutoMapper;
using RentAShow.DTOs;
using RentAShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentAShow.App_Start
{
    //Added for 68| Automapper
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
            
        }
    }
}