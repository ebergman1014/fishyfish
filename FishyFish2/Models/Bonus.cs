using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishyFish2.Models
{
    public class Bonus
    {
        [Key]
        public int BonusId { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Comment { get; set; }
    
        public virtual Team Team { get; set; }
    }
}