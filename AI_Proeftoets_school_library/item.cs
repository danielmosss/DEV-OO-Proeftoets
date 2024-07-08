namespace AI_Proeftoets_school_library;

public class Item
{
    public string name { get; set; }
    public string author { get; set; }
    public string genre { get; set; }
    public string language { get; set; }
}

public class book : Item
{
    public string name;
    public book(string name, string genre, string author, string language)
    {
        this.name = name;
        this.genre = genre;
        this.author = author;
        this.language = language;
    }
}

public class film : Item
{
    public film(string name, string genre, string author, string language)
    {
        this.name = name;
        this.genre = genre;
        this.author = author;
        this.language = language;
    }
}

public class game : Item
{
    public game(string name, string genre, string author, string language)
    {
        this.name = name;
        this.genre = genre;
        this.author = author;
        this.language = language;
    }
}