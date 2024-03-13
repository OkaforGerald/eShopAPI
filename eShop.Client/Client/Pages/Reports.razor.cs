using eShop.Client.Client.AuthProviders;
using eShop.Client.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.Pages
{
    public partial class Reports
    {
        public List<OrderProductDto> OrderList { get; set; } = new List<OrderProductDto>();

        [Inject]
        public IShoppingCartService CartService { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            OrderList = await CartService.GetOrders();
        }
    }
}
