using Microsoft.Extensions.Logging;
using Supabase;
using CommunityToolkit.Maui;
using _6002AndroidApp.ViewModels;
using _6002AndroidApp.Views;
using _6002AndroidApp.Services;

namespace _6002AndroidApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().UseMauiCommunityToolkit();
            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("coolvetica-compressed-hv.otf", "CvtcaCompHV");
                fonts.AddFont("coolvetica-condensed-rg.otf", "CvtcaCondRG");
                fonts.AddFont("coolvetica-crammed-rg.otf", "CvtcaCramRG");
                fonts.AddFont("coolvetica-rg.otf", "CvtcaRG");
            });
            var SUPABASE_URL = "https://qceeywhkitmgeppvmxgb.supabase.co";
            var SUPABASE_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InFjZWV5d2hraXRtZ2VwcHZteGdiIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTcxMTExOTk5MSwiZXhwIjoyMDI2Njk1OTkxfQ.kzENF1Dpe7sugmg9eDaz1b2dhRE7dApj7RsrKpqqddE";
            var options = new SupabaseOptions
            {
                AutoRefreshToken = true,
                AutoConnectRealtime = true
            };

            builder.Services.AddSingleton(provider => new Supabase.Client(SUPABASE_URL, SUPABASE_KEY, options));

            builder.Services.AddSingleton<CharacterViewModel>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<ImageViewModel>();
            builder.Services.AddSingleton<DiceViewModel>();

            builder.Services.AddSingleton<ChooseImage>();

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<SheetViewModel>();
            builder.Services.AddTransient<InventoryViewModel>();

            builder.Services.AddTransient<LogIn>();
            builder.Services.AddTransient<Register>();
            builder.Services.AddTransient<CharacterSheet>();
            builder.Services.AddTransient<CharacterSelect>();
            builder.Services.AddTransient<NewCharacter>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<DiceRoller>();
            builder.Services.AddTransient<Inventory>();

            builder.Services.AddSingleton<IDataService, DataService>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}