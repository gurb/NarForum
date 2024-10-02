namespace GurbForumUser.Client.Models
{
    public class ApiResponseVM
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public object? Result { get; set; }
    }
}
