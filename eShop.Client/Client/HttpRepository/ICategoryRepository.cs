using eShop.Client.Client.Features;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace eShop.Client.Client.HttpRepository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetCategories();

        Task<PagingResponse<OrderProducsDto>> GetProductsByCategory(Guid Id, ProductParameters productParameters);

	}
}
