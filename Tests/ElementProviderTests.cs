using ElementalWords.Interfaces;
using ElementalWords.Models;
using ElementalWords.Services;
using NUnit.Framework;

namespace ElementalWords.Tests
{
    [TestFixture]
    public class ElementProviderTests
    {
        [Test]
        public void GetElements_ReturnsCorrectNumberOfElements()
        {
            IElementProvider elementProvider = new ElementProvider();
            var elements = elementProvider.GetElements();

            Assert.IsNotNull(elements);
            Assert.IsTrue(elements.Count > 0);
        }

        [Test]
        public void GetElements_ContainsExpectedElement()
        {
            IElementProvider elementProvider = new ElementProvider();
            var elements = elementProvider.GetElements();

            Assert.That(elements, Has.Exactly(1).Matches<Element>(e => e.Symbol == "H" && e.Name == "Hydrogen"));
            Assert.That(elements, Has.Exactly(1).Matches<Element>(e => e.Symbol == "O" && e.Name == "Oxygen"));
            Assert.That(elements, Has.Exactly(1).Matches<Element>(e => e.Symbol == "Sn" && e.Name == "Tin"));
        }
    }
}
