using eShop.Client.Client.HttpRepository;
using eShop.Client.Client.Shared;
using Microsoft.AspNetCore.Components;
using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.Pages
{
    public partial class CreateProduct
    {
        private ProductModifyingDto _product = new ProductModifyingDto();
        private SuccessNotification _notification = null!;

        [Inject]
        public IProductHttpRepository ProductRepo { get; set; }

        private async Task Create()
        {
            await ProductRepo.CreateProduct(_product);
            _notification.Show();
        }

        private void AssignImageUrl(string imgUrl) => new ProductsDto().ImageUrl = imgUrl;
    }
}