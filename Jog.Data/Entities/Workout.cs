using System;
using System.ComponentModel.DataAnnotations;

namespace Jog.Data
{
    public class Workout : BaseEntity
    {
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        
        [Required]
        [Display(Name = "Distance")]
        public int Distance { get; set; }
    }
}