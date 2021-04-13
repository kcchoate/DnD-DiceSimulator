using DnD.DiceSimulator.Core.ClassFeatures;
using DnD.DiceSimulator.Core.ClassFeatures.Paladin;
using DnD.DiceSimulator.Core.Random.Dice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace DnD.DiceSimulator.Core.Tests.ClassFeatures.Paladin
{
    [TestClass, TestCategory("Unit")]
    public class GreatWeaponFightingUnitTests
    {
        GreatWeaponFighting _feature { get; set; }
        Mock<IDiceRoller> _diceRoller { get; } = new Mock<IDiceRoller>();

        [TestInitialize]
        public void Initialize()
        {
            _feature = new GreatWeaponFighting(_diceRoller.Object);
        }

        [TestMethod]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        public void ModifyDieRoll_GivenRollAbove2_ReturnsRoll(int expectedValue)
        {
            //Arrange

            //Act
            var result = _feature.ModifyDieRoll(expectedValue, 6);

            //Assert
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void ModifyDieRoll_GivenRollBelow3_ReturnsNewRoll(int rolledValue)
        {
            //Arrange
            var expectedValue = 4;
            _diceRoller.Setup(x => x.RollDie(It.IsAny<int>(), It.IsAny<IEnumerable<IClassFeature>>())).Returns(expectedValue);

            //Act
            var result = _feature.ModifyDieRoll(rolledValue, 6);

            //Assert
            Assert.AreEqual(expectedValue, result);
        }
    }
}
