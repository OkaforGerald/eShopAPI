using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.Components.ProductTable
{
    public partial class ProductTable
    {
        [Parameter]
        public List<OrderProducsDto> Products { get; set; } = new List<OrderProducsDto>();

        [Parameter]
        public EventCallback<Guid> OnDeleted { get; set; }

        [Parameter]
        public string StoreId { get; set; }

        [Parameter]
        public string CategoryId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public IJSRuntime Js { get; set; } = null!;

        private void RedirectToUpdate(Guid id)
        {
            var url = Path.Combine("/updateProduct/", id.ToString());
            NavigationManager.NavigateTo(url);
        }

        private async Task Delete(Guid id)
        {
            var product = Products.FirstOrDefault(p => p.Id.Equals(id));
            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Are you sure you want to delete {product!.Name} product?");
            if (confirmed)
            {
                await OnDeleted.InvokeAsync(id);
            }
        }
    }
}