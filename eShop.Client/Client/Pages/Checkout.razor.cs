using eShop.Client.Client.HttpRepository;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SharedAPI.Data_Transfer;

namespace eShop.Client.Client.Pages
{
	public partial class Checkout
	{
		[Inject]
		public IJSRuntime Js { get; set; }

        protected IEnumerable<CartItemDto> ShoppingCartItems { get; set; }

		protected int TotalQty { get; set; }

		protected string PaymentDescription { get; set; }

		protected decimal PaymentAmount { get; set; }

		[Inject]
		public IShoppingCartService ShoppingCartService { get; set; }

		protected string DisplayButtons { get; set; } = "block";

		protected override async Task OnInitializedAsync()
		{
			try
			{
				ShoppingCartItems = await ShoppingCartService.GetCart();

				if (ShoppingCartItems != null && ShoppingCartItems.Count() > 0)
				{
					Guid orderGuid = Guid.NewGuid();

					PaymentAmount = Math.Round(ShoppingCartItems.Sum(p => p.Product.Price), 2, MidpointRounding.AwayFromZero);
                    TotalQty = ShoppingCartItems.Sum(p => p.Product.Quantity);
					PaymentDescription = $"O_{orderGuid}_{orderGuid}";

				}
				else
				{
					DisplayButtons = "none";
				}

			}
			catch (Exception)
			{
				//Log exception
				throw;
			}
		}

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			try
			{
				if (firstRender)
				{
					await Js.InvokeVoidAsync("initPayPalButton");
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

	}
}
