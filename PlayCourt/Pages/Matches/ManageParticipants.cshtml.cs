using Application.ViewModels.Matches;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PlayCourt.Pages.Matches
{
    public class ManageParticipantsModel : PageModel
    {
        public ManageParticipantsViewModel ViewModel { get; set; } = new();

        public void OnGet(int matchId)
        {
            // TODO: Load data from Application Service
            // Example: ViewModel = await _matchService.GetManageParticipantsDataAsync(matchId);

            // Sample data for demonstration
            ViewModel = new ManageParticipantsViewModel
            {
                TotalSlots = 4,
                FilledSlots = 3,
                MatchInfo = new MatchInfoViewModel
                {
                    MatchId = matchId,
                    Title = "Evening Smash @ My Khe Arena",
                    SportType = "Pickleball Doubles",
                    DateTime = "Today, 18:30",
                    VenueName = "My Khe Arena",
                    ImageUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuAgQwmRDjIOVAtH52rQtI13iXatljPogfCBinWsE0E5nnLeV5r9otI9FpFDJsgBPdh2ETPyCuOudY6Pk0_aIluYwieV-R7C-y8FpGbg8YXPITjyump-rA6dgbVYdlGK08jQfgtUBbCL84rzSOczzVTI17nrIuuqGsKVV8CT6cx6kK1TsItwgDy1r-KnzozU_WnFXphFI52YYUme05hoOYilNCjEfBgMnDIES5ZJGotjBiW5tu4xH2BbsX0bmKKc19kb_ySjtID171aK",
                    MinimumLevel = 4.0,
                    CurrentPlayers = 3,
                    MaxPlayers = 4,
                    Status = "Active Hosting"
                },
                JoinRequests = new List<JoinRequestViewModel>
                {
                    new JoinRequestViewModel
                    {
                        RequestId = 1,
                        PlayerName = "Nguyen Minh Anh",
                        AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuD23P82P55QO4SmCwkujimKiGnp2G0aLBIyxC7l9EPBbM90Fj89IB1J-lih70UywNb_S7MDoKJ2cMuDP5AKwVdvyMNAQp_pDBof0Wnn0H8yJNrjjhTvnmOXudiqIz6Z3CaQQgvwIE8TD7t0xKOVdfbNFAfOfFd6f0beFdwNFV9uRFqQ3kJsLvy1OYHckAh-iTZdiDLqf3SGgLKraMYwEIn-cEtsFdq5tx7KV5V7Uv5LJrMvYM5qLWhMv5RIok3TJTznVKHJ1WiBAw3z",
                        PlayerLevel = 4.2,
                        Message = "Hey! Looking for a competitive game tonight. I've been playing for 3 years."
                    },
                    new JoinRequestViewModel
                    {
                        RequestId = 2,
                        PlayerName = "Tran Duy",
                        AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuA27HZFsP9sQVO36tMgvsQgipu9ScCohvGjhvoeNr4JpFYQ4iPH95sybZ7qci3fn3hieqotmGBLLr3_CeZr_1A_f4OjR65K9EniB4X-BQKVAPXiNet5nLL4HVyf8VfOouDfxkSEu6Gspx4sgdKesHP7n0Thq_Os72F2BS8ved5H6BXsRba27EEMe_Yshk9omJTai_9C1z9R3A9cQWGs9ltN2lNjY_iNecuYNb2wThjh_jVwAO-EhuPSVpF272lHJQMJQWV-xHU1vCnK",
                        PlayerLevel = 4.5,
                        Message = "Ready to fill the last spot! Available any time."
                    }
                },
                ConfirmedPlayers = new List<ConfirmedPlayerViewModel>
                {
                    new ConfirmedPlayerViewModel
                    {
                        PlayerId = 1,
                        PlayerName = "You",
                        AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuDZlakN2MC51c9GaB_AFnycv7JLczn6ECUPKueHD2dEWwuGBtx-x9-cknVRP_ouECC7c4RAwFUSceY_cHIDsPSEQ6DaSWJmM3PJ9svepU55bMRTZCfppywAIbiQlVKztTqWqJjFfRqbrb59V8dRuJOoAkukuWMyyjhHv5dnQ1657MKHBB3rYNyIRseJX3hJu0lo2lvJ9E7BfySU58OP5LIk5sUPJ6A6vmR_p2-vv1VikyeTqhZ8B_GfU4AbAwA25hmc30f9CrO7vDGU",
                        PlayerLevel = 4.0,
                        IsHost = true
                    },
                    new ConfirmedPlayerViewModel
                    {
                        PlayerId = 2,
                        PlayerName = "Linh Pham",
                        AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuATHh6jp9Mudjeyy4JvBYznCNOgSYvqV2X9xSM0IxvpjARufz26vH-7t5KkqpFUCOJFwfOYgqUG_ZeXI4B3AO66OFik8T6fPRTV14hZbdfhMBSRhNrYnMu6khKCeq8_2HGfSXceRmhHlhezmIBr6e7TllNrb4K_ePZjssvRjGAc6tQZ7TKsPZBWhQxI_vaEsBL0DHRL-KOBbP_-406warZ-j7uvkSUkYxxro3UPAXJI0tmmZSEC6HZ97TcrHdhd9UNuFltK32iLRk1e",
                        PlayerLevel = 3.8,
                        IsHost = false
                    },
                    new ConfirmedPlayerViewModel
                    {
                        PlayerId = 3,
                        PlayerName = "Hoang Le",
                        AvatarUrl = "https://lh3.googleusercontent.com/aida-public/AB6AXuBU1BalaiKFhOSsayZpCC2On1KKR5Q1A6JhjxFwu7N--CZCxnF0fKG0lVsf1s-VSfXcKgHvmJIXoWhKWJE552aQIeMbTQGA4LFSjF9rLNbCRtFPBZnAy0YX9619DYvoGp-26BN85APLY7kxeEMNXA-bjCLYdtUEOgve9FVSutaB0u4tdx8O3HnGksjL-sbvxvFjFrhlIIftsnwoJQEZfmd42AqB9mxvmdR-OdT5wlHzZa5lcLZuVIEyfukxMQMYIF7zi05QTvWMw0rz",
                        PlayerLevel = 4.1,
                        IsHost = false
                    }
                }
            };
        }

        public async Task<IActionResult> OnPostAcceptAsync(int requestId)
        {
            // TODO: Call Application Service to accept join request
            // Example: await _matchService.AcceptJoinRequestAsync(requestId);

            TempData["SuccessMessage"] = "Player accepted successfully!";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeclineAsync(int requestId)
        {
            // TODO: Call Application Service to decline join request
            // Example: await _matchService.DeclineJoinRequestAsync(requestId);

            TempData["InfoMessage"] = "Request declined.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveAsync(int playerId)
        {
            // TODO: Call Application Service to remove player
            // Example: await _matchService.RemovePlayerAsync(playerId);

            TempData["InfoMessage"] = "Player removed from match.";
            return RedirectToPage();
        }
    }
}
