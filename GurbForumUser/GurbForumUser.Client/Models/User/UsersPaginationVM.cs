namespace GurbForumUser.Client.Models.User
{
    public class UsersPaginationVM
    {
        public List<UserInfoVM>? Users { get; set; }
        public int TotalCount { get; set; }
    }
}
