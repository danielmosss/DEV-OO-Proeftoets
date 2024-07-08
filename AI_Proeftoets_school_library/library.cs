namespace AI_Proeftoets_school_library;

public class library
{
    public List<book> books = new List<book>();
    public List<film> films = new List<film>();
    public List<game> games = new List<game>();

    private List<user> users = new List<user>();
    public DateTime date;

    public List<licence> licences = new List<licence>();

    public library(DateTime date)
    {
        this.date = date;

        licence beginner = new beginner(DateTime.Now);
        licence pro = new pro(DateTime.Now);
        licence nerd = new nerd(DateTime.Now);

        licences.Add(beginner);
        licences.Add(pro);
        licences.Add(nerd);
    }

    public void addItem(Item item)
    {
        if (item is book)
        {
            books.Add((book)item);
        }
        else if (item is film)
        {
            films.Add((film)item);
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
            books.Remove((book)item);
        }
        else if (item is film)
        {
            films.Remove((film)item);
        }
        else if (item is game)
        {
            games.Remove((game)item);
        }
    }

    public List<string> getUsernames()
    {
        List<string> userNames = new List<string>();
        foreach (user user in users)
        {
            userNames.Add(user.name);
        }

        return userNames;
    }
    
    public user getUser(int index)
    {
        if (index < 0 || index >= users.Count)
        {
            throw new IndexOutOfRangeException();
        }
        return users[index];
    }
    
    public void addUser(user user)
    {
        users.Add(user);
    }
}
