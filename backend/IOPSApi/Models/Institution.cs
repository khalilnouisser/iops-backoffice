using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IOPSBackend.Models
{
    public class Institution
    { 
        [Key]
        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }
        public int zipCode { get; set; }
        public string Adress { get; set; }

        public ICollection<Contestant> Students { get; set; }

        public Country Country { get; set; }
        [Required]
        public string CountryID { get; set; }

    }
}
