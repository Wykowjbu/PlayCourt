using Application.ViewModels.Public;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlayCourt.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public HomeViewModel ViewModel { get; set; } = new();

        public void OnGet()
        {
            // TODO: Load data from services
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            // Search Form
            ViewModel.SearchForm = new SearchFormViewModel
            {
                Sport = "Pickleball",
                Location = "Son Tra District",
                DateTime = "Today, 6:00 PM",
                PopularFilters = new List<string> { "Indoor", "Night Lighting", "Pro Coaching", "Equipment Rental" }
            };

            // Recommended Venues
            ViewModel.RecommendedVenues = new List<VenueCardViewModel>
            {
                new VenueCardViewModel
                {
                    Name = "Riverside Tennis Complex",
                    ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuACuiF3JIdtzJCtQ_XIj08QzqcsyhU0mhbtS4sd6DgAfGAtzVtb5pSPLoClSz9SKncU9eU9prL-WKFKdpbwIe7TqenvQV1CaeejR6xr75Esyay1Zsy7Qa10WYZDaX2j5h42-E_l_y2DqQSW_Hl_BFgxkLPBlReQSn5PONHSis_tb2pekg0VmNe8o6QcWyETVNF-zNETsHOir48tgRhHcRgUhy_u5TyWBtWkTPS0mxrmdkBrtcQV4G97kWPFlC-qF3hRhGAiwv2LqwkB",
                    PricePerHour = 14,
                    Rating = 4.9,
                    Distance = "1.2 km",
                    District = "Hai Chau District",
                    BadgeText = "PLAYCOURT FAVORITE",
                    BadgeColor = "primary",
                    IsFavorite = false
                },
                new VenueCardViewModel
                {
                    Name = "Dragon Bridge Badminton",
                    ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuDp6q6oG3BOGM5qDNxHBplfeNkiuWLRpcEaDZn8Y0jR4CgRkDLs_yV-dLdjNPwv1RVc5z9KnXnGw0FsBNRk9bPyKB6oJMeFuHOkDQ5D78Ah7syRGTFXPMKRaP44tfX2qK-SJxxd_uAExD8w6Gh0SxJE1IhmbBfclNigohhJSZmzV8qxVyr_5EVuAX2rOGM7mh1eu-CbXOf4VO_Li_0cYjNweGtfvu2EezHGA_hWw8_RZg1ruXQjxVRyi65D8223mZr4khdN8oiw99TU",
                    PricePerHour = 10,
                    Rating = 4.7,
                    Distance = "2.5 km",
                    District = "Son Tra District",
                    BadgeText = "INDOOR PRO",
                    BadgeColor = "slate-900",
                    IsFavorite = false
                },
                new VenueCardViewModel
                {
                    Name = "Padel Point Da Nang",
                    ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuCloBFSf5xLehhmHsLmun8zEhbqaceouUFdTJs0PNb1UJPePxfk-Em2KFgbUoyhLk3uyCp1ieSEgODgGSJ2q_CvwR4EgR_9XVlok4at9ohcoxUAhuMPe2fkYazMaYgjZjXO51FsAf5Yc__Res_81MBCktzgw_qdwnCrl6PAllPn3v7T2SxgYxkuCBhpuSGs-clB788GCaiRGU7lZRl5E4n_6vhlAbYOoNmk4m0ysjeusTjK5QbX--PRyakD6psP3cqc4FcNvObTL_os",
                    PricePerHour = 18,
                    Rating = 4.8,
                    Distance = "4.1 km",
                    District = "Ngu Hanh Son",
                    BadgeText = "NEW OPENING",
                    BadgeColor = "primary",
                    IsFavorite = false
                }
            };

            // Live Matches
            ViewModel.LiveMatches = new List<MatchmakingCardViewModel>
            {
                new MatchmakingCardViewModel
                {
                    GameType = "Pickleball Doubles",
                    Sport = "Pickleball",
                    SkillLevel = "Level 4.0+",
                    ScheduleTime = "18:30 Today",
                    Players = new List<PlayerAvatarViewModel>
                    {
                        new PlayerAvatarViewModel { AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuD23P82P55QO4SmCwkujimKiGnp2G0aLBIyxC7l9EPBbM90Fj89IB1J-lih70UywNb_S7MDoKJ2cMuDP5AKwVdvyMNAQp_pDBof0Wnn0H8yJNrjjhTvnmOXudiqIz6Z3CaQQgvwIE8TD7t0xKOVdfbNFAfOfFd6f0beFdwNFV9uRFqQ3kJsLvy1OYHckAh-iTZdiDLqf3SGgLKraMYwEIn-cEtsFdq5tx7KV5V7Uv5LJrMvYM5qLWhMv5RIok3TJTznVKHJ1WiBAw3z" },
                        new PlayerAvatarViewModel { AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuA27HZFsP9sQVO36tMgvsQgipu9ScCohvGjhvoeNr4JpFYQ4iPH95sybZ7qci3fn3hieqotmGBLLr3_CeZr_1A_f4OjR65K9EniB4X-BQKVAPXiNet5nLL4HVyf8VfOouDfxkSEu6Gspx4sgdKesHP7n0Thq_Os72F2BS8ved5H6BXsRba27EEMe_Yshk9omJTai_9C1z9R3A9cQWGs9ltN2lNjY_iNecuYNb2wThjh_jVwAO-EhuPSVpF272lHJQMJQWV-xHU1vCnK" }
                    },
                    SpotsLeft = 1,
                    IconColor = "primary",
                    IsHighlighted = false
                },
                new MatchmakingCardViewModel
                {
                    GameType = "Tennis Singles Play",
                    Sport = "Tennis",
                    SkillLevel = "Intermediate",
                    ScheduleTime = "07:00 Tomorrow",
                    Players = new List<PlayerAvatarViewModel>
                    {
                        new PlayerAvatarViewModel { AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuATHh6jp9Mudjeyy4JvBYznCNOgSYvqV2X9xSM0IxvpjARufz26vH-7t5KkqpFUCOJFwfOYgqUG_ZeXI4B3AO66OFik8T6fPRTV14hZbdfhMBSRhNrYnMu6khKCeq8_2HGfSXceRmhHlhezmIBr6e7TllNrb4K_ePZjssvRjGAc6tQZ7TKsPZBWhQxI_vaEsBL0DHRL-KOBbP_-406warZ-j7uvkSUkYxxro3UPAXJI0tmmZSEC6HZ97TcrHdhd9UNuFltK32iLRk1e" }
                    },
                    SpotsLeft = 1,
                    IconColor = "amber",
                    IsHighlighted = false
                },
                new MatchmakingCardViewModel
                {
                    GameType = "Badminton Fun Mix",
                    Sport = "Badminton",
                    SkillLevel = "Open Session",
                    ScheduleTime = "20:00 Today",
                    Players = new List<PlayerAvatarViewModel>
                    {
                        new PlayerAvatarViewModel { AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuBU1BalaiKFhOSsayZpCC2On1KKR5Q1A6JhjxFwu7N--CZCxnF0fKG0lVsf1s-VSfXcKgHvmJIXoWhKWJE552aQIeMbTQGA4LFSjF9rLNbCRtFPBZnAy0YX9619DYvoGp-26BN85APLY7kxeEMNXA-bjCLYdtUEOgve9FVSutaB0u4tdx8O3HnGksjL-sbvxvFjFrhlIIftsnwoJQEZfmd42AqB9mxvmdR-OdT5wlHzZa5lcLZuVIEyfukxMQMYIF7zi05QTvWMw0rz" },
                        new PlayerAvatarViewModel { AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuASDrvlx_-In_j-W2PRAO7NjYyxkTkwvDJScNbbB1QINmnJ7wMWS7iuxRLPmuVfon8RzhzGsceMiGbFCbqHBnWEO3S-eJEe1aalvSzahZd32YkUCbXM30A3ADJk8smckTlDwYSJyQFhfm5ag-Fog23U2vtqqscwy3YijSKyGLhY3WP9yNbZagk1ecCnTPbDrjhjQyqy2zTPf_Shyc5C6iMjAdatPDeijOyDBeJBwWGatH1yER3cFbHrNj9HCal9T0tFdTT6skcV5GCS" }
                    },
                    SpotsLeft = 2,
                    IconColor = "blue",
                    IsHighlighted = false
                },
                new MatchmakingCardViewModel
                {
                    GameType = "Tournament Training",
                    Sport = "Mixed",
                    SkillLevel = "EXPERT LEVEL",
                    ScheduleTime = "21:00 Tonight",
                    Players = new List<PlayerAvatarViewModel>
                    {
                        new PlayerAvatarViewModel { AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuBbJ0mnM1afvLEwCDOJXH7dh3QHFCddVVW-0UT8rGuR__m2JkCCCxmYwKMSk67iY552IxF2ASo00B_Xrj8PBuL6k6Ub2GfVtBt6plfoHUsMSHYArWXUyCbOl_35yTT8WRwSfG79LpERCGMu2XChvAtkUyzmrIgpwJeewKn7sZznIwc0nRZFTWNoOZn5OAlhDUuplZ1V_8YEvKuZF1RUGRptVtIF3dEiZrqGnTm2lXcbEVQ820hwHGOM5Oj38AOHpq8toWDCZkX5Yqyx" },
                        new PlayerAvatarViewModel { AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuBMut5Ujd40GQnZGxOMTi8LPDre2xGL5tZRke9lzRnSB80QW4J6lCvOMkrv7buhuEZSiNwoiLQ2X7iamgC4Ws4mVS45_Ivw32vfjAZKJLjt90SamBr4diTR1qxhkkn2VWd6JGCVkohfvDXTnv3rwydlB4aHSPCmvrBFNQ01y9pq4D6w65E0hkM_OuV5ebvMAPT9-LLKVYVdPXyFIeA38AChbxoJop3_VqJYRDLcJcGLE8cowrtEWjG_t0pb5nWpQRKGzf0Ja2ZLPFRw" },
                        new PlayerAvatarViewModel { AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuCzCkq_TW-dS1ah_Vqrck75na1CpPrzpVUidnqfw2OOKzHk_nkDbOs9ClnmsD-Gg24XJvUfjnlQRHRHPdxfE4LELMWuwgTh398fjSkPQFyn6Ab4CoCHjyLfXEOM9zAayls7FlTJ4KdN0BTzOUjM6nrlr6ZnjYBNi-E6bN-wJvVXsR0J2_7ogVQosV-lEn0OypeoZ0Vbnoj5jU7fJGj_8kRBSYIIU0pRNYAr-EKe8AuwDkYTIUawDshHcFXb8lrFL-Je3HtVYugcAJ1K" }
                    },
                    SpotsLeft = 1,
                    IconColor = "primary",
                    IsHighlighted = true
                }
            };

            // Active Session
            ViewModel.ActiveSession = new ActiveSessionViewModel
            {
                GameType = "Pickleball",
                VenueName = "Son Tra Arena",
                IsActive = true
            };
        }
    }
}
