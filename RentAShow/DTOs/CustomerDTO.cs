using RentAShow.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentAShow.DTOs
{
    //Added for 67| Data Transfer Object (DTO)
    public class CustomerDTO
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MemberShipType MemberShipType { get; set; }

        [Min18YrsIfMember]
        public DateTime? BirthDate { get; set; }
    }
}