using System;
using NUnit.Framework;

using FightingArena;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructor()
        {
            var warrior = new Warrior("Pesho", 10, 50);

            var expectedName = "Pesho";
            var expectedDamage = 10;
            var expectedHP = 50;

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void TestNameWithNull(string arg)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var warrior = new Warrior(arg, 10, 50);
            });
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void TestDamageWithNegativeAndZeroNumber(int arg)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var warrior = new Warrior("Pesho", arg, 50);
            });
        }

        [Test]
        public void TestHPWithNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var warrior = new Warrior("Pesho", 10, -50);
            });
        }

        [Test]
        public void TestAttackMethodWithGefenderHPBelowThan30()
        {
            var warriorDefender = new Warrior("Pesho", 10, 100);
            var warriorAttacker = new Warrior("Gosho", 10, 20);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorDefender.Attack(warriorAttacker);
            });
        }

        [Test]
        public void TestAttackMethodWithAttackerHPBelowThan30()
        {
            var warriorDefender = new Warrior("Pesho", 10, 20);
            var warriorAttacker = new Warrior("Gosho", 10, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorDefender.Attack(warriorAttacker);
            });
        }

        [Test] 
        public void TestAttackMethodWithDefenderHPLessAttackerDamage() //this.HP<warrior.Damage
        {
            var warriorDefender = new Warrior("Pesho", 40, 50);
            var warriorAttacker = new Warrior("Gosho", 70, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorDefender.Attack(warriorAttacker);
            });
        }
        
        [Test]
        public void TestAttackMethod()
        {
            var warriorDefender = new Warrior("Pesho", 80, 160);
            var warriorAttacker = new Warrior("Gosho", 50, 70);

            warriorDefender.Attack(warriorAttacker);

            Assert.AreEqual(0, warriorAttacker.HP);
            Assert.AreEqual(110, warriorDefender.HP);
        }
    }
}