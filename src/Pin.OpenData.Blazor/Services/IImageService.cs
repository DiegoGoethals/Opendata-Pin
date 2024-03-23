namespace Pin.OpenData.Blazor.Services
{
    public interface IImageService
    {
        string GetImageLink();
        Task SetStandardPicture();
    }
}
