using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

/// <summary>
/// Bảng lưu thông tin các bài đăng tìm trận (match request) do người chơi tạo
/// </summary>
public partial class Match
{
    /// <summary>
    /// Khóa chính của bảng Matches, tự tăng
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng user.UserProfiles (người tạo trận - host)
    /// </summary>
    public int HostId { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng sport.Sports (môn thể thao của trận đấu)
    /// </summary>
    public int SportId { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng venue.Venues (sân lớn - có thể NULL nếu chỉ mô tả khu vực)
    /// </summary>
    public int? VenueId { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng court.Courts (sân con cụ thể - có thể NULL nếu chỉ chọn venue)
    /// </summary>
    public int? CourtId { get; set; }

    /// <summary>
    /// Mô tả địa điểm chơi (ví dụ: &quot;Quận Hải Châu&quot; khi không chọn sân cụ thể)
    /// </summary>
    public string? LocationDescription { get; set; }

    /// <summary>
    /// Ngày dự kiến tổ chức trận đấu
    /// </summary>
    public DateOnly ScheduledDate { get; set; }

    /// <summary>
    /// Giờ bắt đầu trận đấu
    /// </summary>
    public TimeOnly StartTime { get; set; }

    /// <summary>
    /// Giờ kết thúc trận đấu
    /// </summary>
    public TimeOnly EndTime { get; set; }

    /// <summary>
    /// Trình độ tối thiểu yêu cầu (0=Beginner, 1=Intermediate, 2=Advanced) - NULL = không yêu cầu
    /// </summary>
    public short? RequiredSkillLevelMin { get; set; }

    /// <summary>
    /// Trình độ tối đa yêu cầu (0=Beginner, 1=Intermediate, 2=Advanced) - NULL = không giới hạn
    /// </summary>
    public short? RequiredSkillLevelMax { get; set; }

    /// <summary>
    /// Số lượng người chơi tối đa (bao gồm cả host)
    /// </summary>
    public short MaxParticipants { get; set; }

    /// <summary>
    /// Số lượng người chơi hiện tại (bắt đầu = 1 do có host)
    /// </summary>
    public short CurrentParticipants { get; set; }

    /// <summary>
    /// Mô tả cách chia tiền (ví dụ: &quot;50/50&quot;, &quot;Loser pays&quot;, &quot;Free&quot;)
    /// </summary>
    public string? CostDescription { get; set; }

    /// <summary>
    /// Mô tả chi tiết về trận đấu, ghi chú từ host
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Trạng thái trận đấu: 0=Open (Đang tìm người), 1=Full (Đã đủ người), 2=InProgress (Đang diễn ra), 3=Completed (Đã kết thúc), 4=Cancelled (Đã hủy)
    /// </summary>
    public short Status { get; set; }

    /// <summary>
    /// Thời điểm tạo bài đăng tìm trận
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Thời điểm cập nhật thông tin trận đấu gần nhất
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public virtual Court? Court { get; set; }

    public virtual UserProfile Host { get; set; } = null!;

    public virtual ICollection<MatchJoinRequest> MatchJoinRequests { get; set; } = new List<MatchJoinRequest>();

    public virtual ICollection<MatchParticipant> MatchParticipants { get; set; } = new List<MatchParticipant>();

    public virtual Sport Sport { get; set; } = null!;

    public virtual Venue? Venue { get; set; }
}
