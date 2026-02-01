using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Auth
{
    public  class RegisterPlayerViewModel
    {
        [Required(ErrorMessage = "Vui lòng chọn vai trò.")]
        public string Role { get; set; } = "Player"; // Default value

        [Required(ErrorMessage = "Vui lòng nhập họ tên.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập Email.")]
        [EmailAddress(ErrorMessage = "Định dạng Email không hợp lệ.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [MinLength(8, ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
