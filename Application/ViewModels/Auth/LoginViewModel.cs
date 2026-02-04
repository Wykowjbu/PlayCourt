using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "Please Enter Email or Phone")]
        public string Identifier { get; set; } = string.Empty; // Email hoặc Phone

        [Required (ErrorMessage = "Please Enter Pasword")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }


        // Chỉ chứa dữ liệu cần thiết cho UI, không chứa logic DB
    }
}
