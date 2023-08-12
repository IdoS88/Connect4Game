using System.ComponentModel.DataAnnotations;

namespace IdoShamir_EyalCohen_Connect4.UI
{
    public class UpdateUser
    {

        [Display(Name = "Player ID")]
        public int Id { get; set; }

        [Display(Name = "Player Name")]
        [StringLength(60, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "You must enter a phone number!")]
        [DataType(DataType.PhoneNumber)]
        // [RegularExpression(@"^(?:(?:\d{2}|\d{3})-?)?\d{7}$", ErrorMessage = "Invalid Israeli phone number.")]
        [MaxLength(10, ErrorMessage = "Phone number must be 10 digits max")]
        [MinLength(9, ErrorMessage = "Phone number must be 9 digits min")]
        public string? Phone { get; set; }

        public Country CountrySelection { get; set; }

        /*     public string Password { get; set; } // TOD?/O: Hash this
             public string ConfirmPassword { get; set; }

        */
        public void SetCountry(string countrySelection)
        {

            if (!Enum.TryParse(countrySelection, out Country CountrySelection))
            {
                Console.WriteLine("Invalid country selection");
            }
            // Converts the string to an enum
        }


    }
}



