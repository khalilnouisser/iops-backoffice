using System;
using System.ComponentModel.DataAnnotations;
namespace IOPSBackend.Models
{
    public class CountryAdmin : Admin
    {
		public NationalContest NationalContest { get; set; }
        [Required]
        public string NationalContestNameC { get; set; }
        [Required]
        public int NationalContestEdition { get; set; }
	}
}
