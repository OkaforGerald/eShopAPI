using eShop.Client.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace eShop.Client.Client.Pages
{
    public partial class CategoryProducts
    {
        public List<ProductsDto> ProductList { get; set; } = new List<ProductsDto>();
        public Metadata MetaData { get; set; } = new Metadata();

        private ProductParameters _productParameters = new ProductParameters();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public ICategoryRepository CategoryRepo { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            await GetProducts();
        }

        protected override async Task OnParametersSetAsync()
        {
            await GetProducts();
        }

        private async Task SelectedPage(int page)
        {
            _productParameters.PageNumber = page;
            await GetProducts();
        }

        private async Task GetProducts()
        {
            var pagingResponse = await CategoryRepo.GetProductsByCategory(new Guid(Id), _productParameters);
            ProductList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }

        private async Task SearchChanged(string searchTerm)
        {
            Console.WriteLine(searchTerm);
            _productParameters.PageNumber = 1;
            _productParameters.searchTerm = searchTerm;
            await GetProducts();
        }

        private async Task SortChanged(string orderBy)
        {
            Console.WriteLine(orderBy);
            _productParameters.orderBy = orderBy;
            await GetProducts();
        }

        private async Task DeleteProduct(Guid id)
        {
            //await CategoryRepo.DeleteProduct(id);
            _productParameters.PageNumber = 1;
            await GetProducts();
        }
    }
}
