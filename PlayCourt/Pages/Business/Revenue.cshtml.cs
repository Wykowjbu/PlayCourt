using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayCourt.Application.ViewModels.Business;

namespace PlayCourt.WebApp.Pages.Business
{
    public class RevenueModel : PageModel
    {
        public RevenueDashboardViewModel Data { get; set; } = new();

        public void OnGet()
        {
            // MOCK DATA: Replace this with logic from Application Service
            Data = new RevenueDashboardViewModel
            {
                TotalRevenue = "$24,580.00",
                RevenueGrowth = 12.5,
                AvgDailyIncome = "$819.33",
                IncomeGrowth = 3.2,
                TotalBookings = 1422,
                BookingsGrowth = -2.1,
                OccupancyRate = "76.8%",
                OccupancyGrowth = 8.4,
                SportBreakdown = new List<SportRevenueStat>
                {
                    new() { SportName = "Pickleball", Amount = "$11,061", ColorClass = "bg-primary" },
                    new() { SportName = "Tennis", Amount = "$8,603", ColorClass = "bg-blue-500" },
                    new() { SportName = "Badminton", Amount = "$4,916", ColorClass = "bg-amber-500" }
                },
                RecentTransactions = new List<RevenueTransactionDto>
                {
                    new() { TransactionId = "#BK-98210", CustomerName = "Alex Johnson", Sport = "Pickleball", SportBadgeClass = "bg-emerald-50 text-emerald-600", DateTime = "Oct 24, 2023 • 14:00", Amount = "$36.00" },
                    new() { TransactionId = "#BK-98211", CustomerName = "Sarah Williams", Sport = "Tennis", SportBadgeClass = "bg-blue-50 text-blue-600", DateTime = "Oct 24, 2023 • 15:30", Amount = "$45.00" },
                    new() { TransactionId = "#BK-98212", CustomerName = "Mike Chen", Sport = "Badminton", SportBadgeClass = "bg-amber-50 text-amber-600", DateTime = "Oct 24, 2023 • 17:00", Amount = "$24.00" }
                }
            };
        }
    }
}