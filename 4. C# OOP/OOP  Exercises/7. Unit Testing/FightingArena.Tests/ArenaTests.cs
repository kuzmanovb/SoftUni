using System;
using NUnit.Framework;

using FightingArena;

namespace Tests
{
    public class ArenaTests
    {
        Arena arena;
        Warrior warrior1;
        Warrior warrior2;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warrior1 = new Warrior("Pesho", 10, 50);
            warrior2 = new Warrior("Gosho", 20, 100);
        }

        [Test]
        public void TestConstructor()
        {
            var arena2 = new Arena();
        }

        [Test]
        public void TestEnroll()
        {
            arena.Enroll(warrior1);

            Assert.That(arena.Warriors, Has.Member(warrior1));
        }

        [Test]
        public void TestCount()
        {
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            var expectedCount = 2;

            Assert.AreEqual(expectedCount, arena.Count);
        }

        [Test]
        public void TestWarriorsGeter()
        {
            arena.Enroll(warrior1);
            var copyWarrios = arena.Warriors;

            var expectedCount = copyWarrios.Count;

            Assert.AreEqual(expectedCount, copyWarrios.Count);
        }

        [Test]
        public void TestEnrollWithWarriorIsAlready()
        {
            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior1);
            });
        }

        [Test]
        public void TestEnrollWithWarriorSameName()
        {
            var newWarrior = new Warrior("Pesho", 10, 50);

            arena.Enroll(warrior1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(newWarrior);
            });
        }

        [Test]
        public void TestFightWithNullAtacer()
        {
            arena.Enroll(warrior1); //Pesho
            arena.Enroll(warrior2); //Gosho

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("To", "Gosho");
            });
        }

        [Test]
        public void TestFightWithNullDefender()
        {
            arena.Enroll(warrior1); //Pesho
            arena.Enroll(warrior2); //Gosho

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho", "To");
            });
        }

        [Test]
        public void TestFigh()
        {
            arena.Enroll(warrior1); //Attacker - Pesho
            arena.Enroll(warrior2); //Defender - Gosho

            var expectedAttacer = warrior1.HP - warrior2.Damage;
            var expectedDefender = warrior2.HP - warrior1.Damage;

            arena.Fight("Pesho", "Gosho");

            Assert.AreEqual(expectedAttacer, warrior1.HP);
            Assert.AreEqual(expectedDefender, warrior2.HP);
        }
    }
}
