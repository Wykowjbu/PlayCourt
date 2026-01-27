using System;
using System.Collections.Generic;

namespace Domain.Entities;

/// <summary>
/// Danh sách các sân con thuộc một venue
/// </summary>
public partial class Court
{
    /// <summary>
    /// Khoá chính của sân
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ID venue mà sân thuộc về
    /// </summary>
    public int VenueId { get; set; }

    /// <summary>
    /// Tên sân (Court 1, Court A,...)
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// ID môn thể thao (Pickleball | Tennis | Badminton)
    /// </summary>
    public int SportId { get; set; }

    /// <summary>
    /// Sân trong nhà hay ngoài trời
    /// </summary>
    public bool? Indoor { get; set; }

    /// <summary>
    /// Trạng thái sân: 0-Active | 1-Maintenance | 2-Inactive
    /// </summary>
    public short Status { get; set; }

    /// <summary>
    /// Thời điểm tạo sân
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<CourtSchedule> CourtSchedules { get; set; } = new List<CourtSchedule>();

    public virtual ICollection<Match> Matches { get; set; } = new List<Match>();

    public virtual ICollection<PricingRule> PricingRules { get; set; } = new List<PricingRule>();

    public virtual Sport Sport { get; set; } = null!;

    public virtual Venue Venue { get; set; } = null!;
}
