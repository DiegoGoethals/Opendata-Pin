namespace Pin.OpenData.Blazor.Services
{
    public class ImageService : IImageService
    {
        private static string _imageLink;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _hostingEnvironment = webHostEnvironment;
            _imageLink = "/images/water.png";
        }

        public string GetImageLink()
        {
            return _imageLink;
        }

        public async Task SetStandardPicture()
        {
            var sourceFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "standard.png");
            var targetFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "water.png");

            // Check if source file exists
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException($"Source file '{sourceFilePath}' not found.");
            }

            // Copy the file
            await using (var sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            await using (var targetStream = new FileStream(targetFilePath, FileMode.Create, FileAccess.Write))
            {
                await sourceStream.CopyToAsync(targetStream);
            }
        }
    }
}
