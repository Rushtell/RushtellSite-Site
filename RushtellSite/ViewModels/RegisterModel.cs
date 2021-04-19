using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RushtellSite.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Неверный Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        [Required(ErrorMessage = "Пароль введен не верно")]
        public string ConfirmPassword { get; set; }
    }
}
