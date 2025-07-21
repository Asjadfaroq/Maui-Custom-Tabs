using Microsoft.Maui.Controls.Shapes;
namespace MAUI_Custom_Tabs.CustomControls;
public class CustomTabs : ContentView
{
    //============================================== Bindable Properties =====================================
    #region Bindable Properties
    public static readonly BindableProperty ItemsSourceProperty =
        BindableProperty.Create(nameof(ItemsSource), typeof(IList<TabItem>), typeof(CustomTabs), null,
            propertyChanged: OnItemsSourceChanged);
    public static readonly BindableProperty SelectedIndexProperty =
        BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(CustomTabs), 0,
            propertyChanged: OnSelectedIndexChanged);
    public IList<TabItem> ItemsSource
    {
        get => (IList<TabItem>)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }
    public int SelectedIndex
    {
        get => (int)GetValue(SelectedIndexProperty);
        set => SetValue(SelectedIndexProperty, value);
    }
    private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is CustomTabs tabView)
            tabView.UpdateTabs();
    }
    private static void OnSelectedIndexChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is CustomTabs tabView)
            tabView.UpdateSelectedTab();
    }
    #endregion
    //==============================================  Variables initialization =====================================
    #region Private Properties
    private readonly Grid _mainGrid;
    private readonly Grid _tabHeaderGrid;
    private readonly Grid _contentGrid;
    private readonly List<Button> _tabButtons;
    private readonly Dictionary<int, View> _cachedViews;
    private bool _isDisposed;
    // Colors bound to theme
    private Color BackgroundColorTheme => Application.Current.RequestedTheme == AppTheme.Dark ? DarkBackgroundColor : LightBackgroundColor;
    private Color SelectedBackgroundColorTheme => Application.Current.RequestedTheme == AppTheme.Dark ? DarkSelectedBackgroundColor : LightSelectedBackgroundColor;
    private Color SelectedTextColorTheme => Application.Current.RequestedTheme == AppTheme.Dark ? DarkSelectedTextColor : LightSelectedTextColor;
    private Color DefaultTextColorTheme => Application.Current.RequestedTheme == AppTheme.Dark ? DarkDefaultTextColor : LightDefaultTextColor;
    // Light Theme Colors
    private static readonly Color LightBackgroundColor = (Color)Application.Current.Resources["VeryLightGray"];
    private static readonly Color LightSelectedBackgroundColor = Colors.White;
    private static readonly Color LightSelectedTextColor = (Color)Application.Current.Resources["Primary"];
    private static readonly Color LightDefaultTextColor = Colors.Black;
    // Dark Theme Colors
    private static readonly Color DarkBackgroundColor = (Color)Application.Current.Resources["DarkGray"];
    private static readonly Color DarkSelectedBackgroundColor = (Color)Application.Current.Resources["SmokyBlack"];
    private static readonly Color DarkSelectedTextColor = (Color)Application.Current.Resources["Primary"];
    private static readonly Color DarkDefaultTextColor = Colors.White;
    #endregion
    //=============================================================================================================
    public CustomTabs()
    {
        _tabButtons = new List<Button>();
        _cachedViews = new Dictionary<int, View>();
        _mainGrid = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new(GridLength.Auto),
                new(GridLength.Star)
            },
        };
        _tabHeaderGrid = new Grid
        {
            BackgroundColor = BackgroundColorTheme,
            Padding = new Thickness(5),
            HorizontalOptions = LayoutOptions.Fill
        };
        var headerBorder = new Border
        {
            StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) },
            Content = _tabHeaderGrid,
            BackgroundColor = BackgroundColorTheme,
            Padding = 0,
            Margin = new Thickness(15, 0, 15, 6),
            StrokeThickness = 0
        };
        _contentGrid = new Grid();
        _mainGrid.Add(headerBorder, 0, 0);
        _mainGrid.Add(_contentGrid, 0, 1);
        Content = _mainGrid;
        Application.Current.RequestedThemeChanged += OnRequestedThemeChanged;
    }
    #region Other Functions
    private void OnRequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
    {
        UpdateColors();
    }
    private void UpdateColors()
    {
        _tabHeaderGrid.BackgroundColor = BackgroundColorTheme;
        var headerBorder = _mainGrid.Children.OfType<Border>().FirstOrDefault();
        if (headerBorder != null)
        {
            headerBorder.BackgroundColor = BackgroundColorTheme;
        }
        foreach (var button in _tabButtons)
        {
            bool isSelected = _tabButtons.IndexOf(button) == SelectedIndex;
            button.BackgroundColor = isSelected ? SelectedBackgroundColorTheme : BackgroundColorTheme;
            button.TextColor = isSelected ? SelectedTextColorTheme : DefaultTextColorTheme;
        }
    }
    private void UpdateTabs()
    {
        if (ItemsSource == null) return;
        if (_tabHeaderGrid.ColumnDefinitions?.Count != ItemsSource.Count)
        {
            var columns = new ColumnDefinitionCollection();
            for (int i = 0; i < ItemsSource.Count; i++)
            {
                columns.Add(new ColumnDefinition(GridLength.Star));
            }
            _tabHeaderGrid.ColumnDefinitions = columns;
        }
        while (_tabButtons.Count < ItemsSource.Count)
        {
            var index = _tabButtons.Count;
            var button = CreateTabButton(ItemsSource[index].Header, index);
            _tabButtons.Add(button);
            _tabHeaderGrid.Add(button, index, 0);
        }
        while (_tabButtons.Count > ItemsSource.Count)
        {
            var lastButton = _tabButtons[^1];
            _tabHeaderGrid.Remove(lastButton);
            _tabButtons.RemoveAt(_tabButtons.Count - 1);
        }
        for (int i = 0; i < ItemsSource.Count; i++)
        {
            _tabButtons[i].Text = ItemsSource[i].Header;
        }
        UpdateSelectedTab();
    }
    private Button CreateTabButton(string header, int index)
    {
        var button = new Button
        {
            Text = header,
            BackgroundColor = Colors.Transparent,
            TextColor = SelectedTextColorTheme,
            FontSize = 12,
            HeightRequest = 50,
            FontFamily = "poppins500",
            CornerRadius = 10,
            Padding = new Thickness(5),
            HorizontalOptions = LayoutOptions.Fill,
        };
        button.Clicked += async (s, e) =>
        {
            if (!_isDisposed)
            {
                SelectedIndex = index;
                await UpdateSelectedTab();
            }
        };
        return button;
    }

    private async Task UpdateSelectedTab()
    {
        if (ItemsSource == null || _tabButtons.Count == 0) return;
        if (SelectedIndex < 0 || SelectedIndex >= _tabButtons.Count)
        {
            SelectedIndex = 0;
            return;
        }

        // Update button colors
        for (int i = 0; i < _tabButtons.Count; i++)
        {
            var button = _tabButtons[i];
            bool isSelected = i == SelectedIndex;
            button.BackgroundColor = isSelected ? SelectedBackgroundColorTheme : BackgroundColorTheme;
            button.TextColor = isSelected ? SelectedTextColorTheme : DefaultTextColorTheme;
            button.FontAttributes = isSelected ? FontAttributes.Bold : FontAttributes.None;
        }

        // Update content
        var selectedItem = ItemsSource[SelectedIndex];
        if (!_cachedViews.TryGetValue(SelectedIndex, out var view))
        {
            view = selectedItem.Content;
            if (view != null)
            {
                _cachedViews[SelectedIndex] = view;
            }
        }

        if (view != null && !_contentGrid.Children.Contains(view))
        {
            _contentGrid.Clear();
            _contentGrid.Add(view);
        }
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
            {
                foreach (var button in _tabButtons)
                {
                    button.Clicked -= null;
                }
                _tabButtons.Clear();
                _cachedViews.Clear();
                _contentGrid.Clear();
                _tabHeaderGrid.Clear();
            }
            _isDisposed = true;
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    #endregion
}
public class TabItem
{
    public string Header { get; set; }
    public View Content { get; set; }
}












