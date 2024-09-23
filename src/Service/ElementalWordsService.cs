using ElementalWords.Models;
using ElementalWords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementalWords.Service
{
    public class ElementalWordsService : IElementalWordsService
    {
        private readonly IElementRepository _elementRepository;

        public ElementalWordsService(IElementRepository elementRepository)
        {
            _elementRepository=elementRepository;
        }

        public List<List<string>> GetElementalWords(string word)
        {
            var elementMap = _elementRepository.GetAllElements().ToDictionary(e => e.Symbol.ToLower(), e => $"{e.Name} ({e.Symbol})");
            var result = new List<List<string>>();

            // recursively find valid combinations
            void FindCombinations(string remaining, List<string> currentCombination)
            {
                // if no characters left, we found a valid combination
                if (string.IsNullOrEmpty(remaining))
                {
                    result.Add(new List<string>(currentCombination));
                    return;
                }

                // using 1 or 2 characters from the remaining string
                for (int i = 1; i <= 2 && i <= remaining.Length; i++)
                {
                    var prefix = remaining.Substring(0, i).ToLower();

                    // If the prefix matches an element symbol, proceed recursively
                    if (elementMap.ContainsKey(prefix))
                    {
                        var elementName = elementMap[prefix];
                        currentCombination.Add(elementName);

                        FindCombinations(remaining.Substring(i), currentCombination);

                        // remove
                        currentCombination.RemoveAt(currentCombination.Count - 1);
                    }
                }
            }

            // Start recursion with the input word
            FindCombinations(word.ToLower(), new List<string>());

            return result;
        }
    }
}
