namespace Application.ViewModels
{
    public class ResultViewModelResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Errors { get; set; }
    }
}