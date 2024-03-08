using eShop.Client.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace eShop.Client.Client.Pages
{
    public partial class Store
    {
        public List<StoresDto> StoreList { get; set; } = new List<StoresDto>();
        public Metadata MetaData { get; set; } = new Metadata();

        private StoreParameters _storeParameters = new StoreParameters();

        [Inject]
        public IStoreService StoreService { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            await GetProducts();
        }

        private async Task SelectedPage(int page)
        {
            _storeParameters.PageNumber = page;
            await GetProducts();
        }

        private async Task GetProducts()
        {
            var pagingResponse = await StoreService.GetStores(_storeParameters);
            StoreList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }

        private async Task SearchChanged(string searchTerm)
        {
            Console.WriteLine(searchTerm);
            _storeParameters.PageNumber = 1;
            _storeParameters.searchTerm = searchTerm;
            await GetProducts();
        }

        private async Task SortChanged(string orderBy)
        {
            Console.WriteLine(orderBy);
            _storeParameters.orderBy = orderBy;
            await GetProducts();
        }

        private async Task DeleteProduct(Guid id)
        {
            //await Store.DeleteProduct(id);
            _storeParameters.PageNumber = 1;
            await GetProducts();
        }
    }
}
