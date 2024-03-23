using eShop.Client.Client.HttpRepository;
using eShop.Client.Client.Shared;
using Microsoft.AspNetCore.Components;
using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.Pages
{
    public partial class CreateProduct
    {
        private ProductModifyingDto _product = new ProductModifyingDto();
        private List<CategoryDto> categories = new List<CategoryDto>();
        private SuccessNotification _notification = null!;

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IProductHttpRepository ProductRepo { get; set; }

        [Inject]
        public ICategoryRepository CategoryRepo { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            categories = await CategoryRepo.GetCategories();
        }

        private async Task Create()
        {
            await ProductRepo.CreateProduct(_product, Id);
            navigationManager.NavigateTo($"store/{Id}/products");
        }

        private void AssignImageUrl(string imgUrl) => _product.ImageUrl = imgUrl;
    }
}