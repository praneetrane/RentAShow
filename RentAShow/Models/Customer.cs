using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentAShow.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MemberShipType MemberShipType { get; set; }
    }
}