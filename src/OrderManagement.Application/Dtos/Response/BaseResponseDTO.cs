namespace OrderManagement.Application.Dtos.Response
{
    public class BaseResponseDTO
    {
        public long Id { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
