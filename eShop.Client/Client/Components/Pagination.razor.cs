﻿using eShop.Client.Client.Features;
using Microsoft.AspNetCore.Components;
using SharedAPI.Request_Features;

namespace eShop.Client.Client.Components
{
    public partial class Pagination
    {
        [Parameter]
        public Metadata MetaData { get; set; }

        [Parameter]
        public int Spread { get; set; }

        [Parameter]
        public EventCallback<int> SelectedPage { get; set; }

        private List<PagingLink> _links;

        protected override void OnParametersSet()
        {
            CreatePaginationLinks();
        }

        private void CreatePaginationLinks()
        {
            _links = new List<PagingLink>
            {
                new PagingLink(MetaData.CurrentPage - 1, MetaData.HasPrevious, "Previous")
            };

            for (int i = 1; i <= MetaData.TotalPages; i++)
            {
                if (i >= MetaData.CurrentPage - Spread && i <= MetaData.CurrentPage + Spread)
                {
                    _links.Add(new PagingLink(i, true, i.ToString()) { Active = MetaData.CurrentPage == i });
                }
            }

            _links.Add(new PagingLink(MetaData.CurrentPage + 1, MetaData.HasNext, "Next"));
        }

        private async Task OnSelectedPage(PagingLink link)
        {
            if (link.Page == MetaData.CurrentPage || !link.Enabled)
                return;

            MetaData.CurrentPage = link.Page;
            await SelectedPage.InvokeAsync(link.Page);
        }
    }
}