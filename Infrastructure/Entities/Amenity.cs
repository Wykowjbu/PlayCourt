using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

/// <summary>
/// Danh mục tiện ích sân
/// </summary>
public partial class Amenity
{
    /// <summary>
    /// Khoá chính tiện ích
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Tên tiện ích (Parking, Wifi, Shower,...)
    /// </summary>
    public string Name { get; set; } = null!;

    public virtual ICollection<Venue> Venues { get; set; } = new List<Venue>();
}
