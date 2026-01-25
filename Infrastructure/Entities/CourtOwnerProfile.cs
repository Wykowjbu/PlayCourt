using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

/// <summary>
/// Bảng lưu thông tin hồ sơ dành riêng cho chủ sân thể thao
/// </summary>
public partial class CourtOwnerProfile
{
    /// <summary>
    /// Khóa chính của bảng CourtOwnerProfiles, tự tăng
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng user.UserProfiles (hồ sơ người dùng)
    /// </summary>
    public int UserProfilesId { get; set; }

    /// <summary>
    /// Tên doanh nghiệp hoặc tên cơ sở kinh doanh của chủ sân
    /// </summary>
    public string BusinessName { get; set; } = null!;

    /// <summary>
    /// Số giấy phép kinh doanh của chủ sân
    /// </summary>
    public string BusinessLicenseNo { get; set; } = null!;

    /// <summary>
    /// Mã số thuế của doanh nghiệp hoặc chủ sân
    /// </summary>
    public string? TaxCode { get; set; }

    /// <summary>
    /// Địa chỉ kinh doanh của sân thể thao
    /// </summary>
    public string BusinessAddress { get; set; } = null!;

    /// <summary>
    /// Trạng thái xác minh hồ sơ chủ sân: 0 = Chờ duyệt, 1 = Đã duyệt, 2 = Từ chối (0=Pending, 1=Approved, 2=Rejected)
    /// </summary>
    public short VerificationStatus { get; set; }

    /// <summary>
    /// Thời điểm tạo hồ sơ chủ sân
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Thời điểm cập nhật gần nhất hồ sơ chủ sân
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public virtual UserProfile UserProfiles { get; set; } = null!;
}
