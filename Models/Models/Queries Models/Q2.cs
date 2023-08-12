using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models.Queries_Models
{
    public class Q2
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public string? DateInit { get; set; }
    }
}
