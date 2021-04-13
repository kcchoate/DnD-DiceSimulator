using DnD.DiceSimulator.Core.ClassFeatures;
using DnD.DiceSimulator.Core.Random;
using DnD.DiceSimulator.Core.Random.Dice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace DnD.DiceSimulator.Core.Tests.Random.Dice
{
    [TestClass, TestCategory("Unit")]
    public class DiceRollerUnitTests
    {
        DiceRoller _roller { get; set; }
        Mock<IRandomNumberGenerator> _rng { get; } = new Mock<IRandomNumberGenerator>();

        [TestInitialize]
        public void Initialize()
        {
            _roller = new DiceRoller(_rng.Object);
        }

        [TestMethod]
        public void RollDie_GivenNullFeatureList_ReturnsRolledValue()
        {
            //Arrange
            var expectedValue = 6;
            _rng.Setup(x => x.GetInt(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedValue);

            //Act
            var result = _roller.RollDie(6, null);

            //Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void RollDie_GivenEmptyFeatureList_ReturnsRolledValue()
        {
            //Arrange
            var expectedValue = 6;
            _rng.Setup(x => x.GetInt(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedValue);

            //Act
            var result = _roller.RollDie(6, Array.Empty<IClassFeature>());

            //Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void RollDie_GivenClassFeature_ReturnsRolledValueModifedByClassFeature()
        {
            //Arrange
            var expectedRandomValue = 6;
            var classFeatureModifier = 1;
            var expectedValue = expectedRandomValue + classFeatureModifier;

            //mock class feature that just adds 1 to the rolled value
            _rng.Setup(x => x.GetInt(It.IsAny<int>(), It.IsAny<int>())).Returns(expectedRandomValue);

            var mockFeature = new Mock<IClassFeature>();
            mockFeature.Setup(x => x.ModifyDieRoll(It.IsAny<int>(), It.IsAny<int>())).Returns((int rolledValue, int _) => rolledValue + classFeatureModifier);

            //Act
            var result = _roller.RollDie(6, new[] { mockFeature.Object });

            //Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void RollDice_GivenClassFeature_ReturnsRolledValuesModifedByClassFeature()
        {
            //Arrange
            int numberOfDice = 2;
            var firstExpectedRandomValue = 6;
            var secondExpectedRandomValue = 1;
            var classFeatureModifier = 1;
            var expectedValue = new[] { firstExpectedRandomValue + classFeatureModifier, secondExpectedRandomValue + classFeatureModifier };

            //mock class feature that just adds 1 to the rolled value
            _rng.SetupSequence(x => x.GetInt(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(firstExpectedRandomValue)
                .Returns(secondExpectedRandomValue);

            var mockFeature = new Mock<IClassFeature>();
            mockFeature.Setup(x => x.ModifyDieRoll(It.IsAny<int>(), It.IsAny<int>())).Returns((int rolledValue, int _) => rolledValue + classFeatureModifier);

            //Act
            var result = _roller.RollDice(numberOfDice, 6, new[] { mockFeature.Object }).ToArray();

            //Assert
            CollectionAssert.AreEqual(expectedValue, result);
        }
    }
}
