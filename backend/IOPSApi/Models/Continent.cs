using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace IOPSApi.Models
{
    public class Continent
    {
        [Key]
        [MinLength(1)]
        public string ContinentID { get; set; }

        public ICollection<Country> countries { get; set; }
    }
}
