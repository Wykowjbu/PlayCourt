using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Matches
{
    public class CreateMatchRequestViewModel
    {
        [Required(ErrorMessage = "Please select a sport.")]
        public string SelectedSport { get; set; } = "Pickleball";

        [Required(ErrorMessage = "Please enter a venue.")]
        public string Venue { get; set; } = "My Khe Pickleball Arena";

        [Required(ErrorMessage = "Please select date and time.")]
        public string DateTime { get; set; } = "Friday, Oct 27 • 18:30 - 20:30";

        [Range(1, 5, ErrorMessage = "Skill level must be between 1 and 5.")]
        public int MinimumSkillLevel { get; set; } = 3;

        [Range(1, 10, ErrorMessage = "Players needed must be between 1 and 10.")]
        public int PlayersNeeded { get; set; } = 3;

        [Required(ErrorMessage = "Please select a cost sharing mode.")]
        public string CostSharingMode { get; set; } = "Split Equally";

        public List<string> AvailableSports { get; set; } = new();
        public List<string> AvailableVenues { get; set; } = new();

        public string GetSkillLevelText()
        {
            return MinimumSkillLevel switch
            {
                1 => "Beginner (1.0 - 2.5)",
                2 => "Amateur (2.5 - 3.0)",
                3 => "Intermediate (3.5 - 4.5)",
                4 => "Advanced (4.5 - 5.5)",
                5 => "Pro (5.5+)",
                _ => "Intermediate (3.5 - 4.5)"
            };
        }
    }
}
