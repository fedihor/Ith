using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ith.WebUI.Models.Identity
{
    public class EditUserModel
    {
        public string Name { get; set; }
    }

    public class EditRoleModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "Необходимо заполнить поле \"{0}\".")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Введите корректный адрес электронной почты.")]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [MinLength(2, ErrorMessage = "В поле \"{0}\" нужно указать минимум {1} символа.")]
        [MaxLength(10, ErrorMessage = "Поле \"{0}\" не должно превышать {1} символов.")]
        [Required(ErrorMessage = "Необходимо заполнить поле \"{0}\".")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле \"{0}\".")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле \"{0}\".")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        public string PasswordConfirm { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Почта")]
        public string Email { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}