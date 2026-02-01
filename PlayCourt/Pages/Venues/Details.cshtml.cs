using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.ViewModels.Venues;

namespace PlayCourt.Pages.Venues;

public class DetailsModel : PageModel
{
    public VenueDetailViewModel Data { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        // Giả lập dữ liệu - Thực tế sẽ gọi Mediator/Service từ Application Layer
        Data = new VenueDetailViewModel
        {
            Name = "My Khe Pickleball Arena",
            Address = "Vo Nguyen Giap, Da Nang",
            DistanceInfo = "1.2 km from City Center",
            Rating = 4.9,
            ReviewCount = 128,
            PricePerHour = 15,
            Description = "Experience world-class pickleball at My Khe Arena...",
            Images = new List<string> {
                "https://lh3.googleusercontent.com/aida-public/AB6AXuAgQwmRDjIOVAtH52rQtI13iXatljPogfCBinWsE0E5nnLeV5r9otI9FpFDJsgBPdh2ETPyCuOudY6Pk0_aIluYwieV-R7C-y8FpGbg8YXPITjyump-rA6dgbVYdlGK08jQfgtUBbCL84rzSOczzVTI17nrIuuqGsKVV8CT6cx6kK1TsItwgDy1r-KnzozU_WnFXphFI52YYUme05hoOYilNCjEfBgMnDIES5ZJGotjBiW5tu4xH2BbsX0bmKKc19kb_ySjtID171aK",
                "https://lh3.googleusercontent.com/aida-public/AB6AXuACuiF3JIdtzJCtQ_XIj08QzqcsyhU0mhbtS4sd6DgAfGAtzVtb5pSPLoClSz9SKncU9eU9prL-WKFKdpbwIe7TqenvQV1CaeejR6xr75Esyay1Zsy7Qa10WYZDaX2j5h42-E_l_y2DqQSW_Hl_BFgxkLPBlReQSn5PONHSis_tb2pekg0VmNe8o6QcWyETVNF-zNETsHOir48tgRhHcRgUhy_u5TyWBtWkTPS0mxrmdkBrtcQV4G97kWPFlC-qF3hRhGAiwv2LqwkB",
                "https://lh3.googleusercontent.com/aida-public/AB6AXuDp6q6oG3BOGM5qDNxHBplfeNkiuWLRpcEaDZn8Y0jR4CgRkDLs_yV-dLdjNPwv1RVc5z9KnXnGw0FsBNRk9bPyKB6oJMeFuHOkDQ5D78Ah7syRGTFXPMKRaP44tfX2qK-SJxxd_uAExD8w6Gh0SxJE1IhmbBfclNigohhJSZmzV8qxVyr_5EVuAX2rOGM7mh1eu-CbXOf4VO_Li_0cYjNweGtfvu2EezHGA_hWw8_RZg1ruXQjxVRyi65D8223mZr4khdN8oiw99TU",
                "https://lh3.googleusercontent.com/aida-public/AB6AXuCloBFSf5xLehhmHsLmun8zEhbqaceouUFdTJs0PNb1UJPePxfk-Em2KFgbUoyhLk3uyCp1ieSEgODgGSJ2q_CvwR4EgR_9XVlok4at9ohcoxUAhuMPe2fkYazMaYgjZjXO51FsAf5Yc__Res_81MBCktzgw_qdwnCrl6PAllPn3v7T2SxgYxkuCBhpuSGs-clB788GCaiRGU7lZRl5E4n_6vhlAbYOoNmk4m0ysjeusTjK5QbX--PRyakD6psP3cqc4FcNvObTL_os"
            },
            Amenities = new List<AmenityViewModel> {
                new() { Name = "Free Wi-Fi", Icon = "wifi" },
                new() { Name = "Free Parking", Icon = "local_parking" }
            },
            Reviews = new List<ReviewViewModel> {
                new() { UserName = "Alex Nguyen", Rating = 5, Comment = "The best court!", TimeAgo = "2 days ago", UserAvatar = "https://lh3.googleusercontent.com/aida-public/AB6AXuD23P82P55QO4SmCwkujimKiGnp2G0aLBIyxC7l9EPBbM90Fj89IB1J-lih70UywNb_S7MDoKJ2cMuDP5AKwVdvyMNAQp_pDBof0Wnn0H8yJNrjjhTvnmOXudiqIz6Z3CaQQgvwIE8TD7t0xKOVdfbNFAfOfFd6f0beFdwNFV9uRFqQ3kJsLvy1OYHckAh-iTZdiDLqf3SGgLKraMYwEIn-cEtsFdq5tx7KV5V7Uv5LJrMvYM5qLWhMv5RIok3TJTznVKHJ1WiBAw3z" }
            },
            AvailableDates = Enumerable.Range(22, 6).Select(d => new ScheduleDateViewModel
            {
                Date = new DateTime(2026, 2, d),
                IsSelected = d == 22
            }).ToList(),
            TimeSlots = new List<TimeSlotViewModel> {
                new() { TimeRange = "08:00 - 09:00", Status = "Booked" },
                new() { TimeRange = "09:00 - 10:00", Status = "Available" },
                new() { TimeRange = "10:00 - 11:00", Status = "Available" }
            }
        };

        return Page();
    }
}