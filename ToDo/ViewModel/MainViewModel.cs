using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ToDo.ViewModel;

public partial class MainViewModel : ObservableObject
{
    IConnectivity connectivity;
    public MainViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        this.connectivity = connectivity;
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        Items.Add(Text);

        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
            Items.Remove(s);
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(Detail)}?Text={DateTime.Now.ToString("yyyy dd, HH:mm:ss")}",
            new Dictionary<string, object>
            {
                {nameof(Detail), new object()}
            });
    }

    [RelayCommand]
    async Task GotoMe()
    {
        if (connectivity.NetworkAccess == NetworkAccess.Internet)
        {
            var ourUrl = "https://www.youtube.com/@sardorsohinazarov";
            Launcher.OpenAsync(new Uri(ourUrl));
        }
        else
        {
            await Shell.Current.DisplayAlert("Oh, No !!!", "Check your network", "OK");
            return;
        }
    }
}
