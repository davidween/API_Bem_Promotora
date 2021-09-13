namespace Application.ViewModels
{
    public class ResultViewModel
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Cliente { get; set; }
        public dynamic Proposta { get; set; }
    }
}