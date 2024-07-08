namespace AI_Proeftoets_school_library;

public class user
{
    public string name { get; set; }
    private double balance;
    public licence licence;
    
    private List<book> bookiess = new List<book>();
    private List<film> slechtereYoutube = new List<film>();
    private List<game> games = new List<game>();
    
    public user(string name, double balance, licence licence)
    {
        this.name = name;
        this.balance = balance;
        this.licence = licence;
    }
    
    public void addItem(Item item)
    {
        if (item is book)
        {
            bookiess.Add((book)item);
        }
        else if (item is film)
        {
            slechtereYoutube.Add((film)item);
        }
        else if (item is game)
        {
            games.Add((game)item);
        }
    }
    
    public void removeItem(Item item)
    {
        if (item is book)
        {
            bookiess.Remove((book)item);
        }
        else if (item is film)
        {
            slechtereYoutube.Remove((film)item);
        }
        else if (item is game)
        {
            games.Remove((game)item);
        }
    }
    
    public List<Item> getItems()
    {
        List<Item> items = new List<Item>();
        items.AddRange(bookiess);
        items.AddRange(slechtereYoutube);
        items.AddRange(games);
        return items;
    }

    public List<book> getBooks()
    {
        return bookiess;
    }
    
    public double GetBalance()
    {
        return balance;
    }
    
    public void AddBalance(double amount)
    {
        balance += amount;
    }
}