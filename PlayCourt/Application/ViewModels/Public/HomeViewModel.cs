namespace Application.ViewModels.Public
{
    public class HomeViewModel
    {
        public SearchFormViewModel SearchForm { get; set; } = new();
        public List<VenueCardViewModel> RecommendedVenues { get; set; } = new();
        public List<MatchmakingCardViewModel> LiveMatches { get; set; } = new();
        public ActiveSessionViewModel? ActiveSession { get; set; }
    }

    public class SearchFormViewModel
    {
        public string Sport { get; set; } = "Pickleball";
        public string Location { get; set; } = "Son Tra District";
        public string DateTime { get; set; } = "Today, 6:00 PM";
        public List<string> PopularFilters { get; set; } = new() 
        { 
            "Indoor", 
            "Night Lighting", 
            "Pro Coaching", 
            "Equipment Rental" 
        };
    }

    public class VenueCardViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal PricePerHour { get; set; }
        public double Rating { get; set; }
        public string Distance { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string BadgeText { get; set; } = string.Empty;
        public string BadgeColor { get; set; } = "primary"; // primary, slate, amber
        public bool IsFavorite { get; set; }
    }

    public class MatchmakingCardViewModel
    {
        public string GameType { get; set; } = string.Empty;
        public string Sport { get; set; } = string.Empty; // Pickleball, Tennis, Badminton
        public string SkillLevel { get; set; } = string.Empty;
        public string ScheduleTime { get; set; } = string.Empty;
        public List<PlayerAvatarViewModel> Players { get; set; } = new();
        public int SpotsLeft { get; set; }
        public string IconColor { get; set; } = "primary"; // primary, amber, blue
        public bool IsHighlighted { get; set; }
    }

    public class PlayerAvatarViewModel
    {
        public string AvatarUrl { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public class ActiveSessionViewModel
    {
        public string GameType { get; set; } = string.Empty;
        public string VenueName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}