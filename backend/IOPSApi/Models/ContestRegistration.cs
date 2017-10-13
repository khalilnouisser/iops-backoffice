using System;
using IOPSBackend.Consts;
using System.ComponentModel.DataAnnotations;
namespace IOPSBackend.Models
{
    public class ContestRegistration
    {
        public DateTime RegistrationDate { get; set; }

        public Contestant Contestant { get; set; }
        public Contest Contest { get; set; }

        [Required]
        public string ContestNameC { get; set; }
        [Required]
        public int ContestEdition { get; set; }
        [Required]
        public int ContestantID { get; set; }

        public RegistrationContestStatus Status { get; set; }
        [Required]
        public double Score { get; set; }
        [Required]
        public int rang { get; set; }
    } 
}
 