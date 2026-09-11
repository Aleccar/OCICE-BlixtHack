using System.ComponentModel.DataAnnotations;

namespace OCICE_BlixtHack.Models
{
    public class UserLoginVm
    {
        [Required] public string UserName { get; set; }
        [Required][DataType(DataType.Password)] public string Password { get; set; }
    }
}
