using BokuNoKanji.Models;
using BokuNoKanji.Services;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace BokuNoKanji.ViewModels;

public class SearchViewModel
{
    public ObservableCollection<SearchCondition> Conditions { get; set; }

    public List<string> AvailableFields { get; } =
        new() { "Strokes", "Grade", "JLPT", "Reading", "Meaning" };

    public List<string> AvailableOperators { get; } =
        new() { "=", "<", ">", "Contains" };

    public List<string> AvailableLogical { get; } =
        new() { "AND", "OR" };

    public ICommand AddConditionCommand { get; }
    public ICommand RemoveConditionCommand { get; }
    public ICommand ExecuteSearchCommand { get; }

    public SearchViewModel()
    {
        Conditions = new ObservableCollection<SearchCondition>
        {
            new SearchCondition()
        };

        AddConditionCommand =
            new Command(() => Conditions.Add(new SearchCondition()));

        RemoveConditionCommand =
            new Command<SearchCondition>(c =>
            {
                if (c != null)
                    Conditions.Remove(c);
            });

        ExecuteSearchCommand = new Command(async () => await RunSearchAsync());
    }

    private async Task RunSearchAsync()
    {
        try
        {
            var kanji = await KanjiDataService.GetAllKanjiAsync();

            var conditions = Conditions
                .Where(c => !string.IsNullOrWhiteSpace(c.Field)
                         && !string.IsNullOrWhiteSpace(c.Value))
                .ToList();

            if (conditions.Count == 0)
            {
                await Shell.Current.DisplayAlert(
                    "Advanced Search",
                    "Please enter at least one search condition.",
                    "OK");
                return;
            }

            // Apply conditions in order, using each condition's
            // Logical property to combine it with the preceding result.
            
            var matched = kanji
                .Where(k => Matches(k, conditions[0]))
                .ToList();

            for (int i = 1; i < conditions.Count; i++)
            {
                var condition = conditions[i];

                var matches = kanji
                    .Where(k => Matches(k, condition))
                    .ToList();

                if (string.Equals(
                    condition.Logical,
                    "OR",
                    StringComparison.OrdinalIgnoreCase))
                {
                    matched = matched
                        .Concat(matches)
                        .DistinctBy(k => k.Character)
                        .ToList();
                }
                else
                {
                    var matchingCharacters = matches
                        .Select(k => k.Character)
                        .ToHashSet();

                    matched = matched
                        .Where(k => matchingCharacters.Contains(k.Character))
                        .ToList();
                }
            }

            App.SharedKanjiViewModel.FilterKanji(matched);
            
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert(
                "Advanced Search Error",
                ex.Message,
                "OK");
        }
    }


    private static bool Matches(Kanji k, SearchCondition c)
    {
        string value = c.Value?.Trim() ?? "";
        string op = c.Operator?.Trim() ?? "=";

        switch (c.Field)
        {
            case "Meaning":
                return CompareText(k.Meaning, value, op);

            case "Reading":
                return CompareText(k.Onyomi, value, op)
                    || CompareText(k.Kunyomi, value, op);

            case "JLPT":
                return CompareNumber(k.Jlpt, value, op);

            case "Grade":
                return CompareNumber(k.Grade, value, op);

            case "Strokes":
                return CompareNumber(k.Strokes, value, op);

            default:
                return false;
        }
    }



    private static bool CompareText(string? actual, string expected, string op)
    {
        if (actual == null)
            return false;

        if (op.Equals("Contains", StringComparison.OrdinalIgnoreCase))
            return actual.Contains(expected, StringComparison.OrdinalIgnoreCase);

        if (op == "=")
            return actual.Equals(expected, StringComparison.OrdinalIgnoreCase);

        return false;
    }

    private static bool CompareNumber(
        int actual, string expected, string op)
    {
        if (!int.TryParse(expected, NumberStyles.Integer,
            CultureInfo.InvariantCulture, out int number))
            return false;

        return op switch
        {
            "=" => actual == number,
            "<" => actual < number,
            ">" => actual > number,
            _ => false
        };
    }
}

