using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Organization.UI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Boş Geçilemez"),StringLength(50,ErrorMessage ="{0} max {1} karakter olmalıdır")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez"), StringLength(50, ErrorMessage = "{0} max {1} karakter olmalıdır")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez"), StringLength(50, ErrorMessage = "{0} karakter olmalıdır")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez"), StringLength(50, ErrorMessage = "{0} karakter olmalıdır"),Compare("Password",ErrorMessage = "{0} ile {1} uyuşmuyor...")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez"), StringLength(50, ErrorMessage = "{0} karakter olmalıdır")]
        public string Phone { get; set; }
    }
}