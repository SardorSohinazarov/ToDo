using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ToDo.ViewModel;

[QueryProperty("Text","Text")]
public partial class DetailViewModel : ObservableObject
{
    [ObservableProperty]
    public string text;

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
