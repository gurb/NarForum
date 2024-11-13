using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models.Category;
using NarForumUser.Client.Models.Section;
using NarForumUser.Client.Pages.Sections.Modal;
using NarForumUser.Client.Services.UI;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using NarForumUser.Client.Models.Message;


namespace NarForumUser.Client.Pages.Sections
{
    public partial class SectionList
    {
        private PersistingComponentStateSubscription _subscription;
        public bool min768 { get; set; } = false;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ISectionService SectionService { get; set; }
        [Inject]
        public ICategoryService CategoryService { get; set; }
        [Inject]
        public RefreshStateService RefreshStateService { get; set; }

        [Inject]
        private HttpClient Http { get; set; }
        [Inject] 
        private IConfiguration Configuration { get; set; }


        public List<SectionVM>? Sections { get; private set; }
        public List<CategoryVM>? Categories { get; private set; }

        AddSectionModal? addSectionModal;

        public string Message { get; set; } = string.Empty;

        bool onInit = false;

        protected override async Task OnInitializedAsync()
        {
            _subscription = ApplicationState.RegisterOnPersisting(Persist);
        }

        protected override async Task OnParametersSetAsync()
        {
            RefreshStateService.RefreshSectionList += Refresh;

            await GetSections();
            await GetCategories();

            await CheckUserImageProfile();

            onInit = true;
        }

        private async Task GetSections()
        {
            var foundInState = ApplicationState
                .TryTakeFromJson<List<SectionVM>?>("sections", out var _Sections);

            Sections = foundInState ? _Sections : Sections;

            if (!foundInState)
            {
                Sections = await SectionService.GetSections();
                Sections = Sections.OrderBy(x => x.OrderIndex).ToList();
            }
        }

        private async Task GetCategories()
        {
            var foundInState = ApplicationState
                .TryTakeFromJson<List<CategoryVM>?>("categories", out var _Categories);

            Categories = foundInState ? _Categories : Categories;

            if(!foundInState)
            {
                Categories = await CategoryService.GetSectionCategories();
                Categories = Categories.OrderBy(x => x.OrderIndex).ToList();
            }
        }

        private async void Refresh()
        {
            await GetSections();
            await GetCategories();

            await CheckUserImageProfile();
            await InvokeAsync(StateHasChanged);
        }

        private async Task Persist()
        {
            ApplicationState.PersistAsJson("sections", Sections);
            ApplicationState.PersistAsJson("categories", Categories);
            await Task.CompletedTask;
        }

        private void OpenModal()
        {
            addSectionModal?.ShowModal();
        }

        private string GetImageUrl(string userId)
        {
            return $"user-profile/{userId}";
        }


        private async Task CheckUserImageProfile()
        {
            if (Categories is not null && Categories.Count > 0)
            {
                foreach (var category in Categories)
                {
                    if (category.LastUserId is not null)
                    {
                        category.Base64 = await imageProvider.GetImage($"user-profile/{category.LastUserId.ToString()}");
                    }
                    else
                    {
                        category.Base64 = null;
                    }
                }
            }
        }

        

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}