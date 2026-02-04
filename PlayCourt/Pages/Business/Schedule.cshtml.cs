using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayCourt.Application.ViewModels.Business;

namespace PlayCourt.WebApp.Pages.Business
{
    public class ScheduleModel : PageModel
    {
        public BookingsManagementViewModel Data { get; set; } = new();
        
        [BindProperty(SupportsGet = true)]
        public string? SearchQuery { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string? StartDate { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string? EndDate { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public void OnGet()
        {
            // MOCK DATA: Replace this with logic from Application Service
            var allBookings = GetAllMockBookings();
            
            // Apply search filter
            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                allBookings = allBookings.Where(b => 
                    b.PlayerName.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    b.BookingId.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }
            
            // Apply date filter
            if (!string.IsNullOrWhiteSpace(StartDate) || !string.IsNullOrWhiteSpace(EndDate))
            {
                DateTime? startDateParsed = null;
                DateTime? endDateParsed = null;
                
                if (!string.IsNullOrWhiteSpace(StartDate) && DateTime.TryParse(StartDate, out var sd))
                {
                    startDateParsed = sd;
                }
                
                if (!string.IsNullOrWhiteSpace(EndDate) && DateTime.TryParse(EndDate, out var ed))
                {
                    endDateParsed = ed;
                }
                
                allBookings = allBookings.Where(b =>
                {
                    // Parse the date string (format: "May 24, 2024")
                    if (DateTime.TryParse(b.Date, out var bookingDate))
                    {
                        bool matchesStart = !startDateParsed.HasValue || bookingDate >= startDateParsed.Value;
                        bool matchesEnd = !endDateParsed.HasValue || bookingDate <= endDateParsed.Value;
                        return matchesStart && matchesEnd;
                    }
                    return false;
                }).ToList();
            }
            
            // Pagination
            int itemsPerPage = 10;
            int totalItems = allBookings.Count;
            int skip = (PageNumber - 1) * itemsPerPage;
            var pagedBookings = allBookings.Skip(skip).Take(itemsPerPage).ToList();
            
            Data = new BookingsManagementViewModel
            {
                Bookings = pagedBookings,
                Stats = new BookingStatsDto
                {
                    TodayBookings = 18,
                    TodayGrowth = "+12%",
                    ActiveMatches = 5,
                    OccupancyRate = 82,
                    PendingRequests = 3
                },
                Pagination = new PaginationDto
                {
                    CurrentPage = PageNumber,
                    TotalItems = totalItems,
                    ItemsPerPage = itemsPerPage
                }
            };
        }
        
        private List<BookingDto> GetAllMockBookings()
        {
            return new List<BookingDto>
            {
                new()
                {
                    BookingId = "#BK-9021",
                    PlayerName = "James Smith",
                    PlayerInitials = "JS",
                    Sport = "Pickleball",
                    SportBadgeClass = "bg-blue-50 dark:bg-blue-900/30 text-blue-600 dark:text-blue-400",
                    Date = "May 24, 2024",
                    TimeSlot = "17:00 - 18:30",
                    Duration = "90 min",
                    BookingType = "Private Booking",
                    BookingTypeBadgeClass = "text-slate-600 dark:text-slate-400 bg-slate-100 dark:bg-slate-700/50",
                    Status = "Confirmed",
                    StatusBadgeClass = "bg-primary/10 text-primary"
                },
                new()
                {
                    BookingId = "#BK-8842",
                    PlayerName = "Elena Lopez",
                    PlayerInitials = "EL",
                    Sport = "Tennis",
                    SportBadgeClass = "bg-amber-50 dark:bg-amber-900/30 text-amber-600 dark:text-amber-400",
                    Date = "May 24, 2024",
                    TimeSlot = "19:00 - 20:00",
                    Duration = "60 min",
                    BookingType = "Matchmaking",
                    BookingTypeBadgeClass = "text-blue-600 dark:text-blue-400 bg-blue-50 dark:bg-blue-900/30",
                    Status = "Match Found",
                    StatusBadgeClass = "bg-blue-100 dark:bg-blue-900 text-blue-600 dark:text-blue-300"
                },
                new()
                {
                    BookingId = "#BK-9104",
                    PlayerName = "Marcus Wong",
                    PlayerInitials = "MW",
                    Sport = "Badminton",
                    SportBadgeClass = "bg-indigo-50 dark:bg-indigo-900/30 text-indigo-600 dark:text-indigo-400",
                    Date = "May 25, 2024",
                    TimeSlot = "08:00 - 10:00",
                    Duration = "120 min",
                    BookingType = "Private Booking",
                    BookingTypeBadgeClass = "text-slate-600 dark:text-slate-400 bg-slate-100 dark:bg-slate-700/50",
                    Status = "Pending",
                    StatusBadgeClass = "bg-slate-100 dark:bg-slate-700 text-slate-500 dark:text-slate-400"
                },
                new()
                {
                    BookingId = "#BK-9200",
                    PlayerName = "Sarah Johnson",
                    PlayerInitials = "SJ",
                    Sport = "Tennis",
                    SportBadgeClass = "bg-amber-50 dark:bg-amber-900/30 text-amber-600 dark:text-amber-400",
                    Date = "May 25, 2024",
                    TimeSlot = "14:00 - 15:30",
                    Duration = "90 min",
                    BookingType = "Private Booking",
                    BookingTypeBadgeClass = "text-slate-600 dark:text-slate-400 bg-slate-100 dark:bg-slate-700/50",
                    Status = "Confirmed",
                    StatusBadgeClass = "bg-primary/10 text-primary"
                },
                new()
                {
                    BookingId = "#BK-9201",
                    PlayerName = "Michael Chen",
                    PlayerInitials = "MC",
                    Sport = "Pickleball",
                    SportBadgeClass = "bg-blue-50 dark:bg-blue-900/30 text-blue-600 dark:text-blue-400",
                    Date = "May 26, 2024",
                    TimeSlot = "09:00 - 10:00",
                    Duration = "60 min",
                    BookingType = "Matchmaking",
                    BookingTypeBadgeClass = "text-blue-600 dark:text-blue-400 bg-blue-50 dark:bg-blue-900/30",
                    Status = "Searching",
                    StatusBadgeClass = "bg-amber-100 dark:bg-amber-900 text-amber-600 dark:text-amber-300"
                },
                new()
                {
                    BookingId = "#BK-9202",
                    PlayerName = "Emily Parker",
                    PlayerInitials = "EP",
                    Sport = "Badminton",
                    SportBadgeClass = "bg-indigo-50 dark:bg-indigo-900/30 text-indigo-600 dark:text-indigo-400",
                    Date = "May 26, 2024",
                    TimeSlot = "16:00 - 18:00",
                    Duration = "120 min",
                    BookingType = "Private Booking",
                    BookingTypeBadgeClass = "text-slate-600 dark:text-slate-400 bg-slate-100 dark:bg-slate-700/50",
                    Status = "Confirmed",
                    StatusBadgeClass = "bg-primary/10 text-primary"
                },
                new()
                {
                    BookingId = "#BK-9203",
                    PlayerName = "David Lee",
                    PlayerInitials = "DL",
                    Sport = "Tennis",
                    SportBadgeClass = "bg-amber-50 dark:bg-amber-900/30 text-amber-600 dark:text-amber-400",
                    Date = "May 27, 2024",
                    TimeSlot = "10:00 - 11:30",
                    Duration = "90 min",
                    BookingType = "Private Booking",
                    BookingTypeBadgeClass = "text-slate-600 dark:text-slate-400 bg-slate-100 dark:bg-slate-700/50",
                    Status = "Confirmed",
                    StatusBadgeClass = "bg-primary/10 text-primary"
                },
                new()
                {
                    BookingId = "#BK-9204",
                    PlayerName = "Lisa Wang",
                    PlayerInitials = "LW",
                    Sport = "Pickleball",
                    SportBadgeClass = "bg-blue-50 dark:bg-blue-900/30 text-blue-600 dark:text-blue-400",
                    Date = "May 28, 2024",
                    TimeSlot = "15:00 - 16:00",
                    Duration = "60 min",
                    BookingType = "Matchmaking",
                    BookingTypeBadgeClass = "text-blue-600 dark:text-blue-400 bg-blue-50 dark:bg-blue-900/30",
                    Status = "Match Found",
                    StatusBadgeClass = "bg-blue-100 dark:bg-blue-900 text-blue-600 dark:text-blue-300"
                },
                new()
                {
                    BookingId = "#BK-9205",
                    PlayerName = "Tom Anderson",
                    PlayerInitials = "TA",
                    Sport = "Badminton",
                    SportBadgeClass = "bg-indigo-50 dark:bg-indigo-900/30 text-indigo-600 dark:text-indigo-400",
                    Date = "May 29, 2024",
                    TimeSlot = "18:00 - 19:30",
                    Duration = "90 min",
                    BookingType = "Private Booking",
                    BookingTypeBadgeClass = "text-slate-600 dark:text-slate-400 bg-slate-100 dark:bg-slate-700/50",
                    Status = "Pending",
                    StatusBadgeClass = "bg-slate-100 dark:bg-slate-700 text-slate-500 dark:text-slate-400"
                },
                new()
                {
                    BookingId = "#BK-9206",
                    PlayerName = "Anna Martinez",
                    PlayerInitials = "AM",
                    Sport = "Tennis",
                    SportBadgeClass = "bg-amber-50 dark:bg-amber-900/30 text-amber-600 dark:text-amber-400",
                    Date = "May 30, 2024",
                    TimeSlot = "09:00 - 10:30",
                    Duration = "90 min",
                    BookingType = "Private Booking",
                    BookingTypeBadgeClass = "text-slate-600 dark:text-slate-400 bg-slate-100 dark:bg-slate-700/50",
                    Status = "Confirmed",
                    StatusBadgeClass = "bg-primary/10 text-primary"
                }
            };
        }
    }
}
