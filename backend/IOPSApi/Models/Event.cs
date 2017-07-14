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

        public DateTime? DateEvent { get; set; }
}
}
