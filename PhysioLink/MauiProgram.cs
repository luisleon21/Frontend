using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using PhysioLink.Components.Services;
using Microsoft.Extensions.DependencyInjection;

namespace PhysioLink
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();


            var backendUrl = "http://localhost:8081/";

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(backendUrl);
            builder.Services.AddSingleton(httpClient);

            builder.Services.AddScoped<test>();


            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
