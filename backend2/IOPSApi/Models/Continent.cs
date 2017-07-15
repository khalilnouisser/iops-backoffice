using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace IOPSApi.Models
{
    public class Continent
    {
        [Key]
        public string ContinentID { get; set; }

        public ICollection<Country> countries { get; set; }
    }
}
