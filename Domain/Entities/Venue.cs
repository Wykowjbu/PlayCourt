using System;
using System.Collections.Generic;

namespace Domain.Entities;

/// <summary>
/// Thông tin sân thể thao (pickleball, tennis, badminton,...)
/// </summary>
public partial class Venue
{
    /// <summary>
    /// Khoá chính của sân
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ID chủ sân (tham chiếu auth_app.Users)
    /// </summary>
    public int OwnerId { get; set; }

    /// <summary>
    /// Tên sân
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Mô tả chi tiết về sân
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Địa chỉ chi tiết của sân
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// Vĩ độ (latitude) dùng để định vị bản đồ
    /// </summary>
    public double? Latitude { get; set; }

    /// <summary>
    /// Kinh độ (longitude) dùng để định vị bản đồ
    /// </summary>
    public double? Longitude { get; set; }

    /// <summary>
    /// Số điện thoại liên hệ sân
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Giờ mở cửa
    /// </summary>
    public TimeOnly? OpenTime { get; set; }

    /// <summary>
    /// Giờ đóng cửa
    /// </summary>
    public TimeOnly? CloseTime { get; set; }

    /// <summary>
    /// Trạng thái sân: 0-Pending | 1-Active | 2-Inactive | 3-Blocked
    /// </summary>
    public short Status { get; set; }

    /// <summary>
    /// Thời điểm tạo bản ghi sân
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Thời điểm cập nhật thông tin sân
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Court> Courts { get; set; } = new List<Court>();

    public virtual ICollection<Match> Matches { get; set; } = new List<Match>();

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<VenueDocument> VenueDocuments { get; set; } = new List<VenueDocument>();

    public virtual ICollection<VenueImage> VenueImages { get; set; } = new List<VenueImage>();

    public virtual ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
}
