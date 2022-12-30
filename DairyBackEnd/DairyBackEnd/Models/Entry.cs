using System.ComponentModel.DataAnnotations;

namespace DiaryBackEnd.Models
{
    public class Entry
    {
        [Key]

        public int did { get; set; }
        public string? title { get; set; }
        
        public string? date { get; set; }
        public string? description { get; set; }
        public int uid { get; set; }
    }
}
