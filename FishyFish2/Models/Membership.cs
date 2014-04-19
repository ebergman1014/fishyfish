using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishyFish2.Models
{
    public class Membership
    {
        [Key]
        public int MembershipId { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public bool Captain { get; set; }
        [Required]
        public bool Substitute { get; set; }

        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }
    }
}