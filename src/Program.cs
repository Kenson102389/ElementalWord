using ElementalWords.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ElementalWords;

internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1 || string.IsNullOrWhiteSpace(args[0]))
        {
            throw new ArgumentException("Please provide exactly one non-empty argument.");
        }

        string word = args[0];

        var services = Ioc.Configure();

        var elementalWordsService = services.GetRequiredService<IElementalWordsService>();
         
        var result = elementalWordsService.GetElementalWords(word);

        if (result.Count == 0)
        {
            Console.WriteLine($"No elemental words found for '{word}'.");
        }
        else
        {
            Console.WriteLine($"Elemental words for '{word}':");
            foreach (var form in result)
            {
                Console.WriteLine(string.Join(", ", form));
            }
        }
    }

    

}