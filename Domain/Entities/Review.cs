using System;
using System.Collections.Generic;

namespace Domain.Entities;

/// <summary>
/// Bảng lưu đánh giá của người chơi về sân thể thao sau khi hoàn thành booking
/// </summary>
public partial class Review
{
    /// <summary>
    /// Khóa chính của bảng Reviews, tự tăng
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng user.UserProfiles (người đánh giá)
    /// </summary>
    public int PlayerId { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng venue.Venues (sân được đánh giá)
    /// </summary>
    public int VenueId { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng booking.Bookings (booking liên quan - NULL nếu đánh giá chung)
    /// </summary>
    public int? BookingId { get; set; }

    /// <summary>
    /// Điểm đánh giá từ 1.0 đến 5.0 sao (cho phép 0.5 sao, ví dụ: 4.5)
    /// </summary>
    public decimal Rating { get; set; }

    /// <summary>
    /// Nội dung đánh giá chi tiết của người chơi (tùy chọn)
    /// </summary>
    public string? ReviewText { get; set; }

    /// <summary>
    /// Trạng thái đánh giá: 0=Active (Hiển thị công khai), 1=Hidden (Đã ẩn bởi admin), 2=Flagged (Bị báo cáo - đang chờ kiểm duyệt)
    /// </summary>
    public short Status { get; set; }

    /// <summary>
    /// Thời điểm tạo đánh giá
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Thời điểm cập nhật đánh giá gần nhất (khi người dùng edit)
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual UserProfile Player { get; set; } = null!;

    public virtual ICollection<ReviewImage> ReviewImages { get; set; } = new List<ReviewImage>();

    public virtual ICollection<ReviewReport> ReviewReports { get; set; } = new List<ReviewReport>();

    public virtual Venue Venue { get; set; } = null!;
}
