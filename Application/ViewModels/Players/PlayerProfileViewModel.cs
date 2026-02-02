using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Players
{
    public class PlayerProfileViewModel
    {
        // Header Info
        public string FullName { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public bool IsVerified { get; set; }

        // Personal Info Form
        public string PhoneNumber { get; set; }
        public string SelectedDistrict { get; set; }
        public List<string> AvailableDistricts { get; set; } = new List<string>();

        // Proficiency
        public List<SportProficiencyViewModel> Sports { get; set; } = new List<SportProficiencyViewModel>();
    }

    public class SportProficiencyViewModel
    {
        public string SportName { get; set; }
        public string IconName { get; set; } // e.g., "sports_tennis"
        public string IconColorClass { get; set; } // e.g., "text-orange-600"
        public string BgColorClass { get; set; } // e.g., "bg-orange-100"
        public string StatusText { get; set; }
        public string CurrentLevel { get; set; } // Beginner, Intermediate, Advanced
    }
}
