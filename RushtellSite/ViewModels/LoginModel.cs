using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RushtellSite.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Неверный Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Неверный пароль")]
        public string Password { get; set; }
    }
}
