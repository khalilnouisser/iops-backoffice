using System;
using System.Collections.Generic;
using IOPSBackend.Consts;
using System.ComponentModel.DataAnnotations;
namespace IOPSBackend.Models
{
    public class Contestant : User
    {
        public int PhoneNumber { get; set; }
        public string IdentityCardScan { get; set; }
        public string StudentCardScan { get; set; }
        public DateTime RegistrationDate { get; set; }


        public Institution Institution { get; set; }
        [Required]
        public string InstitutionName { get; set; }

        public Country Country { get; set; }
        [Required]
        public string CountryID { get; set; }

        public string c { get; set; }

        public RegistrationStatus Status { get; set; } = RegistrationStatus.INACTIVE;

        public ICollection<ContestRegistration> ConrestRegistrations { get; set; }
	} 
}