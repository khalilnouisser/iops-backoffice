using System;
using System.Collections.Generic;
namespace IOPSBackend.Models
{
    public class NationalContest : Contest
    {
        public Country Country { get; set; }
        public string CountryName { get; set; }
        public InternationalContest InternationalContest { get; set; }
        public string InternationalContestNameC { get; set; }
		public int InternationalContestEdition { get; set; }

        public ICollection<LocalContest> LocalContests { get; set; }

        public ICollection<CountryAdmin> Admins { get; set; }

	} 
}