using System.ComponentModel.DataAnnotations;
using Server.Models.CustomValidations;

namespace Server.Models
{
    public sealed record Player
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string? Phone { get; set; }

        public string? CountrySelection { get; set; }
    }
}
