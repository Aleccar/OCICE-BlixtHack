using System.ComponentModel.DataAnnotations;

namespace OCICE_BlixtHack.Models
{
    public class UserLoginVm
    {
        [Required] public string UserName { get; set; }
        [Required] public string Password { get; set; }
    }
}
