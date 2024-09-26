using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Lc_userapi.Models
{
    public class userClass
    {

        [Key]
        public int userId { get; set; }

        [Required]
        [StringLength(50)]
        public string? firstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? lastName { get; set; }


        [Required]
        public string? Email { get; set; }

        [Required]
      
        public DateTime dob { get; set; }

        [Required]
        [StringLength(30)]
        public string ? gender { get; set; }

        [Required]
        [StringLength(30)]
        public string? place { get; set; }

    }
}
