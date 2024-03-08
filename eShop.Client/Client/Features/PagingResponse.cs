using SharedAPI.Request_Features;

namespace eShop.Client.Client.Features
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; } = new List<T>();
        public Metadata MetaData { get; set; }
    }
}