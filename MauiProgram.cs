using MoneyMap.Services; // Ensure namespace matches your SQLiteService
using MoneyMap.Services.Interface;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

using MoneyMap.Service;

namespace MoneyMap
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
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddMudServices();
            builder.Services.AddScoped<ITransactionService, TransactionService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
