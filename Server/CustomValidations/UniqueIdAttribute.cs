using IdoShamir_EyalCohen_Connect4.Data;
using System.ComponentModel.DataAnnotations;

namespace IdoShamir_EyalCohen_Connect4.CustomValidations
{
    public class UniqueIdAttribute : ValidationAttribute
    {
        //private readonly int _id;

        // Initializes a new instance of the ValidationContext class by using the specified object instance and a dictionary of service objects.
        //public UniqueIdAttribute(object instance)
        //{

        //    _id = (int)instance;
        //}

        public string GetErrorMessage() =>

            $"This specific ID already been selected by other player.";

        protected override ValidationResult IsValid(
            object? value, ValidationContext validationContext)
        {
            var _context = (ServerContext)validationContext
                         .GetService(typeof(ServerContext))!;
            if (value == null)
            {
                return new ValidationResult("Value Isn't in valid Format!");
            }
            // Check the database for the existence of the ID
            if (_context.Player.Any(item => item.Id == (int)value))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success!;
        }
    }
}
