using System;
using System.Collections.Generic;

namespace Domain.Entities;

/// <summary>
/// Bảng lưu hình ảnh kèm theo đánh giá của người chơi (tối đa 5-10 ảnh/review)
/// </summary>
public partial class ReviewImage
{
    /// <summary>
    /// Khóa chính của bảng ReviewImages, tự tăng
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Khóa ngoại tham chiếu đến bảng review.Reviews (đánh giá chứa hình ảnh này)
    /// </summary>
    public int ReviewId { get; set; }

    /// <summary>
    /// Đường dẫn URL đến hình ảnh được upload
    /// </summary>
    public string ImageUrl { get; set; } = null!;

    /// <summary>
    /// Thứ tự hiển thị hình ảnh (0 = ảnh đầu tiên, 1 = ảnh thứ hai,...)
    /// </summary>
    public short DisplayOrder { get; set; }

    /// <summary>
    /// Thời điểm upload hình ảnh
    /// </summary>
    public DateTime CreatedAt { get; set; }

    public virtual Review Review { get; set; } = null!;
}
