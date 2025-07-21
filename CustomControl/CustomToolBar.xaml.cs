using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace MAUI_Custom_Tabs.CustomControls;

public partial class CustomToolBar : ContentView
{
    public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(CustomToolBar), string.Empty);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    
    public CustomToolBar()
    {
        InitializeComponent();
    }
}