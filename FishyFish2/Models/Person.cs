using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishyFish2.Models
{
    public class Person : IdentityUser
    {
        public Person()
        {
            this.Catches = new HashSet<Catch>();
            this.Memberships = new HashSet<Membership>();
        }

        [Key]
        public int PersonId { get; set; }
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public virtual string Email { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public System.DateTime Dob { get; set; }
        public string TshirtSize { get; set; }
        public string Affiliation { get; set; }
        public string PaymentMethod { get; set; }
        public bool? PaymentReceived { get; set; }
        public bool? WaiverReceived { get; set; }
        public System.DateTime SignupDate { get; set; }
        public bool? Active { get; set; }
        override public string UserName { get; set; }

        public virtual ICollection<Catch> Catches { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}