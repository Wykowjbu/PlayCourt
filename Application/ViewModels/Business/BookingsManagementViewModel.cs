namespace PlayCourt.Application.ViewModels.Business
{
    public class BookingsManagementViewModel
    {
        public List<BookingDto> Bookings { get; set; } = new();
        public BookingStatsDto Stats { get; set; } = new();
        public PaginationDto Pagination { get; set; } = new();
    }

    public class BookingDto
    {
        public string BookingId { get; set; } = string.Empty;
        public string PlayerName { get; set; } = string.Empty;
        public string PlayerInitials { get; set; } = string.Empty;
        public string Sport { get; set; } = string.Empty;
        public string SportBadgeClass { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string TimeSlot { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string BookingType { get; set; } = string.Empty;
        public string BookingTypeBadgeClass { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string StatusBadgeClass { get; set; } = string.Empty;
    }

    public class BookingStatsDto
    {
        public int TodayBookings { get; set; }
        public string TodayGrowth { get; set; } = string.Empty;
        public int ActiveMatches { get; set; }
        public int OccupancyRate { get; set; }
        public int PendingRequests { get; set; }
    }

    public class PaginationDto
    {
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / ItemsPerPage);
        public string DisplayText => $"Showing {((CurrentPage - 1) * ItemsPerPage) + 1} to {Math.Min(CurrentPage * ItemsPerPage, TotalItems)} of {TotalItems} bookings";
    }
}
