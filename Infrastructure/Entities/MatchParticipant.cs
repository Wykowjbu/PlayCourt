using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

/// <summary>
/// Bảng lưu danh sách người chơi đã được chấp nhận tham gia trận đấu
/// </summary>
public partial class MatchParticipant
{
    /// <summary>
    /// Khóa chính của bảng MatchParticipants, tự tăng
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng match.Matches (trận đấu)
    /// </summary>
    public int MatchId { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng user.UserProfiles (người chơi tham gia)
    /// </summary>
    public int PlayerId { get; set; }

    /// <summary>
    /// Thời điểm người chơi được chấp nhận tham gia trận đấu
    /// </summary>
    public DateTime JoinedAt { get; set; }

    /// <summary>
    /// Đánh dấu người chơi này là host (người tạo trận) hay không
    /// </summary>
    public bool IsHost { get; set; }

    public virtual Match Match { get; set; } = null!;

    public virtual UserProfile Player { get; set; } = null!;
}
