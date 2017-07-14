using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IOPSApi.Models
{
    public class Country
    {
        [Key]
        public string CountryID { get; set; }
         
        public string Name { get; set; }
        [Url]
        [Required]
        public string SiteURL { get; set; } 

        public string Description { get; set; }

		public string ResponsableName { get; set; }

		public Continent Continent { get; set; }

		[Required]
		public string ContinentID { get; set; }

		public ICollection<Inscription> Inscriptions { get; set; }
    }

} 
