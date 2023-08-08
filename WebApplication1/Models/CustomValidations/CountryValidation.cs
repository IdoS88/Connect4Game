using System.ComponentModel.DataAnnotations;

namespace Server.Models.CustomValidations
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
