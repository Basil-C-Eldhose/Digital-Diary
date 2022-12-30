using System.ComponentModel.DataAnnotations;

namespace DiaryBackEnd.Models
{
    public class Profile
    {
        [Key]

        public int pid { get; set; }

        public int uid { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? dob { get; set; }
        public string? phno { get; set; }
        public string? address { get; set; }
        public string? pin { get; set; }
        public string? idno { get; set; }
        public string? dlno { get; set; }
        public string? email { get; set; }
        public string? education { get; set; }
        public string? passno { get; set; }
        public string? bano { get; set; }
        public string? country { get; set; }
        public string? state { get; set; }

    }
}
