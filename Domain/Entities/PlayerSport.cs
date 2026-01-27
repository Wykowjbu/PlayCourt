using System;
using System.Collections.Generic;

namespace Domain.Entities;

/// <summary>
/// Bảng liên kết giữa người chơi và các môn thể thao mà họ tham gia
/// </summary>
public partial class PlayerSport
{
    /// <summary>
    /// Khóa chính của bảng PlayerSports, tự tăng
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng user.UserProfiles (hồ sơ user)
    /// </summary>
    public int UserProfilesId { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng sport.Sports (môn thể thao)
    /// </summary>
    public int SportId { get; set; }

    /// <summary>
    /// Trình độ của người chơi đối với môn thể thao: 0 = Người mới, 1 = Trung bình, 2 = Nâng cao
    /// </summary>
    public short SkillLevel { get; set; }

    /// <summary>
    /// Thời điểm người chơi đăng ký tham gia môn thể thao
    /// </summary>
    public DateTime CreatedAt { get; set; }

    public virtual Sport Sport { get; set; } = null!;

    public virtual UserProfile UserProfiles { get; set; } = null!;
}
