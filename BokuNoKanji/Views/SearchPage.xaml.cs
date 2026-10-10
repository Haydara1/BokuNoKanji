using BokuNoKanji.Popups;
using BokuNoKanji.ViewModels;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;


namespace BokuNoKanji.Views;

public partial class SearchPage : ContentPage
{
    private KanjiViewModel _viewModel;

    public SearchPage()
    {
        InitializeComponent();
        BindingContext = App.SharedKanjiViewModel; // Use shared ViewModel

        picker.SelectedIndex = 2;
    }

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        // Apply the filter before navigating
        App.SharedKanjiViewModel.FilterKanji();
        await Shell.Current.GoToAsync(nameof(KanjiListPage));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Clear search when returning to search page
        App.SharedKanjiViewModel.SearchText = string.Empty;
        KanjiSearchBar.Text = string.Empty;
    }
    
}