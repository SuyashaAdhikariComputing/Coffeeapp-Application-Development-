using Coffeeapp.Data.Models;
using Coffeeapp.Data.Services;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace Coffeeapp
{
    public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<AddIn>();
            builder.Services.AddSingleton<CoffeeConfig>();
            builder.Services.AddSingleton<OrderItem>();
            builder.Services.AddSingleton<LoginService>();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		    builder.Logging.AddDebug();
#endif
			builder.Services.AddMudServices();
			
			

			return builder.Build();
		}
	}
}