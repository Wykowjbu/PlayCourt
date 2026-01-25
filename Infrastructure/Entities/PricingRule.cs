using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

/// <summary>
/// Quy tắc giá thuê sân theo ngày và khung giờ
/// </summary>
public partial class PricingRule
{
    /// <summary>
    /// Khoá chính bảng giá
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ID sân áp dụng bảng giá
    /// </summary>
    public int CourtId { get; set; }

    /// <summary>
    /// Thứ trong tuần: 1=Mon ... 7=Sun
    /// </summary>
    public int DayOfWeek { get; set; }

    /// <summary>
    /// Giờ bắt đầu áp dụng giá
    /// </summary>
    public TimeOnly StartTime { get; set; }

    /// <summary>
    /// Giờ kết thúc áp dụng giá
    /// </summary>
    public TimeOnly EndTime { get; set; }

    /// <summary>
    /// Giá thuê sân theo giờ
    /// </summary>
    public decimal PricePerHour { get; set; }

    /// <summary>
    /// Thời điểm tạo quy tắc giá
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    public virtual Court Court { get; set; } = null!;
}
