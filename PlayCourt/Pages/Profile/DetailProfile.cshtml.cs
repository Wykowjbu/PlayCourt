using Application.ViewModels.Players;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlayCourt.Pages.Profile
{
    public class DetailProfileModel : PageModel
    {
        [BindProperty]
        public PlayerProfileViewModel ViewModel { get; set; }

        public void OnGet()
        {
            // MOCK DATA - Represents data retrieved from Application Service
            ViewModel = new PlayerProfileViewModel
            {
                FullName = "John Doe",
                Email = "johndoe.sports@playcourt.com",
                AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuA-bHombTWkjJ2f4nOUJ3CdtKiGxf6txkfTZLvnlx8T94du3370O8LRR28dEJQ55V4nneK22jHg06GelcAgvVHULjg3aRo2Rv0-02WTCHiIqXda0LwyE38YIwHoXaEqOp8hFhXPG00Hd06_iKyZ1mxwRpsQZ9YBQJU5J_iWtYsS2JQTtCH24VcnIB1IY1z9l3iOTqz7es1-Tv7nucCp6hRDYWAmki8JSsWwnqzO5RmA_SKNRvfiooFx6YuxhAYmesIxZj4StF8DLVvG",
                IsVerified = true,
                PhoneNumber = "0901234567",

                // Address Data
                SelectedDistrict = "Ngu Hanh Son",
                SelectedWard = "My An",
                StreetAddress = "45 Le Van Hien",

                // Dropdown Data
                AvailableDistricts = new List<string> { "Hai Chau", "Ngu Hanh Son", "Son Tra", "Thanh Khe", "Lien Chieu", "Cam Le", "Hoa Vang" },
                AvailableWards = new List<string> { "My An", "Khue My", "Hoa Quy", "Hoa Hai" }, // Mocked for 'Ngu Hanh Son'

                Sports = new List<SportProficiencyViewModel>
                {
                    new SportProficiencyViewModel {
                        SportName = "Badminton",
                        StatusText = "Personalized matching active",
                        IconName = "sports_tennis",
                        BgColorClass = "bg-orange-100",
                        IconColorClass = "text-orange-600",
                        CurrentLevel = "Intermediate"
                    },
                    new SportProficiencyViewModel {
                        SportName = "Tennis",
                        StatusText = "Skill verification pending",
                        IconName = "sports_tennis",
                        BgColorClass = "bg-green-100",
                        IconColorClass = "text-green-600",
                        CurrentLevel = "Beginner"
                    },
                    new SportProficiencyViewModel {
                        SportName = "Pickleball",
                        StatusText = "Join the PlayCourt community",
                        IconName = "sports_cricket",
                        BgColorClass = "bg-blue-100",
                        IconColorClass = "text-blue-600",
                        CurrentLevel = "Beginner"
                    }
                }
            };
        }

        public void OnPost()
        {
            // Logic Save Profile sẽ gọi xuống Application Layer
        }
    }
}
