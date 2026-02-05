using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayCourt.Application.ViewModels.VenueRegistration;

namespace PlayCourt.WebApp.Pages.Venue
{
    public class PricingModel : PageModel
    {
        public PricingConfigurationViewModel Data { get; set; } = new();

        public void OnGet()
        {
            // MOCK DATA: Replace with actual service
            Data = new PricingConfigurationViewModel
            {
                CourtName = "Court #1 (Main Clay Court)",
                BaseHourlyRate = 25.00m,
                EnableWeekendPricing = false,
                PeakHourSlots = new List<PeakHourSlotDto>
                {
                    new()
                    {
                        StartTime = new TimeOnly(17, 0),
                        EndTime = new TimeOnly(22, 0),
                        PeakRate = 35.00m
                    },
                    new()
                    {
                        StartTime = new TimeOnly(6, 0),
                        EndTime = new TimeOnly(9, 0),
                        PeakRate = 30.00m
                    }
                },
                Progress = new RegistrationProgressDto
                {
                    CompletionPercentage = 75,
                    Steps = new List<ProgressStepDto>
                    {
                        new() { Name = "Venue Identity", Status = "done", Icon = "check_circle" },
                        new() { Name = "Facility Setup", Status = "done", Icon = "check_circle" },
                        new() { Name = "Pricing Configuration", Status = "active", Icon = "radio_button_checked" },
                        new() { Name = "Business Verification", Status = "pending", Icon = "radio_button_unchecked" }
                    }
                }
            };
        }
    }
}
