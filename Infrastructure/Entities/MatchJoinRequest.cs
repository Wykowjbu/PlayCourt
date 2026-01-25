using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

/// <summary>
/// Bảng lưu các yêu cầu xin tham gia trận đấu từ người chơi, chờ host duyệt
/// </summary>
public partial class MatchJoinRequest
{
    /// <summary>
    /// Khóa chính của bảng MatchJoinRequests, tự tăng
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng match.Matches (trận đấu muốn tham gia)
    /// </summary>
    public int MatchId { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng user.UserProfiles (người chơi gửi yêu cầu)
    /// </summary>
    public int PlayerId { get; set; }

    /// <summary>
    /// Trạng thái yêu cầu: 0=Pending (Chờ duyệt), 1=Accepted (Đã chấp nhận), 2=Rejected (Đã từ chối)
    /// </summary>
    public short Status { get; set; }

    /// <summary>
    /// Thời điểm gửi yêu cầu tham gia
    /// </summary>
    public DateTime RequestedAt { get; set; }

    /// <summary>
    /// Thời điểm host phản hồi (accept/reject) yêu cầu
    /// </summary>
    public DateTime? RespondedAt { get; set; }

    public virtual Match Match { get; set; } = null!;

    public virtual UserProfile Player { get; set; } = null!;
}
