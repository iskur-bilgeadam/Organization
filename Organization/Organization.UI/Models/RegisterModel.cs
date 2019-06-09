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
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        ErrorMessage = "Email adresi geçersiz!")]
        [Display(Name = "E-Posta")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez"), StringLength(50, ErrorMessage = "{0} karakter olmalıdır")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez"), StringLength(50, ErrorMessage = "{0} karakter olmalıdır"),Compare("Password",ErrorMessage = "Şifreler uyuşmuyor...")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Range(10000000000, 99999999999, ErrorMessage = "Telefon 11  karakterden oluşmaldır!")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
    }
}