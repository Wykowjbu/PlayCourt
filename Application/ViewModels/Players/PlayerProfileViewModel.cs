using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Players
{
    public class PlayerProfileViewModel
    {
        // Header & Basic Info
        public string FullName { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public bool IsVerified { get; set; }
        public string PhoneNumber { get; set; }

        // Detailed Address Logic
        public string SelectedDistrict { get; set; }
        public string SelectedWard { get; set; }
        public string StreetAddress { get; set; } // House Number + Street Name

        // Select Lists
        public List<string> AvailableDistricts { get; set; } = new List<string>();
        public List<string> AvailableWards { get; set; } = new List<string>(); // Should be loaded based on District

        // Proficiency
        public List<SportProficiencyViewModel> Sports { get; set; } = new List<SportProficiencyViewModel>();
    }

    public class SportProficiencyViewModel
    {
        public string SportName { get; set; }
        public string IconName { get; set; }
        public string IconColorClass { get; set; }
        public string BgColorClass { get; set; }
        public string StatusText { get; set; }
        public string CurrentLevel { get; set; }
    }
}
