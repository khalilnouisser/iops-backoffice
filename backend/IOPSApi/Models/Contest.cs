using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace IOPSBackend.Models
{
    public abstract class Contest
    {
        [Required]
        public string NameC { get; set; }
        [Required]
        public int Edition { get; set; }
                 
		public ICollection<ContestRegistration> ContestantRegistrations { get; set; }

		public string Discriminator { get; set; }
	}
} 
 