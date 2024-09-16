﻿using System.ComponentModel.DataAnnotations;

namespace PortalAboutEverything.Models.Auth
{
    public class AuthViewModel
    {
        [Required(ErrorMessage = "Имя пользователя обязательно")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Вы забыли пароль")]
        public string Password { get; set; }
    }
}
