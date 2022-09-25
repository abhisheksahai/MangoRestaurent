namespace Mango.Services.WebAPI.Models.Dtos
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }
        public object? Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessage { get; set; }
    }
}