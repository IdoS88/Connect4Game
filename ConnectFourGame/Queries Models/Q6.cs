using System.ComponentModel.DataAnnotations;

namespace ClientModels.Queries_Models
{
    public class Q6
    {
        [Key]
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = string.Empty;

        public int GamesCount { get; set; }
    }
}
