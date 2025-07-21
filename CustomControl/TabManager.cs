using CommunityToolkit.Mvvm.ComponentModel;
using MAUI_Custom_Tabs.ViewModels;
using System.Collections.ObjectModel;

namespace MAUI_Custom_Tabs.CustomControls;

public class TabDefinition
{
    public string Header { get; set; }
    public Func<View> ContentCreator { get; set; }
}
public partial class TabManager : BaseViewModel
{
    private readonly Dictionary<int, TabDefinition> _tabDefinitions;
    private readonly WeakDictionary<int, View> _loadedViews;
    [ObservableProperty] private ObservableCollection<TabItem> tabItems;

    [ObservableProperty] private int selectedTabIndex;
    public TabManager(IEnumerable<TabDefinition> tabDefinitions)
    {
        _tabDefinitions = tabDefinitions
            .Select((td, index) => new { Index = index, Definition = td })
            .ToDictionary(x => x.Index, x => x.Definition);

        _loadedViews = new WeakDictionary<int, View>();
        TabItems = new ObservableCollection<TabItem>(
            tabDefinitions.Select(td => new TabItem { Header = td.Header }));

        LoadTabContent(0);
    }
    partial void OnSelectedTabIndexChanged(int value) => LoadTabContent(value);
    public void LoadTabContent(int index)
    {
        if (index < 0 || index >= TabItems?.Count ||
            !_tabDefinitions.TryGetValue(index, out var tabDef)) return;

        if (!_loadedViews.TryGetValue(index, out var view))
        {
            view = tabDef.ContentCreator();
            view.WidthRequest = Application.Current.MainPage.Width;
            _loadedViews[index] = view;
        }

        TabItems[index].Content = view;
    }
    public override void Dispose()
    {
        foreach (var tab in TabItems ?? Enumerable.Empty<TabItem>())
        {
            (tab.Content as IDisposable)?.Dispose();
        }
        TabItems?.Clear();
        _loadedViews.Clear();
        base.Dispose();
    }
}