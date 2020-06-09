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

        //--Start Section 3 | Exercise 1- Add membership type to list of customers.
        [Required(ErrorMessage="Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }
        //--End

        public bool IsSubscribedToNewsletter { get; set; }
       
        public MemberShipType MemberShipType { get; set; }
       
        [Display(Name="Membership Type")]

        public byte MembershipTypeId { get; set; }
       
        //--Start Section 3 | Exercise 2- Add Birthday to the Customer.
        [Display(Name="Date of Birth")]
       [Min18YrsIfMember]
        public DateTime? BirthDate { get; set; }
        //--End 
    }
}