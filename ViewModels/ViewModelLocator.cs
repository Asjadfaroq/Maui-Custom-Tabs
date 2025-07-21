using System.Reflection;
using MAUI_Custom_Tabs;
using MAUI_Custom_Tabs.ViewModels;

namespace MAUI_Custom_Tabs.ViewModels;

public static class ViewModelLocator
{
    public static readonly IServiceProvider ServiceProvider;
    static ViewModelLocator()
    {
        if (MauiProgram.builder?.Services == null)
        {
            throw new InvalidOperationException("MauiProgram.builder.Services is not initialized");
        }
        ServiceProvider = MauiProgram.builder.Services.BuildServiceProvider();
    }

    public static readonly BindableProperty AutoWireViewModelProperty =
        BindableProperty.CreateAttached(
            "AutoWireViewModel",
            typeof(bool),
            typeof(ViewModelLocator),
            default(bool),
            propertyChanged: OnAutoWireViewModelChanged);

    public static bool GetAutoWireViewModel(BindableObject bindable) =>
        (bool)bindable.GetValue(AutoWireViewModelProperty);

    public static void SetAutoWireViewModel(BindableObject bindable, bool value) =>
        bindable.SetValue(AutoWireViewModelProperty, value);

    private static async void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (!(bindable is Element view))
        {
            return;
        }

        var viewType = view.GetType();
        var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
        var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
        var viewModelName = $"{viewName}ViewModel, {viewAssemblyName}";

        var viewModelType = Type.GetType(viewModelName);
        if (viewModelType != null)
        {
            var viewModel = ServiceProvider.GetService(viewModelType) as BaseViewModel;
            if (viewModel != null)
            {
                await viewModel.Initialize();
            }
            view.BindingContext = viewModel;
        }
    }
}

