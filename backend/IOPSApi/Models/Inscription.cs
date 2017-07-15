    using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace IOPSApi.Models
{
    public class Inscription
    {
        [Key]
        public int InscID { set; get; }
        public string Username { get; set; }
        public string BirthdayDate { get; set; }
        [Required]
        public string Fname { get; set; }
		[Required]
		public string Lname { set; get; }
        [EmailAddress]
		[Required]
		public string EmailAdress { set; get; }
        public DateTime? DateInsc { get; set; }

        public string CinPic { set; get; }
        public string CEPic { set; get; }

        public Context Context { get; set; }
        public string ContextID { get; set; }

		public Country Country { get; set; }
		[Required]
		public string CountryID { get; set; }

        public InscriptionStatus Status { get; set; }
		[Required]
		public string University { get; set; }

	}

    public enum InscriptionStatus {
        New,
        EmailVerifed,
        Confrimed
    }
}
