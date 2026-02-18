using System;
using System.Collections.Generic;

namespace Domain.Entities;

/// <summary>
/// Bảng lưu các báo cáo vi phạm về nội dung đánh giá (spam, offensive, fake review)
/// </summary>
public partial class ReviewReport
{
    /// <summary>
    /// Khóa chính của bảng ReviewReports, tự tăng
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng review.Reviews (đánh giá bị báo cáo)
    /// </summary>
    public int ReviewId { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng auth_app.User (người gửi báo cáo)
    /// </summary>
    public int ReporterId { get; set; }

    /// <summary>
    /// Loại vi phạm: 0=Spam, 1=Offensive/Abusive, 2=Fake Review, 3=Inappropriate Content, 4=Other
    /// </summary>
    public short ReasonType { get; set; }

    /// <summary>
    /// Mô tả chi tiết lý do báo cáo từ người dùng
    /// </summary>
    public string? ReasonDescription { get; set; }

    /// <summary>
    /// Trạng thái xử lý: 0=Pending (Chờ xử lý), 1=Resolved (Đã xử lý - review bị ẩn/xóa), 2=Rejected (Báo cáo không hợp lệ)
    /// </summary>
    public short Status { get; set; }

    /// <summary>
    /// Thời điểm gửi báo cáo
    /// </summary>
    public DateTime ReportedAt { get; set; }

    /// <summary>
    /// Thời điểm admin xử lý báo cáo
    /// </summary>
    public DateTime? ResolvedAt { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng auth_app.User (admin xử lý báo cáo)
    /// </summary>
    public int? ResolvedById { get; set; }

    /// <summary>
    /// Ghi chú của admin khi xử lý báo cáo
    /// </summary>
    public string? AdminNote { get; set; }

    public virtual User Reporter { get; set; } = null!;

    public virtual User? ResolvedBy { get; set; }

    public virtual Review Review { get; set; } = null!;
}
