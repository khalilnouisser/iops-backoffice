using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IOPSBackend.Models
{
    public class LocalContest : Contest
    {
        public NationalContest NationalContest { get; set; }
        [Required]
		public string NationalContestNameC { get; set; }
        [Required]
		public int NationalContestEdition { get; set; }

        public ICollection<LocalContestAdmin> Admins { get; set; }

	}
}
