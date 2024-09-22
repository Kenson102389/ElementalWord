using ElementalWords.Interfaces;
using ElementalWords.Services;

namespace ElementalWords;

internal class Program
{
    static void Main(string[] args)
    {
        IElementProvider elementProvider = new ElementProvider();
        var elements = elementProvider.GetElements();

        IWordCombiner wordCombiner = new WordCombiner(elements);

        Console.WriteLine("Enter a word to find elemental combinations:");
        string? inputWord = Console.ReadLine()?.Trim();

        if (!string.IsNullOrEmpty(inputWord))
        {
            var forms = wordCombiner.GetCombinations(inputWord);

            if (forms.Count > 0)
            {
                Console.WriteLine($"Elemental combinations for '{inputWord}':");
                foreach (var form in forms)
                {
                    Console.WriteLine(string.Join(", ", form));
                }
            }
            else
            {
                Console.WriteLine($"No elemental combinations found for '{inputWord}'.");
            }
        }
        else
        {
            Console.WriteLine("Input cannot be empty.");
        }
    }
}
