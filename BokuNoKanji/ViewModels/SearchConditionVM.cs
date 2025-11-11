using BokuNoKanji.Models;
using BokuNoKanji.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BokuNoKanji.ViewModels;
public class SearchViewModel
{
    public ObservableCollection<SearchCondition> Conditions { get; set; }
    public List<string> AvailableFields { get; } = new() { "Strokes", "Grade", "JLPT", "Reading", "Meaning" };
    public List<string> AvailableOperators { get; } = new() { "=", "<", ">"};
    public List<string> AvailableLogical { get; } = new() { "AND", "OR" };

    public ICommand AddConditionCommand { get; }
    public ICommand RemoveConditionCommand { get; }
    public ICommand ExecuteSearchCommand { get; }

    

    public SearchViewModel()
    {
        Conditions = new ObservableCollection<SearchCondition>();
        Conditions.Add(new SearchCondition());

        AddConditionCommand = new Command(() => Conditions.Add(new SearchCondition()));
        RemoveConditionCommand = new Command<SearchCondition>(c => Conditions.Remove(c));
        ExecuteSearchCommand = new Command(RunSearch);
    }

    private async void RunSearch()
    {
        List<Kanji> Kanjis = await KanjiDataService.GetAllKanjiAsync();

        bool lastIndexOperatorAND = false;

        foreach(SearchCondition c in Conditions)
        {

            if (c.Field == "Meaning")
            {
                
            }

            else if (c.Field == "Reading")
            {

            }

            else if (c.Field == "JLPT")
            {

            }

            else if (c.Field == "Grade")
            {
                
            }

            else if (c.Field == "Strokes")
            {
                
            }
        }
    }
}