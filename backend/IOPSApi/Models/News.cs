﻿using System.ComponentModel.DataAnnotations;
using System;
namespace IOPSApi.Models
{
    public class News
    { 
        [Key]
        public int NewsID { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }
        public string PhotoURL { get; set; }
<<<<<<< HEAD
        public DateTime? DatePub { get; set; }
=======
        public DateTime DatePub { get; set; } = new DateTime();
>>>>>>> 4b0389fc64b3e261991c0b67f54501c498a5157b
    } 
}
