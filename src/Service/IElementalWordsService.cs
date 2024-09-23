using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementalWords.Service
{
    public interface IElementalWordsService
    {
        public List<List<string>> GetElementalWords(string word);
    }
}
