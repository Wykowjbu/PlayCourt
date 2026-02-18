using System;
using System.Collections.Generic;

namespace Domain.Entities;

/// <summary>
/// Giấy tờ pháp lý của sân
/// </summary>
public partial class VenueDocument
{
    /// <summary>
    /// Khoá chính giấy tờ
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ID sân sở hữu giấy tờ
    /// </summary>
    public int VenueId { get; set; }

    /// <summary>
    /// Loại giấy tờ: BusinessLicense, Contract, IDCard,...
    /// </summary>
    public string DocumentType { get; set; } = null!;

    /// <summary>
    /// Đường dẫn file giấy tờ
    /// </summary>
    public string DocumentUrl { get; set; } = null!;

    /// <summary>
    /// Trạng thái duyệt: 0-Pending | 1-Approved | 2-Rejected
    /// </summary>
    public short? Status { get; set; }

    /// <summary>
    /// Thời điểm chủ sân upload giấy tờ
    /// </summary>
    public DateTime? UploadedAt { get; set; }

    /// <summary>
    /// Thời điểm admin xác minh giấy tờ
    /// </summary>
    public DateTime? VerifiedAt { get; set; }

    public virtual Venue Venue { get; set; } = null!;
}
