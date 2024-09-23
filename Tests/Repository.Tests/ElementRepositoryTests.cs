using ElementalWords.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ElementalWords.Tests.Repository.Tests
{
    [TestFixture]
    public class ElementRepositoryTests
    {
        private IElementRepository _elementRepository;

        [SetUp]
        public void Setup()
        {
            _elementRepository = new ElementRepository();
        }

        [Test]
        public void GetAllElements_ShouldReturnListOfElements()
        {
            // Act
            var elements = _elementRepository.GetAllElements();

            // Assert
            Assert.IsNotNull(elements, "Expected non-null list of elements.");
            Assert.IsNotEmpty(elements, "Expected non-empty list of elements.");
        }

        [Test]
        public void GetAllElements_ShouldContainSpecificElement()
        {
            // Act
            var elements = _elementRepository.GetAllElements();

            // Assert
            Assert.IsTrue(elements.Any(e => e.Symbol == "H" && e.Name == "Hydrogen"),
                "Expected list to contain Hydrogen.");
        }

        [Test]
        public void GetAllElements_ShouldContainExpectedNumberOfElements()
        {
            // Act
            var elements = _elementRepository.GetAllElements();

            // Assert
            Assert.That(115==elements.Count(), "Expected 115 elements in the list.");
        }
    }
}


