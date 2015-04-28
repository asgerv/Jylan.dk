using System.Data.Entity;
using System.Linq;
using Jylan.Models;

namespace Jylan.Extensions
{
    public static class ViewModelTransformationExtensions
    {
        public static LandingPageViewModel ToLandingPageViewModel(this DbSet<Signup> signupTable, Event currentEvent)
        {
            var newModel = new LandingPageViewModel
            {
                Name = currentEvent.Name,
                Signups = signupTable.ToList(),
                StartDateTime = currentEvent.StartDateTime,
                EndDateTime = currentEvent.EndDateTime,
                MaxSignups = currentEvent.MaxSignups,
                Price = currentEvent.Price
            };

            return newModel;
        }
    }
}