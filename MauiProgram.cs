using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SffListViewGroupingTest.ViewModels;
using Syncfusion.Maui.Core.Hosting;

using System.Reflection;

namespace SffListViewGroupingTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            
            builder.Services.AddSingleton<BookInfoRepository>();

            return builder.Build();
        }
    }
}
