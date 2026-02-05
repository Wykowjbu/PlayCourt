namespace PlayCourt.Application.ViewModels.VenueRegistration
{
    public class PricingConfigurationViewModel
    {
        public string CourtName { get; set; } = "Court #1 (Main Clay Court)";
        public decimal BaseHourlyRate { get; set; }
        public bool EnableWeekendPricing { get; set; }
        public decimal? WeekendRate { get; set; }
        public List<PeakHourSlotDto> PeakHourSlots { get; set; } = new();
        public RegistrationProgressDto Progress { get; set; } = new();
    }

    public class PeakHourSlotDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal PeakRate { get; set; }
    }
}
