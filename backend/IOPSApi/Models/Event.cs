using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace IOPSApi.Models
{
    public class Event
    {
        public int EventID { get; set; }
		[Required]
		public string Title { get; set; }
        public string ImageURL { get; set; }
        [Required]
        public string Descriptions { get; set; }
        public string CountryID { get; set; }

<<<<<<< HEAD
        public DateTime? DateEvent { get; set; }
=======
        public DateTime Date { get; set; } = new DateTime();
>>>>>>> 4b0389fc64b3e261991c0b67f54501c498a5157b

}
}
