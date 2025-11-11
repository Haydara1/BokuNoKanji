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
        AdvancedSearchSub.BindingContext = App.SharedSearchViewModel ;

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

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        KanjiSearchBar.IsEnabled = !KanjiSearchBar.IsEnabled;
        KanjiSearchBar.Text = string.Empty;

        TipsBorder.IsVisible = KanjiSearchBar.IsEnabled;
        AdvancedSearchSub.IsVisible = !KanjiSearchBar.IsEnabled;
    }

    private void HelpButton_Clicked(object sender, EventArgs e)
    {
        var popup = new InfoPopup("Advanced searching allows you to filter kanjis following many conditions \n" +
            "You can filter by stroke count, jlpt level...\n" +
            "OR means one of the two connected conditions is enough\n" +
            "AND means the connected conditions must exist to be filtered\n" +
            "The connecter is between the first condition and the one after it.");
        this.ShowPopup(popup, new PopupOptions
        {
            CanBeDismissedByTappingOutsideOfPopup = true
        }); // "this" = current Page
    }
}