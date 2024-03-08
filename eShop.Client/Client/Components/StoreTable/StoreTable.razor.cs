using Microsoft.AspNetCore.Components;
using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.Components.StoreTable
{
    public partial class StoreTable
    {
        [Parameter]
        public List<StoresDto> Stores { get; set; } = new List<StoresDto>();

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
    }
}
