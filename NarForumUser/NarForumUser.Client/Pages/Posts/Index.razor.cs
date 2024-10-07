using NarForumUser.Client.Contracts;
using NarForumUser.Client.Models.Post;
using Microsoft.AspNetCore.Components;

namespace NarForumUser.Client.Pages.Posts
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IPostService PostService { get; set; }

        public List<PostVM> Posts { get; private set; }

        public string Message { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Posts = await PostService.GetPosts();
        }

    }
}