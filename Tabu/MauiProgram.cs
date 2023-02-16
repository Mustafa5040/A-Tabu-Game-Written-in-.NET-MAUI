
/* 'Tabu (net7.0-windows10.0.19041.0)' projesinden birleştirilmemiş değişiklik
Sonra:
using Microsoft.Extensions.DependencyInjection;
Önce:
using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm;
using Microsoft.Extensions.DependencyInjection;
*/

/* 'Tabu (net7.0-android)' projesinden birleştirilmemiş değişiklik
Sonra:
using Microsoft.Extensions.DependencyInjection;
Önce:
using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm;
using Microsoft.Extensions.DependencyInjection;
*/

/* 'Tabu (net7.0-ios)' projesinden birleştirilmemiş değişiklik
Sonra:
using Microsoft.Extensions.DependencyInjection;
Önce:
using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm;
using Microsoft.Extensions.DependencyInjection;
*/
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
/* 'Tabu (net7.0-windows10.0.19041.0)' projesinden birleştirilmemiş değişiklik
Sonra:
using Plugin.Maui.Audio;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Maui;
Önce:
using Plugin.Maui.Audio;
*/

/* 'Tabu (net7.0-android)' projesinden birleştirilmemiş değişiklik
Sonra:
using Plugin.Maui.Audio;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Maui;
Önce:
using Plugin.Maui.Audio;
*/

/* 'Tabu (net7.0-ios)' projesinden birleştirilmemiş değişiklik
Sonra:
using Plugin.Maui.Audio;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Maui;
Önce:
using Plugin.Maui.Audio;
*/


namespace Tabu;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("segmdl2.ttf", "SegoeMDL");
                fonts.AddFont("SegUIVar.ttf", "SegoeUIVariable");
            });
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
