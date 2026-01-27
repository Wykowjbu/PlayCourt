using System;
using System.Collections.Generic;

namespace Domain.Entities;

/// <summary>
/// Bảng lưu thông tin xác thực và phân quyền người dùng trong hệ thống
/// </summary>
public partial class User
{
    /// <summary>
    /// Khóa chính của bảng User, tự tăng
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Email dùng để đăng nhập hệ thống (duy nhất)
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Số điện thoại của người dùng
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Mật khẩu đã được mã hóa (hash)
    /// </summary>
    public string PasswordHash { get; set; } = null!;

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng auth_app.Roles (vai trò người dùng)
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Trạng thái tài khoản: 0 = Chưa xác minh, 1 = Hoạt động, 2 = Bị khóa
    /// </summary>
    public short Status { get; set; }

    /// <summary>
    /// Trạng thái xác minh email của người dùng
    /// </summary>
    public bool IsEmailVerified { get; set; }

    /// <summary>
    /// Số lần đăng nhập thất bại liên tiếp
    /// </summary>
    public int FailedLoginCount { get; set; }

    /// <summary>
    /// Thời điểm hết hạn khóa tài khoản do đăng nhập sai
    /// </summary>
    public DateTime? LockedUntil { get; set; }

    /// <summary>
    /// Thời điểm đăng nhập gần nhất
    /// </summary>
    public DateTime? LastLoginAt { get; set; }

    /// <summary>
    /// Thời điểm tạo tài khoản người dùng
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Thời điểm cập nhật thông tin tài khoản gần nhất
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<ReviewReport> ReviewReportReporters { get; set; } = new List<ReviewReport>();

    public virtual ICollection<ReviewReport> ReviewReportResolvedBies { get; set; } = new List<ReviewReport>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();

    public virtual ICollection<Venue> Venues { get; set; } = new List<Venue>();
}
