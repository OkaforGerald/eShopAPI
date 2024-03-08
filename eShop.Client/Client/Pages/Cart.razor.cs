using eShop.Client.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.Pages
{
    public partial class Cart
    {
        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        public List<CartItemDto> ShoppingCartItems { get; set; }

        [Inject]
        public IJSRuntime Js { get; set; }

        private string TotalPrice { get; set; }
        private int TotalQuantity { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ShoppingCartItems = await ShoppingCartService.GetCart();
            CartChanged();
        }
        protected async Task DeleteCartItem_Click(Guid id)
        {
            var cartItemDto = await ShoppingCartService.DeleteItem(id);

            RemoveCartItem(id);
            CartChanged();

        }

        //protected async Task UpdateQtyCartItem_Click(Guid id, int qty)
        //{
        //    try
        //    {
        //        if (qty > 0)
        //        {
        //            var updateItemDto = new CartItemQtyUpdateDto
        //            {
        //                CartItemId = id,
        //                Qty = qty
        //            };

        //            var returnedUpdateItemDto = await this.ShoppingCartService.UpdateQty(updateItemDto);

        //            await UpdateItemTotalPrice(returnedUpdateItemDto);

        //            CartChanged();

        //            await MakeUpdateQtyButtonVisible(id, false);


        //        }
        //        else
        //        {
        //            var item = this.ShoppingCartItems.FirstOrDefault(i => i.Product.Id == id);

        //            if (item != null)
        //            {
        //                item.Product.Quantity = 1;
        //            }

        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        protected async Task UpdateQty_Input(Guid id)
        {
            await MakeUpdateQtyButtonVisible(id, true);
        }

        private async Task MakeUpdateQtyButtonVisible(Guid id, bool visible)
        {
            await Js.InvokeVoidAsync("MakeUpdateQtyButtonVisible", id, visible);
        }

        private void UpdateItemTotalPrice(ProductsDto cartItemDto)
        {
            var item = GetCartItem(cartItemDto.Id);

            if (item != null)
            {
                item.Product.Price = cartItemDto.Price * cartItemDto.Quantity;
            }
        }
        private void CalculateCartSummaryTotals()
        {
            SetTotalPrice();
            SetTotalQuantity();
        }

        private void SetTotalPrice()
        {
            TotalPrice = this.ShoppingCartItems.Sum(p => p.Product.Price).ToString("C");
        }
        private void SetTotalQuantity()
        {
            TotalQuantity = this.ShoppingCartItems.Sum(p => p.QuantityInCart);
        }

        private CartItemDto GetCartItem(Guid id)
        {
            return ShoppingCartItems.FirstOrDefault(i => i.Product.Id == id);
        }

        private void RemoveCartItem(Guid id)
        {
            var cartItemDto = GetCartItem(id);

            ShoppingCartItems.Remove(cartItemDto);
        }
        private void CartChanged()
        {
            CalculateCartSummaryTotals();
            ShoppingCartService.RaiseEventOnShoppingCartChanged(TotalQuantity);
        }

    }
}
