using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Matches
{
    public class CreateMatchRequestViewModel
    {
        [Required(ErrorMessage = "Please select a sport.")]
        public string SelectedSport { get; set; }

        [Required(ErrorMessage = "Please enter a venue.")]
        public string Venue { get; set; }

        [Required(ErrorMessage = "Please select date and time.")]
        public string DateTime { get; set; }

        [Range(1, 5, ErrorMessage = "Skill level must be between 1 and 5.")]
        public int MinimumSkillLevel { get; set; }

        [Range(1, 10, ErrorMessage = "Players needed must be between 1 and 10.")]
        public int PlayersNeeded { get; set; }

        [Required(ErrorMessage = "Please select a cost sharing mode.")]
        public string CostSharingMode { get; set; }

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
