using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace IOPSApi.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Messages
    {
        [Key]
        public int MessageID { get; set; }
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(9000)]
        public string Text { get; set; }
		[Required]
		[MinLength(2)]
        public string Name { get; set; }

<<<<<<< HEAD
		public DateTime? DateMessage { get; set; }
=======
		public DateTime Date { get; set; } = new DateTime();
>>>>>>> 4b0389fc64b3e261991c0b67f54501c498a5157b


		public string CountryID { get; set; }  
	} 
}
