using System.ComponentModel.DataAnnotations;

namespace DiaryBackEnd.Models
{
    public class Todo
    {
        [Key]
        public int tid { get; set; }
        public int uid { get; set; }
        public string? task { get; set; }
        public string? status { get; set; }
    }
}
