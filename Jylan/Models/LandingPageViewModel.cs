using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jylan.Models
{
    public class LandingPageViewModel
    {
        public string Name { get; set; }
        public int MaxSignups { get; set; }

        [UIHint("DateTimeText")]
        public DateTime StartDateTime { get; set; }

        [UIHint("DateTimeText")]
        public DateTime EndDateTime { get; set; }

        public int Price { get; set; }
        public IList<Signup> Signups { get; set; }
    }
}