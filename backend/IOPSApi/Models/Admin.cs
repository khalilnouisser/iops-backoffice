using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace IOPSApi.Models
{
    public class Admin : User
    {
        [Required]  
        public string AdminPassword { get; set; }
    }
}
