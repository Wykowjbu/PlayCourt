namespace PlayCourt.Application.ViewModels.Business
{
    public class CourtsManagementViewModel
    {
        public List<CourtDto> Courts { get; set; } = new();
    }

    public class CourtDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string SportType { get; set; } = string.Empty;
        public string SportBadgeClass { get; set; } = string.Empty;
        public string RegularRate { get; set; } = string.Empty;
        public string PeakRate { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string StatusText { get; set; } = string.Empty;
        public PricingConfigDto? PricingConfig { get; set; }
        public bool ShowPricingDetails { get; set; }
    }

    public class PricingConfigDto
    {
        public decimal RegularHourlyRate { get; set; }
        public decimal PeakHourlyRate { get; set; }
        public string PeakStartTime { get; set; } = "17:00";
        public string PeakEndTime { get; set; } = "22:00";
        public bool IsPeakActive { get; set; } = true;
    }
}