using System;
using System.ComponentModel.DataAnnotations;
namespace IOPSBackend.Models
{
    public class LocalContestAdmin : Admin
    {
        public LocalContest LocalContest { get; set; }
        [Required]
        public string LocalContestNameC { get; set; }
        [Required]
        public int LocalContestEdition { get; set; }
	} 
}
