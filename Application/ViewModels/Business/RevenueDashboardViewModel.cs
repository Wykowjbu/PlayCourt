namespace PlayCourt.Application.ViewModels.Business
{
    public class RevenueDashboardViewModel
    {
        public string TotalRevenue { get; set; } = "$0.00";
        public double RevenueGrowth { get; set; }

        public string AvgDailyIncome { get; set; } = "$0.00";
        public double IncomeGrowth { get; set; }

        public int TotalBookings { get; set; }
        public double BookingsGrowth { get; set; } // Negative indicates decrease

        public string OccupancyRate { get; set; } = "0%";
        public double OccupancyGrowth { get; set; }

        public List<SportRevenueStat> SportBreakdown { get; set; } = new();
        public List<RevenueTransactionDto> RecentTransactions { get; set; } = new();
    }

    public class SportRevenueStat
    {
        public string SportName { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public string ColorClass { get; set; } = string.Empty; // e.g., bg-primary, bg-blue-500
    }

    public class RevenueTransactionDto
    {
        public string TransactionId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Sport { get; set; } = string.Empty;
        public string SportBadgeClass { get; set; } = string.Empty; // e.g., bg-emerald-50 text-emerald-600
        public string DateTime { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
    }
}