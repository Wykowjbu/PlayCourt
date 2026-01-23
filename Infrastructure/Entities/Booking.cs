using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

/// <summary>
/// Bảng lưu trữ thông tin đặt sân (Normalized).
/// </summary>
public partial class Booking
{
    public int Id { get; set; }

    public int UserId { get; set; }

    /// <summary>
    /// Tham chiếu đến bảng Venues. Join để lấy tên và địa chỉ.
    /// </summary>
    public int VenueId { get; set; }

    /// <summary>
    /// Tham chiếu đến bảng Courts. Join để lấy tên sân.
    /// </summary>
    public int CourtId { get; set; }

    public DateOnly BookingDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    /// <summary>
    /// Giá tiền chốt tại thời điểm đặt (Snapshot giá).
    /// </summary>
    public decimal TotalPrice { get; set; }

    public decimal? PlatformFee { get; set; }

    public decimal OwnerEarnings { get; set; }

    /// <summary>
    /// Trạng thái đơn hàng. Mapping Code: 0=Pending, 1=Confirmed, 2=Cancelled, 3=Completed, 4=Refunded
    /// </summary>
    public short Status { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Court Court { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Review? Review { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual Venue Venue { get; set; } = null!;
}
