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

    [Test]
    public void TestAddItemToLibrary()
    {
        var library = new library(DateTime.Now);
        book book1 = new book("bijbel", "godsdienst", "vele mensen", "nederlands");

        Assert.AreEqual(library.books.Count,0);
        library.addItem(book1);
        Assert.AreEqual(library.books.Count,1);
        Assert.AreEqual(library.books[0],book1);
    }
}