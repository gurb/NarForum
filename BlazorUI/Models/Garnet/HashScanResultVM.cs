namespace BlazorUI.Models.Garnet
{
    public class HashScanResultVM
    {
        public int Length { get; set; }
        public Dictionary<string, string>? Hash { get; set; }
        public bool IsSuccess { get; set; }
    }
}
