using eShop.Client.Client.HttpRepository;
using eShop.Client.Client.Shared;
using Microsoft.AspNetCore.Components;
using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.Pages
{
    public partial class UpdateProduct
    {
        private ProductsDto _product;
        private SuccessNotification _notification;

        [Inject]
        private IProductHttpRepository ProductRepo { get; set; } = null!;

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _product = await ProductRepo.GetProduct(new Guid(), Id);
        }

        private async Task Update()
        {
            await ProductRepo.UpdateProduct(new ProductModifyingDto());
            _notification.Show();
        }

        private void AssignImageUrl(string imgUrl) => _product.ImageUrl = imgUrl;
    }
}