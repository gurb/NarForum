using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models.Category;
using NarForumUser.Client.Models.Section;
using NarForumUser.Client.Pages.Sections.Modal;
using NarForumUser.Client.Services.UI;
using Microsoft.AspNetCore.Components;

namespace NarForumUser.Client.Pages.Sections
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

        [Inject]
        private HttpClient Http { get; set; }
        [Inject] 
        private IConfiguration Configuration { get; set; }


        public List<SectionVM>? Sections { get; private set; }
        public List<CategoryVM>? Categories { get; private set; }

        AddSectionModal? addSectionModal;

        public string Message { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {

            RefreshStateService.RefreshSectionList += Refresh;
            Sections = await SectionService.GetSections();
            Sections = Sections.OrderBy(x => x.OrderIndex).ToList();
            Categories = await CategoryService.GetSectionCategories();
            Categories = Categories.OrderBy(x => x.OrderIndex).ToList();
            await CheckUserImageProfile();
        }

        private async void Refresh()
        {
            Sections = await SectionService.GetSections();
            Sections = Sections.OrderBy(x => x.OrderIndex).ToList();
            Categories = await CategoryService.GetSectionCategories();
            Categories = Categories.OrderBy(x => x.OrderIndex).ToList();
            await CheckUserImageProfile();
            await InvokeAsync(StateHasChanged);
        }

        private void OpenModal()
        {
            addSectionModal?.ShowModal();
        }

        private string GetImageUrl(string userId)
        {
            return $"{Configuration["ApiBaseUrl"]}/file/images/user-profile/{userId}";
        }


        private async Task CheckUserImageProfile()
        {
            if (Categories is not null && Categories.Count > 0)
            {
                foreach (var category in Categories)
                {
                    if (category.LastUserId is not null)
                    {
                        string imageUrl = GetImageUrl(category.LastUserId.ToString());

                        bool isExist = await UrlExists(imageUrl);
                        if (isExist)
                        {
                            category.UserProfileImageUrl = imageUrl;
                        }
                    }
                    else
                    {
                        category.UserProfileImageUrl = null;
                    }
                }
            }
        }

        private async Task<bool> UrlExists(string url)
        {
            try
            {
                var response = await Http.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}