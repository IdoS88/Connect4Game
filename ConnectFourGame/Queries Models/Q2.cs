using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientModels.Queries_Models
{
    public class Q2
    {
        [Key]
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public string DateInit { get; set; }= string.Empty;
    }
}
