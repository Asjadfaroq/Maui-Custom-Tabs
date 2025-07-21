using Microsoft.Extensions.Logging;
using MAUI_Custom_Tabs.ViewModels;
using CommunityToolkit.Maui;

namespace MAUI_Custom_Tabs;

public static class MauiProgram
{
	public static MauiAppBuilder? builder;
	public static MauiApp CreateMauiApp()
	{
		builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Poppins-SemiBold.ttf", "poppins500");
				fonts.AddFont("Poppins-Medium.ttf", "poppins400");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<DashboardViewModel>();
		builder.Services.AddSingleton<TrendsViewModel>();
		builder.Services.AddSingleton<InsightsViewModel>();
		builder.Services.AddSingleton<ReportsViewModel>();
		return builder.Build();
	}
}
