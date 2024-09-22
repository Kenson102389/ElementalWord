using System.Collections.Generic;
using ElementalWords.Services;
using NUnit.Framework;
using ElementalWords.Interfaces;

namespace ElementalWords.Tests
{
    [TestFixture]
    public class WordCombinerTests
    {
        private List<IElement> _elements;

        [SetUp]
        public void Setup()
        {
            _elements = TestUtilities.GetTestElements();
        }

        [Test]
        public void GetCombinations_WithValidWord_ReturnsCorrectCombinations()
        {
            var wordCombiner = new WordCombiner(_elements);
            var result = wordCombiner.GetCombinations("snack");

            var expectedResults = new List<List<string>>
            {
                new List<string> { "Sulfur (S)", "Nitrogen (N)", "Actinium (Ac)", "Potassium (K)" },
                new List<string> { "Sulfur (S)", "Sodium (Na)", "Carbon (C)", "Potassium (K)" },
                new List<string> { "Tin (Sn)", "Actinium (Ac)", "Potassium (K)" }
            };

            Assert.IsNotEmpty(result);
            Assert.That(result.Count, Is.EqualTo(expectedResults.Count));

            foreach (var expected in expectedResults)
            {
                Assert.That(result, Does.Contain(expected));
            }
        }

        [Test]
        public void GetCombinations_WithInvalidWord_ReturnsEmpty()
        {
            var wordCombiner = new WordCombiner(_elements);
            var result = wordCombiner.GetCombinations("xyz");

            Assert.IsEmpty(result);
        }
    }
}
