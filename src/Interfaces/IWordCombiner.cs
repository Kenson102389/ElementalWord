namespace ElementalWords.Interfaces;

public interface IWordCombiner
{
    List<List<string>> GetCombinations(string word);
}