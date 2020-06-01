using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentAShow.Models
{
    public class Customer
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MemberShipType MemberShipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}