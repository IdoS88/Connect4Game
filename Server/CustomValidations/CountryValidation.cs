using System.ComponentModel.DataAnnotations;

namespace IdoShamir_EyalCohen_Connect4.CustomValidations
{

    /// <summary>
    /// not sure if i need this class
    /// </summary>
    public class CountryAttribute : ValidationAttribute
    {

        public string GetErrorMessage() =>
            $"This specific ID already been selected by other player.";

        //protected override ValidationResult IsValid(
        //    object? value, ValidationContext validationContext)
        //{
        //}
    }
}
