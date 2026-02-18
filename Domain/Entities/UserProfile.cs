using System;
using System.Collections.Generic;

namespace Domain.Entities;

/// <summary>
/// Bảng lưu thông tin hồ sơ cá nhân của người dùng (dùng chung cho tất cả các loại user)
/// </summary>
public partial class UserProfile
{
    /// <summary>
    /// Khóa chính của bảng UserProfiles, tự tăng
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng auth_app.User (định danh người dùng)
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Họ và tên đầy đủ của người dùng
    /// </summary>
    public string FullName { get; set; } = null!;

    /// <summary>
    /// Đường dẫn (URL) ảnh đại diện của người dùng
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// Ngày sinh của người dùng
    /// </summary>
    public DateOnly? DateOfBirth { get; set; }

    /// <summary>
    /// Giới tính của người dùng:  0 = Nam, 1 = Nữ
    /// </summary>
    public short? Gender { get; set; }

    /// <summary>
    /// Địa chỉ chi tiết của người dùng
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Thành phố nơi người dùng sinh sống
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Quốc gia nơi người dùng sinh sống
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// Thời điểm tạo bản ghi hồ sơ người dùng
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Thời điểm cập nhật gần nhất thông tin hồ sơ người dùng
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<CourtOwnerProfile> CourtOwnerProfiles { get; set; } = new List<CourtOwnerProfile>();

    public virtual ICollection<MatchJoinRequest> MatchJoinRequests { get; set; } = new List<MatchJoinRequest>();

    public virtual ICollection<MatchParticipant> MatchParticipants { get; set; } = new List<MatchParticipant>();

    public virtual ICollection<Match> Matches { get; set; } = new List<Match>();

    public virtual ICollection<PlayerSport> PlayerSports { get; set; } = new List<PlayerSport>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual User User { get; set; } = null!;
}
