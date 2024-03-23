using Pin.OpenData.Blazor.Services;

namespace Pin.OpenData.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddSingleton<ILocationService, LocationService>();
            builder .Services.AddSingleton<INewsLetterService, NewsLetterService>();
            builder.Services.AddSingleton<IImageService, ImageService>();

            var app = builder.Build();

            var imageService = app.Services.GetRequiredService<IImageService>();
            await imageService.SetStandardPicture();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}