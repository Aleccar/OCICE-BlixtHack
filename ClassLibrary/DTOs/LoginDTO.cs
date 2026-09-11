using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="Skriv in användarnamn")]
        [Display(Name ="Användarnamn:")]
        public string UserName {  get; set; }
        [Required(ErrorMessage ="Skriv lösenord")]
        [Display(Name ="Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
