using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Venues;

public class VenueDetailViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string DistanceInfo { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public decimal PricePerHour { get; set; }
    public List<string> Images { get; set; }
    public List<AmenityViewModel> Amenities { get; set; }
    public List<ReviewViewModel> Reviews { get; set; }
    public List<ScheduleDateViewModel> AvailableDates { get; set; }
    public List<TimeSlotViewModel> TimeSlots { get; set; }
}

public class AmenityViewModel
{
    public string Icon { get; set; }
    public string Name { get; set; }
}

public class ReviewViewModel
{
    public string UserName { get; set; }
    public string UserAvatar { get; set; }
    public string TimeAgo { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
}

public class ScheduleDateViewModel
{
    public DateTime Date { get; set; }
    public bool IsSelected { get; set; }
}

public class TimeSlotViewModel
{
    public string TimeRange { get; set; }
    public string Status { get; set; } // Available, Booked
}
