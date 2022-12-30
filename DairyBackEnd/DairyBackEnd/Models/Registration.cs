using System.ComponentModel.DataAnnotations;

namespace DairyBackEnd.Models
{
    public class Registration
    {
        [Key]
        public int uid { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
    }
}
