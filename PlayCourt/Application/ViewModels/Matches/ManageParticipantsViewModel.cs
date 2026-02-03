namespace Application.ViewModels.Matches
{
    public class ManageParticipantsViewModel
    {
        public MatchInfoViewModel MatchInfo { get; set; } = new();
        public List<JoinRequestViewModel> JoinRequests { get; set; } = new();
        public List<ConfirmedPlayerViewModel> ConfirmedPlayers { get; set; } = new();
        public int TotalSlots { get; set; }
        public int FilledSlots { get; set; }
    }

    public class MatchInfoViewModel
    {
        public int MatchId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string SportType { get; set; } = string.Empty;
        public string DateTime { get; set; } = string.Empty;
        public string VenueName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public double MinimumLevel { get; set; }
        public int CurrentPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class JoinRequestViewModel
    {
        public int RequestId { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public double PlayerLevel { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class ConfirmedPlayerViewModel
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public double PlayerLevel { get; set; }
        public bool IsHost { get; set; }
    }
}
