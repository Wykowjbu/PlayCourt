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
            // MOCK DATA - Trong thực tế sẽ gọi Service/Mediator
            ViewModel = new PlayerProfileViewModel
            {
                FullName = "John Doe",
                Email = "johndoe.sports@playcourt.com",
                AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuA-bHombTWkjJ2f4nOUJ3CdtKiGxf6txkfTZLvnlx8T94du3370O8LRR28dEJQ55V4nneK22jHg06GelcAgvVHULjg3aRo2Rv0-02WTCHiIqXda0LwyE38YIwHoXaEqOp8hFhXPG00Hd06_iKyZ1mxwRpsQZ9YBQJU5J_iWtYsS2JQTtCH24VcnIB1IY1z9l3iOTqz7es1-Tv7nucCp6hRDYWAmki8JSsWwnqzO5RmA_SKNRvfiooFx6YuxhAYmesIxZj4StF8DLVvG",
                IsVerified = true,
                PhoneNumber = "0901234567",
                SelectedDistrict = "Ngu Hanh Son",
                AvailableDistricts = new List<string> { "Hai Chau", "Ngu Hanh Son", "Son Tra", "Thanh Khe", "Lien Chieu", "Cam Le" },
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
            // Logic Save Profile sẽ gọi xuống Application Layer tại đây
            // Redirect hoặc hiển thị thông báo thành công
        }
    }
}
