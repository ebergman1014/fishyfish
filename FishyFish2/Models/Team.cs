using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishyFish2.Models
{
    public class Team
    {
        public Team()
        {
            this.Bonus = new HashSet<Bonus>();
            this.Memberships = new HashSet<Membership>();
        }

        [Key]
        public int TeamId { get; set; }
        [Required]
        [Display(Name = "Team Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }

        public virtual ICollection<Bonus> Bonus { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}