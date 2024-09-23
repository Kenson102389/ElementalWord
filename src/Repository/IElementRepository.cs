using ElementalWords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementalWords.Repository
{
    public interface IElementRepository
    {
        IEnumerable<Element> GetAllElements();
    }
}
