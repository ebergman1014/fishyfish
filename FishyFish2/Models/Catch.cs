using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishyFish2.Models
{
    public class Catch
    {
        [Key]
        public int CatchId { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public double Inches { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public System.DateTime DateSubmitted { get; set; }
        [Required]
        public byte[] Photo1 { get; set; }
        [Required]
        public byte[] Photo2 { get; set; }
        [Required]
        public bool? Verified { get; set; }
        [Required]
        public System.DateTime? DateVerified { get; set; }
        [Required]
        public bool? Posted { get; set; }
        [Required]
        public string Species { get; set; }

        public virtual Person Person { get; set; }
    }
}