using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Auth
{
    public class VerifyAccountViewModel
    {
        // Hiển thị thông tin user đang verify (email hoặc sđt đã che)
        public string TargetDestination { get; set; } = string.Empty;

        // Dữ liệu OTP nhập vào (6 ô input)
        public string Digit1 { get; set; }
        public string Digit2 { get; set; }
        public string Digit3 { get; set; }
        public string Digit4 { get; set; }
        public string Digit5 { get; set; }
        public string Digit6 { get; set; }

        // Token định danh user (email ẩn) để post về server
        public string Email  { get; set; }

        // Cờ trạng thái để hiển thị nút Resend
        public bool CanResend { get; set; }
        public int ResendCountdown { get; set; } = 59;
    }
}
