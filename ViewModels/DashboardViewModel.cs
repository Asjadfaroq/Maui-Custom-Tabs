using CommunityToolkit.Mvvm.ComponentModel;
using MAUI_Custom_Tabs.CustomControls;
using MAUI_Custom_Tabs.Views;

namespace MAUI_Custom_Tabs.ViewModels;

public partial class DashboardViewModel : BaseViewModel
{
    [ObservableProperty] private TabManager tabManager = null!;
    public DashboardViewModel()
    {
        setTab();
    }
    public void setTab()
    {
        TabManager = new TabManager(new[]{
            
            new TabDefinition
            {
                Header = "Insights",
                ContentCreator = () => new Insights { BindingContext = new InsightsViewModel() }
            },
            new TabDefinition
            {
                Header = "Trends",
                ContentCreator = () => new Trends { BindingContext = new TrendsViewModel()}
            },
            new TabDefinition
            {
                Header = "Reports",
                ContentCreator = () => new Reports { BindingContext = new ReportsViewModel() }
            }
        });
    }
}