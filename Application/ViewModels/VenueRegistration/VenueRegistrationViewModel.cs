namespace PlayCourt.Application.ViewModels.VenueRegistration
{
    public class VenueRegistrationViewModel
    {
        public VenueInfoDto VenueInfo { get; set; } = new();
        public List<string> AvailableSportTypes { get; set; } = new();
        public List<AmenityDto> AvailableAmenities { get; set; } = new();
        public RegistrationProgressDto Progress { get; set; } = new();
    }

    public class VenueInfoDto
    {
        public string VenueName { get; set; } = string.Empty;
        public List<string> SelectedSportTypes { get; set; } = new();
        public string Address { get; set; } = string.Empty;
        public string? BusinessLicenseUrl { get; set; }
        public string? LandUseCertificateUrl { get; set; }
        public List<string> SelectedAmenities { get; set; } = new();
        public List<string> PhotoGalleryUrls { get; set; } = new();
    }

    public class AmenityDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsSelected { get; set; }
    }

    public class RegistrationProgressDto
    {
        public int CompletionPercentage { get; set; }
        public List<ProgressStepDto> Steps { get; set; } = new();
    }

    public class ProgressStepDto
    {
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = "pending"; // pending, active, done
        public string Icon { get; set; } = "radio_button_unchecked";
    }
}
