using eShop.Client.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata;
using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.Pages
{
    public partial class CreateStore
    {
        private CreateStoreDto _store = new CreateStoreDto();

        [Inject]
        public IStoreService storeService { get; set; }

        [Inject]
        public NavigationManager navManager { get; set; }

        private async Task Create()
        {
            await storeService.CreateStore(_store);

            navManager.NavigateTo("/stores");
        }
    }
}
