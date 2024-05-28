namespace AdminUI.Models.User
{
    public class UsersPaginationQueryVM
    {
        public string? UserName { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
