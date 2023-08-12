
using IdoShamir_EyalCohen_Connect4.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace IdoShamir_EyalCohen_Connect4.UI
{

    public class NewPlayerRegister
    {
        [Display(Name = "Player ID")]
        [UniqueId]
        [Range(1, short.MaxValue, ErrorMessage = "The field must be at least 1 and unique from other players")]
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

        public string CountrySelection { get; set; } = string.Empty;

        /*     public string Password { get; set; } // TOD?/O: Hash this
             public string ConfirmPassword { get; set; }

        */


    }
    public enum Country
    {
        Israel,
        USA,
        England,
        France,
        Germany,
        Spain,
        Italy,
        Russia,
        China,
        Japan,
        Australia,
        Canada,
        Mexico,
        Brazil,
    }
}
