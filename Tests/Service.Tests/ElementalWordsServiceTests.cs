using ElementalWords.Models;
using ElementalWords.Repository;
using ElementalWords.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementalWords.Tests.Service.Tests
{
    [TestFixture]
    public class ElementalWordsServiceTests
    {
        private Mock<IElementRepository> _elementRepositoryMock;
        private IElementalWordsService _elementalWordsService;

        [SetUp]
        public void Setup()
        {
            _elementRepositoryMock = new Mock<IElementRepository>();
            _elementalWordsService = new ElementalWordsService(_elementRepositoryMock.Object);
        }

        [Test]
        public void GetElementalWords_WithValidWord_ShouldReturnValidCombinations()
        {
            // Arrange
            var elements = new List<Element>
            {
                new Element { Symbol = "H", Name = "Hydrogen" },
                new Element { Symbol = "He", Name = "Helium" },
                new Element { Symbol = "Li", Name = "Lithium" }
            };
            _elementRepositoryMock.Setup(repo => repo.GetAllElements()).Returns(elements);

            var word = "HeLi";

            // Act
            var result = _elementalWordsService.GetElementalWords(word);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.That(1==result.Count); //only one item
            Assert.That("Helium (He)"==result[0][0]); // First part should be Helium
            Assert.That("Lithium (Li)"== result[0][1]); // Second part should be Lithium
        }

        [Test]
        public void GetElementalWords_WithNoValidCombination_ShouldReturnEmpty()
        {
            // Arrange
            var elements = new List<Element>
            {
                new Element { Symbol = "H", Name = "Hydrogen" },
                new Element { Symbol = "He", Name = "Helium" }
            };
            _elementRepositoryMock.Setup(repo => repo.GetAllElements()).Returns(elements);

            var word = "XYZ"; // No valid combination

            // Act
            var result = _elementalWordsService.GetElementalWords(word);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count()==0); // No valid combinations expected
        }
    }
}

