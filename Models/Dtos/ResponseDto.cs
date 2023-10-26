namespace MediPortal_Hospital.Models.Dtos
{
    public class ResponseDto
    {
        public object? obj { get; set; }

        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = true;

    }
}
