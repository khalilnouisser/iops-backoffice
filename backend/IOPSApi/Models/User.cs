using System;
using System.ComponentModel.DataAnnotations;
namespace IOPSApi.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Fname { get; set; }
		[Required]
		public string Lname { get; set; }
		[Required]
		[EmailAddress]
		public string EmailAdress { get; set; }
		[Required] 
		public string Password { get; set; }
		public DateTime DateCreation { get; set; } = new DateTime();
		[Url]
        public string ProfilePic { get; set; }
	}  
}
 