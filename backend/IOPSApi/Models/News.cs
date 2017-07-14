using System.ComponentModel.DataAnnotations;
using System;
namespace IOPSApi.Models
{
    public class News
    { 
        [Key]
        public int NewsID { get; set; }
		[Required]
		public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }
        public string PhotoURL { get; set; }
        public DateTime? DatePub { get; set; }
    } 
}
