using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void TestConstructorHero()
    {
        var hero = new Hero("Pesho", 20);

        var expectedName = "Pesho";
        var expectedLevel = 20;

        Assert.AreEqual(expectedName, hero.Name);
        Assert.AreEqual(expectedLevel, hero.Level);
    }

    [Test]
    public void TestConstructorHeroRepo()
    {
        var repo = new HeroRepository();

        Assert.IsNotNull(repo.Heroes.Count);
    }

    [Test]
    public void TestCreateMethodWithSameHero()
    {
        var hero = new Hero("Pesho", 20);
        var repo = new HeroRepository();

        repo.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            repo.Create(hero);
        });
    }

    [Test]
    public void TestCreateMethodWithNullHero()
    {
        
        var repo = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() =>
        {
            repo.Create(null);

        });
    }

    [Test]
    public void TestRemoveWithNullName()
    {
        var hero = new Hero("Pesho", 20);
        var repo = new HeroRepository();
        repo.Create(hero);

        Assert.Throws<ArgumentNullException>(() =>
        {
            repo.Remove(null);
        });
    }

    [Test]
    public void TestRemove()
    {
        var hero = new Hero("Pesho", 20);
        var repo = new HeroRepository();
        repo.Create(hero);

        var expectedExitOne = true;
        var actualOne = repo.Remove("Pesho");

        var expectedExitTwo = false;
        var actualTwo = repo.Remove("Gosho");

        Assert.AreEqual(expectedExitOne, actualOne);
        Assert.AreEqual(expectedExitTwo, actualTwo);

    }

    [Test]
    public void TestGetHeroHighestLevel()
    {
        var hero1 = new Hero("Pesho", 20);
        var hero2 = new Hero("Gosho", 40);
        var hero3 = new Hero("Tosho", 60);
        var repo = new HeroRepository();
        repo.Create(hero1);
        repo.Create(hero2);
        repo.Create(hero3);

        var expectedHero = hero3;
        var actualHero = repo.GetHeroWithHighestLevel();

        Assert.AreEqual(expectedHero, actualHero);

    }

    [Test]
    public void TestGetHero()
    {
        var hero1 = new Hero("Pesho", 20);
        var hero2 = new Hero("Gosho", 40);
        var hero3 = new Hero("Tosho", 60);
        var repo = new HeroRepository();
        repo.Create(hero1);
        repo.Create(hero2);
        repo.Create(hero3);

        var expectedHero = hero3;
        var actualHero = repo.GetHero("Tosho");

        Assert.AreEqual(expectedHero, actualHero);
    }
}