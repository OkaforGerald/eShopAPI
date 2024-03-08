using eShop.Client.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace eShop.Client.Client.Pages
{
    public partial class ProductDetails
    {
        private ProductsDto _product = new ProductsDto();

        [Parameter]
        public string StoreID { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IProductHttpRepository ProductRepo { get; set; } = null!;

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _product = await ProductRepo.GetProduct(new Guid(StoreID), Id);
        }

        private async Task AddToCart_Click(Guid Id)
        {
            await ShoppingCartService.AddtoCart(new Guid(StoreID), Id.ToString());

            navigationManager.NavigateTo("cart");
        }
    }
}
