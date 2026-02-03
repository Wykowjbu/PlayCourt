using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayCourt.Application.ViewModels.Business;

namespace PlayCourt.WebApp.Pages.Business
{
    public class ScheduleModel : PageModel
    {
        public BookingsManagementViewModel Data { get; set; } = new();

        public void OnGet()
        {
            // MOCK DATA: Replace this with logic from Application Service
            Data = new BookingsManagementViewModel
            {
                Bookings = new List<BookingDto>
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
                    }
                },
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
                    CurrentPage = 1,
                    TotalItems = 42,
                    ItemsPerPage = 3
                }
            };
        }
    }
}
