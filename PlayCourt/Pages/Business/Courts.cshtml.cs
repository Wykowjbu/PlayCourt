using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlayCourt.Application.ViewModels.Business;

namespace PlayCourt.WebApp.Pages.Business
{
    public class CourtsModel : PageModel
    {
        public CourtsManagementViewModel Data { get; set; } = new();

        public void OnGet()
        {
            // MOCK DATA: Replace this with logic from Application Service
            Data = new CourtsManagementViewModel
            {
                Courts = new List<CourtDto>
                {
                    new()
                    {
                        Id = "1",
                        Name = "Court A - Premium",
                        SportType = "Pickleball",
                        SportBadgeClass = "bg-blue-50 dark:bg-blue-900/30 text-blue-600 dark:text-blue-400",
                        RegularRate = "$14.00",
                        PeakRate = "$18.00",
                        IsActive = true,
                        StatusText = "Active",
                        ShowPricingDetails = true, // Show pricing details for first court as example
                        PricingConfig = new PricingConfigDto
                        {
                            RegularHourlyRate = 14.00m,
                            PeakHourlyRate = 18.00m,
                            PeakStartTime = "17:00",
                            PeakEndTime = "22:00",
                            IsPeakActive = true
                        }
                    },
                    new()
                    {
                        Id = "2",
                        Name = "Court B - Standard",
                        SportType = "Tennis",
                        SportBadgeClass = "bg-amber-50 dark:bg-amber-900/30 text-amber-600 dark:text-amber-400",
                        RegularRate = "$12.00",
                        PeakRate = "$15.00",
                        IsActive = false,
                        StatusText = "Maintenance",
                        ShowPricingDetails = false,
                        PricingConfig = new PricingConfigDto
                        {
                            RegularHourlyRate = 12.00m,
                            PeakHourlyRate = 15.00m,
                            PeakStartTime = "17:00",
                            PeakEndTime = "22:00",
                            IsPeakActive = true
                        }
                    }
                }
            };
        }
    }
}