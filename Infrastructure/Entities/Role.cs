using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

/// <summary>
/// Bảng danh mục vai trò người dùng trong hệ thống
/// </summary>
public partial class Role
{
    /// <summary>
    /// Khóa chính của bảng Roles
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Mã vai trò (ví dụ: PLAYER, COURT_OWNER, ADMIN)
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// Tên vai trò hiển thị
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Mô tả chi tiết quyền hạn của vai trò
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Thời điểm tạo vai trò
    /// </summary>
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
