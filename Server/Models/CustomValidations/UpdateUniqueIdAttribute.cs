using System.ComponentModel.DataAnnotations;
using IdoShamir_EyalCohen_Connect4.Data;
using Models.Models;

namespace IdoShamir_EyalCohen_Connect4.Models.CustomValidations
{
    public class UpdateUniqueIdAttribute : ValidationAttribute
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



            Player? _player = _context.Player.Find(value);

            if (_player == null)
                return new ValidationResult("Value Isn't Found!");

            IList<Player>? PlayersTable = _context.Player.ToList();

            PlayersTable.Remove(_player);


            if (value == null)
            {
                return new ValidationResult("Value Isn't in valid Format!");
            }

            // Check the database for the existence of the ID
            else if (PlayersTable.Any(item => item.Id == (int)value))
            {
                return new ValidationResult(GetErrorMessage());
            }
            else
                return ValidationResult.Success!;
        }
    }
}

