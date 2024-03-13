using Microsoft.AspNetCore.Components;
using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.Components.OrderTable
{
    public partial class OrderTable
    {
        [Parameter]
        public List<OrderProductDto> Orders { get; set; } = new List<OrderProductDto>();

        [Parameter]
        public string Username { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
    }
}
