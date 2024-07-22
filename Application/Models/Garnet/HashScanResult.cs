namespace Identity.Models.DTO
{
    public class HashScanResult
    {
        public int Length { get; set; }
        public Dictionary<string, string>? Hash { get; set; }
        public bool IsSuccess { get; set; }
    }
}
