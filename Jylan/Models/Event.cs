using System;
using System.ComponentModel.DataAnnotations;

namespace Jylan.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Navn")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Start tidspunkt")]
        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }

        [Required]
        [Display(Name = "Slut tidspunkt")]
        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }

        [Required]
        [Display(Name = "Pris")]
        [DataType(DataType.Currency)]
        [Range(0, 999, ErrorMessage = "Ukorrekt pris indtastet. (0-999)")]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Max antal tilmeldinger")]
        [Range(0, 999, ErrorMessage = "Ukorrekt antal indtastet. (0-999)")]
        public int MaxSignups { get; set; }

        //public string CompetitionInfo { get; set; }

        //public List<Signup> Signups { get; set; }
    }
}