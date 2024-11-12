using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiCareSystem.BussinessObject;
using KoiCareSystem.Service.Interfaces;
using KoiCareSystem.Service;

namespace KoiCareSystem.Pages.OrderDetailPage
{
    public class IndexModel : PageModel
    {
        private readonly IOrderDetailService _orderDetailService;

        public IndexModel(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        public IList<OrderDetail> OrderDetails { get; set; } = default!;

        public async Task OnGetAsync()
        {
            OrderDetails = await _orderDetailService.GetAllOrderDetailsAsync();
        }
    }
}
