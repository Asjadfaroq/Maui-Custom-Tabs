using MAUI_Custom_Tabs.Views;

namespace MAUI_Custom_Tabs;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Dashboard), typeof(Dashboard));
		Routing.RegisterRoute(nameof(Trends), typeof(Trends));
		Routing.RegisterRoute(nameof(Insights), typeof(Insights));
		Routing.RegisterRoute(nameof(Reports), typeof(Reports));
	}
	
}
