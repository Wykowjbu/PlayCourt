using Application.ViewModels.Matches;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlayCourt.Pages.Matches
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public MatchListingViewModel ViewModel { get; set; } = new();

        public void OnGet()
        {
            // TODO: Call Application Service to get data
            // Example: ViewModel = await _matchService.GetMatchListingAsync(filters);

            // Initialize dropdown data
            ViewModel.Sports = new List<string>
            {
                "All Racket Sports",
                "Pickleball",
                "Tennis",
                "Badminton"
            };

            ViewModel.Levels = new List<string>
            {
                "Any Level",
                "Beginner",
                "Intermediate+",
                "Advanced",
                "Pro"
            };

            ViewModel.Distances = new List<string>
            {
                "Within 5 km",
                "Within 10 km",
                "All of Da Nang"
            };

            // Sample match data
            ViewModel.LiveMatches = new List<MatchCardViewModel>
            {
                new MatchCardViewModel
                {
                    Id = 1,
                    Title = "Advanced Doubles Play",
                    SportType = "Pickleball",
                    VenueName = "My Khe Arena",
                    StartTimeText = "18:30 Today",
                    SkillLevel = "Intermediate+",
                    PricePerPerson = 8,
                    SpotsLeft = 1,
                    ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuAgQwmRDjIOVAtH52rQtI13iXatljPogfCBinWsE0E5nnLeV5r9otI9FpFDJsgBPdh2ETPyCuOudY6Pk0_aIluYwieV-R7C-y8FpGbg8YXPITjyump-rA6dgbVYdlGK08jQfgtUBbCL84rzSOczzVTI17nrIuuqGsKVV8CT6cx6kK1TsItwgDy1r-KnzozU_WnFXphFI52YYUme05hoOYilNCjEfBgMnDIES5ZJGotjBiW5tu4xH2BbsX0bmKKc19kb_ySjtID171aK",
                    LevelBadgeClass = "bg-amber-50 dark:bg-amber-900/30 text-amber-600 dark:text-amber-400",
                    SportBadgeColor = "bg-primary"
                },
                new MatchCardViewModel
                {
                    Id = 2,
                    Title = "Sunday Morning Singles",
                    SportType = "Tennis",
                    VenueName = "Riverside Complex",
                    StartTimeText = "07:00 Tomorrow",
                    SkillLevel = "Intermediate",
                    PricePerPerson = 12,
                    SpotsLeft = 1,
                    ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuACuiF3JIdtzJCtQ_XIj08QzqcsyhU0mhbtS4sd6DgAfGAtzVtb5pSPLoClSz9SKncU9eU9prL-WKFKdpbwIe7TqenvQV1CaeejR6xr75Esyay1Zsy7Qa10WYZDaX2j5h42-E_l_y2DqQSW_Hl_BFgxkLPBlReQSn5PONHSis_tb2pekg0VmNe8o6QcWyETVNF-zNETsHOir48tgRhHcRgUhy_u5TyWBtWkTPS0mxrmdkBrtcQV4G97kWPFlC-qF3hRhGAiwv2LqwkB",
                    LevelBadgeClass = "bg-blue-50 dark:bg-blue-900/30 text-blue-600 dark:text-blue-400",
                    SportBadgeColor = "bg-blue-500"
                },
                new MatchCardViewModel
                {
                    Id = 3,
                    Title = "Mixed Fun Session",
                    SportType = "Badminton",
                    VenueName = "Dragon Bridge Arena",
                    StartTimeText = "20:00 Tonight",
                    SkillLevel = "Beginner+",
                    PricePerPerson = 5,
                    SpotsLeft = 3,
                    ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuDp6q6oG3BOGM5qDNxHBplfeNkiuWLRpcEaDZn8Y0jR4CgRkDLs_yV-dLdjNPwv1RVc5z9KnXnGw0FsBNRk9bPyKB6oJMeFuHOkDQ5D78Ah7syRGTFXPMKRaP44tfX2qK-SJxxd_uAExD8w6Gh0SxJE1IhmbBfclNigohhJSZmzV8qxVyr_5EVuAX2rOGM7mh1eu-CbXOf4VO_Li_0cYjNweGtfvu2EezHGA_hWw8_RZg1ruXQjxVRyi65D8223mZr4khdN8oiw99TU",
                    LevelBadgeClass = "bg-green-50 dark:bg-green-900/30 text-green-600 dark:text-green-400",
                    SportBadgeColor = "bg-amber-500"
                }
            };

            // Sample statistics
            ViewModel.TotalLiveMatches = 124;
            ViewModel.TotalVenues = 12;
            ViewModel.ActivePlayers = 850;
            ViewModel.AverageRating = 4.9;
        }
    }
}
