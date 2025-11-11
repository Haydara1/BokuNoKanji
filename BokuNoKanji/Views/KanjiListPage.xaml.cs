namespace BokuNoKanji.Views;

using BokuNoKanji.Models;
using BokuNoKanji.ViewModels;
using Microsoft.Maui.Controls;

public partial class KanjiListPage : ContentPage
{
    public KanjiListPage()
    {
        InitializeComponent();
        BindingContext = App.SharedKanjiViewModel; // Use shared ViewModel
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void ClearButton_Clicked(object sender, EventArgs e)
    {
        App.SharedKanjiViewModel.SearchText = string.Empty;
        App.SharedKanjiViewModel.FilterKanji();
    }

    // Show details when a kanji is tapped
    private async void OnKanjiSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Kanji selected)
        {
            await DisplayAlert(
                selected.Character,
                $"Meaning: {selected.Meaning}\nStrokes: {selected.Strokes}\nOnyomi: {selected.Onyomi}\nKunyomi: {selected.Kunyomi}",
                "Close");

            ((CollectionView)sender).SelectedItem = null; // deselect
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Ensure we have the latest filtered results
        App.SharedKanjiViewModel.FilterKanji();
    }
}