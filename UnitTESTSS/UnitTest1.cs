using AI_Proeftoets_school_library;

namespace UnitTESTSS;


public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    
    [Test]
    public void CreateLicenceBeginner()
    {
        var licence = new beginner(DateTime.Now);
        Assert.AreEqual("beginner", licence.name);
        Assert.AreEqual(3, licence.MaxBooks);
        Assert.AreEqual(0.30, licence.PricePerFilm);
        Assert.AreEqual(0.6, licence.PricePerGame);
        Assert.AreEqual(false, licence.FirstFilmFree);
    }
}