using BlazorUI.Contracts;
using BlazorUI.Models.Category;
using BlazorUI.Models.Section;
using BlazorUI.Services.UI;
using Microsoft.AspNetCore.Components;

namespace BlazorUI.Pages.Sections
{
    public partial class SectionList
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ISectionService SectionService { get; set; }
        [Inject]
        public ICategoryService CategoryService { get; set; }
        [Inject]
        public RefreshStateService RefreshStateService { get; set; }
        public List<SectionVM>? Sections { get; private set; }
        public List<CategoryVM>? Categories { get; private set; }



        public string Message { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {

            RefreshStateService.RefreshSectionList += Refresh;
            Sections = await SectionService.GetSections();
            Categories = await CategoryService.GetSectionCategories();
        }

        private async void Refresh()
        {
            Sections = await SectionService.GetSections();
            Categories = await CategoryService.GetSectionCategories();
            await InvokeAsync(StateHasChanged);
        }
    }
}