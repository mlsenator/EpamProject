using System.ComponentModel.DataAnnotations;

namespace TestingSystem.Models
{
    public class LogOnViewModel
    {
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}
