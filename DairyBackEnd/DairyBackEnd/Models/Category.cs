using System.ComponentModel.DataAnnotations;

namespace DiaryBackEnd.Models
{
    public class Category
    {
        [Key]

        public int cid { get; set; }
        public string? category { get; set; }
        public int uid { get; set; }
    }
}
