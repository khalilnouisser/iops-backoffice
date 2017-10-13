using System;
using System.ComponentModel.DataAnnotations;

namespace IOPSBackend.Models
{
    public class SuperAdmin : Admin
    {
        public InternationalContest InternationalContest { get; set; }
        [Required]
        public int InternationalContestEdition { get; set; }
		public string InternationalContestNameC { get; set; }
	}
} 
