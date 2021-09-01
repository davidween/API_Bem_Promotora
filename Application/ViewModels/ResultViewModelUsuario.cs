namespace Application.ViewModels
{
    public class ResultViewModelUsuario
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Token { get; set; }
        public dynamic TokenExpires { get; set; }
    }
}