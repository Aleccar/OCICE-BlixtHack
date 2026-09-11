using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required] [MaxLength(50)] public string UserName { get; set; }
        [Required][MaxLength(20)] public string PasswordHash { get; set; }
        [Required] public bool IsAdmin { get; set; }
    }
}
