using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Maui;

namespace Tabu;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("segmdl2.ttf", "SegoeMDL");
			});
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
