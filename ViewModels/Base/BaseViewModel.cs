using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
namespace MAUI_Custom_Tabs.ViewModels;

public partial class BaseViewModel : ObservableObject, IDisposable
{
    public BaseViewModel()
    { }
    public virtual Task Initialize(object parameter) => Task.CompletedTask;
    public virtual Task Initialize() => Initialize(null);
        
    public virtual void Dispose() { }
}
