namespace Application.ViewModels.Matches
{
    public class MatchListingViewModel
    {
        public string SelectedSport { get; set; } = "Pickleball";
        public string SelectedLevel { get; set; } = "Intermediate+";
        public string SelectedDistance { get; set; } = "Within 10 km";

        public List<string> Sports { get; set; } = new();
        public List<string> Levels { get; set; } = new();
        public List<string> Distances { get; set; } = new();

        public List<MatchCardViewModel> LiveMatches { get; set; } = new();

        public int TotalLiveMatches { get; set; }
        public int TotalVenues { get; set; }
        public int ActivePlayers { get; set; }
        public double AverageRating { get; set; }
    }

    public class MatchCardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string SportType { get; set; } = string.Empty;
        public string VenueName { get; set; } = string.Empty;
        public string StartTimeText { get; set; } = string.Empty;
        public string SkillLevel { get; set; } = string.Empty;
        public decimal PricePerPerson { get; set; }
        public int SpotsLeft { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string LevelBadgeClass { get; set; } = string.Empty;
        public string SportBadgeColor { get; set; } = string.Empty;
    }
}
