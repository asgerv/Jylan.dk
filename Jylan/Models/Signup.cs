using System.ComponentModel.DataAnnotations;

namespace Jylan.Models
{
    public class Signup
    {
        public int SignupId { get; set; }

        [Required(ErrorMessage = "Feltet '{0}' er påkrævet.")]
        [Display(Name = "Email Adresse")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Nickname")]
        public string Nick { get; set; }

        [Required(ErrorMessage = "Feltet '{0}' er påkrævet.")]
        [Display(Name = "Fornavn")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Feltet '{0}' er påkrævet.")]
        [Display(Name = "Efternavn")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Feltet '{0}' er påkrævet.")]
        [Display(Name = "Telefon nr.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Har betalt")]
        [UIHint("BooleanButtonLabel")]
        public bool HasPayed { get; set; }
    }
}