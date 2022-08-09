using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void CreateShouldThrowArgumentNullExceptionIfHeroIsNull()
    { 
        HeroRepository repository = new HeroRepository();
        Hero hero = null;

        Assert.Throws<ArgumentNullException>(() =>
       {
           repository.Create(hero); 
       }, "Hero is null");
    }

    [Test]
    public void CreateShouldThrowExceptionIfHeroAlreadyExist()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Polina", 20);
        repository.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            repository.Create(hero);
        }, $"Hero with name {hero.Name} already exists");
    }

    [Test]
    public void CreateShouldReturnCorrectData()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Polina", 20);
        string actualDataCreate = repository.Create(hero);
        string expectedDataCreate = $"Successfully added hero Polina with level 20";

        Assert.AreEqual(expectedDataCreate, actualDataCreate);
    }

    [TestCase("")]
    [TestCase("    ")]
    public void RemoveShouldThrowArgumentNullExceptionIfStringIsNullOrEmpty(string name)
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Polina", 20);
        repository.Create(hero);

        Assert.Throws<ArgumentNullException>(() =>
        {
            repository.Remove(name);
        }, "Name cannot be null");
    }

    [Test]
    public void RemoveShouldReturnCorrectData()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Polina", 20);
        repository.Create(hero);
        bool actualDataRemove = repository.Remove("Polina");
        bool expectedDataRemove = true;

        Assert.AreEqual(expectedDataRemove, actualDataRemove);
      
    }

    [Test]
    public void GetHighestResultShouldReturnCorrectData()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Polina", 20);
        Hero hero1 = new Hero("Maria", 15);
        repository.Create(hero);
        repository.Create(hero1);

        Hero actualHero = repository.GetHeroWithHighestLevel();
        string actualHeroName = actualHero.Name;
        int actualHeroLevel = actualHero.Level;

        Hero expectedHero = new Hero("Polina" ,20);
        string expectedHeroName = "Polina";
        int expectedHeroLevel = 20;

        Assert.AreEqual(expectedHeroName, actualHeroName);
        Assert.AreEqual(expectedHeroLevel, actualHeroLevel);

    }

    [Test]
    public void GetHeroShouldReturnCorrectData()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Polina", 20);
        Hero hero1 = new Hero("Maria", 15);
        repository.Create(hero);
        repository.Create(hero1);

        Hero actualHero = repository.GetHero("Polina");
        string actualHeroName = actualHero.Name;
        int actualHeroLevel = actualHero.Level;

        Hero expectedHero = new Hero("Polina", 20);
        string expectedHeroName = "Polina";
        int expectedHeroLevel = 20;

        Assert.AreEqual(expectedHeroName, actualHeroName);
        Assert.AreEqual(expectedHeroLevel, actualHeroLevel);

    }
}