using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

/// <summary>
/// Lịch khoá sân (bảo trì, nghỉ lễ, sự kiện,...)
/// </summary>
public partial class CourtSchedule
{
    /// <summary>
    /// Khoá chính lịch sân
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ID sân bị khoá
    /// </summary>
    public int CourtId { get; set; }

    /// <summary>
    /// Thời điểm bắt đầu khoá sân
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// Thời điểm kết thúc khoá sân
    /// </summary>
    public DateTime EndTime { get; set; }

    /// <summary>
    /// Lý do khoá sân
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// Thời điểm tạo lịch khoá
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    public virtual Court Court { get; set; } = null!;
}
