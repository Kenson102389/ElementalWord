using ElementalWords.Interfaces;

namespace ElementalWords.Services;

public class WordCombiner : IWordCombiner
{
    private readonly List<IElement> _elements;

    public WordCombiner(List<IElement> elements)
    {
        _elements = elements ?? throw new ArgumentNullException(nameof(elements));
    }

    public List<List<string>> GetCombinations(string word)
    {
        var results = new List<List<string>>();
        FindCombinations(word.ToLower(), new List<string>(), results);
        return results;
    }

    private void FindCombinations(string word, List<string> currentCombination, List<List<string>> results)
    {
        if (string.IsNullOrEmpty(word))
        {
            results.Add(new List<string>(currentCombination));
            return;
        }

        for (int i = 1; i <= 3 && i <= word.Length; i++)
        {
            string symbol = word.Substring(0, i).ToUpper();
            var element = _elements.FirstOrDefault(e => e.Symbol.Equals(symbol, StringComparison.OrdinalIgnoreCase));
            if (element != null)
            {
                currentCombination.Add($"{element.Name} ({element.Symbol})");
                FindCombinations(word.Substring(i), currentCombination, results);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }
    }
}

