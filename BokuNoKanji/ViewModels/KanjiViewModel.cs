using BokuNoKanji.Models;
using BokuNoKanji.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BokuNoKanji.ViewModels;

public class KanjiViewModel : INotifyPropertyChanged
{
    private int _maxDisplayCount = 200; // Default value
    public int MaxDisplayCount
    {
        get => _maxDisplayCount;
        set
        {
            if (_maxDisplayCount != value)
            {
                _maxDisplayCount = value;
                OnPropertyChanged();
                FilterKanji(); // Re-filter when this changes
            }
        }
    }

    private string _selectedLimitIndex = "200 results";
    public string SelectedLimitIndex
    {
        get => _selectedLimitIndex;
        set
        {
            if (_selectedLimitIndex != value)
            {
                _selectedLimitIndex = value;
                OnPropertyChanged();

                // Update the max display count based on text
                MaxDisplayCount = value switch
                {
                    "0" => 50,
                    "1" => 100,
                    "2" => 200,
                    "3" => 500,
                    "4" => 2000,
                    _ => 200
                };
            }
        }
    }

    private ObservableCollection<Kanji> _displayedKanji = new();
    public ObservableCollection<Kanji> DisplayedKanji
    {
        get => _displayedKanji;
        set
        {
            if (_displayedKanji != value)
            {
                _displayedKanji = value;
                OnPropertyChanged();
            }
        }
    }

    private string _searchText;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText != value)
            {
                _searchText = value;
                OnPropertyChanged();
                // Don't filter automatically - wait for search button press
            }
        }
    }

    private List<Kanji> _allKanjiInMemory = new();
    private bool _isDataLoaded = false;

    public KanjiViewModel()
    {

        _ = LoadKanjiAsync();
    }

    private async Task LoadKanjiAsync()
    {
        if (!_isDataLoaded)
        {
            _allKanjiInMemory = await KanjiDataService.GetAllKanjiAsync();
            _isDataLoaded = true;

            // Load initial set of kanji
            var initial = _allKanjiInMemory.Take(200).ToList();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                DisplayedKanji.Clear();
                foreach (var k in initial)
                    DisplayedKanji.Add(k);
            });
        }
    }


    public void FilterKanji()
    {
        if (_allKanjiInMemory == null || _allKanjiInMemory.Count == 0)
        {
            Debug.WriteLine("FilterKanji: No data loaded yet");
            return;
        }

        string searched = SearchText?.ToLower() ?? "";
        Debug.WriteLine($"FilterKanji: Searching for '{searched}'");

        IEnumerable<Kanji> filtered;

        if (string.IsNullOrWhiteSpace(searched))
        {
            Debug.WriteLine("FilterKanji: No search text, showing first 200");
            filtered = _allKanjiInMemory.Take(MaxDisplayCount);
        }
        else
        {
            // Try to parse as stroke count
            bool isNumber = int.TryParse(searched, out int strokeCount);
            Debug.WriteLine($"FilterKanji: Is number: {isNumber}, Stroke count: {strokeCount}");

            filtered = _allKanjiInMemory.Where(k =>
                (k.Character?.Contains(searched) ?? false) ||
                (k.Meaning?.ToLower().Contains(searched) ?? false) ||
                (isNumber && k.Strokes == strokeCount))
                .Take(MaxDisplayCount);

            Debug.WriteLine($"FilterKanji: Found {filtered.Count()} results");
        }

        MainThread.BeginInvokeOnMainThread(() =>
        {
            DisplayedKanji.Clear();
            foreach (var k in filtered)
            {
                DisplayedKanji.Add(k);
                Debug.WriteLine($"Adding kanji: {k.Character} - {k.Meaning}");
            }
            Debug.WriteLine($"DisplayedKanji now has {DisplayedKanji.Count} items");
        });
    
    }

    public void FilterKanji(IEnumerable<Kanji> filteredKanji)
    {
        filteredKanji = filteredKanji.Take(MaxDisplayCount);

        MainThread.BeginInvokeOnMainThread(() =>
        {
            DisplayedKanji.Clear();
            foreach (var k in filteredKanji)
            {
                DisplayedKanji.Add(k);
            }
            Debug.WriteLine($"DisplayedKanji now has {DisplayedKanji.Count} items");
        });
    }



    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}