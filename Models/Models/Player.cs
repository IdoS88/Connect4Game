namespace Models.Models
{
    public sealed record Player
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? CountrySelection { get; set; }
    }
}
