namespace DemoResolution.Domain.Wrappers
{
    public class AppResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
