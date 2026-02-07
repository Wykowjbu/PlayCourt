using System;
using System.Collections.Generic;

namespace Domain.Entities;

/// <summary>
/// Danh sách hình ảnh của sân
/// </summary>
public partial class VenueImage
{
    /// <summary>
    /// Khoá chính ảnh
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ID sân sở hữu hình ảnh
    /// </summary>
    public int VenueId { get; set; }

    /// <summary>
    /// Đường dẫn ảnh (URL hoặc path)
    /// </summary>
    public string ImageUrl { get; set; } = null!;

    /// <summary>
    /// Ảnh đại diện của sân hay không
    /// </summary>
    public bool? IsCover { get; set; }

    /// <summary>
    /// Thời điểm upload ảnh
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    public virtual Venue Venue { get; set; } = null!;
}
