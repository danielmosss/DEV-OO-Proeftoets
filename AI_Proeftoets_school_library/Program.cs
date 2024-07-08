using AI_Proeftoets_school_library;

Console.WriteLine("Hello, World!");

library BierBib = new library(DateTime.Now);

book book1 = new book("The Bitcoin Standard", "Economics", "Saifedean Ammous", "English");
book book2 = new book("The 48 Laws of Power", "Self-help", "Robert Greene", "English");
book book3 = new book("The Art of War", "Strategy", "Sun Tzu", "English");

film film1 = new film("The Godfather", "Crime", "Francis Ford Coppola", "English");
film film2 = new film("The Shawshank Redemption", "Drama", "Frank Darabont", "English");
film film3 = new film("The Dark Knight", "Action", "Christopher Nolan", "English");

game game1 = new game("MineCraft", "Sandbox", "Markus Persson", "English");
game game2 = new game("Golf with your Friends", "Sports", "Blacklight Interactive", "English");
game game3 = new game("Asserto Corsa", "Racing", "Kunos Simulazioni", "English");

BierBib.addItem(book1);
BierBib.addItem(book2);
BierBib.addItem(book3);

BierBib.addItem(film1);
BierBib.addItem(film2);
BierBib.addItem(film3);

BierBib.addItem(game1);
BierBib.addItem(game2);
BierBib.addItem(game3);

user ActiveUser = null;
PrintMenu();

void PrintMenu()
{
    if (ActiveUser == null)
    {
        Console.WriteLine("SELECTEER EEN GEBRUIKER, NU");
        PrintUsers();
    }
    else
    {
        Console.WriteLine("1. Voeg een item toe.");
        Console.WriteLine("2. Verwijder een item.");
        Console.WriteLine("3. Bekijk items.");
        Console.WriteLine("4. Bekijk gebruiker.");
        Console.WriteLine("5. Leen een item.");
        Console.WriteLine("6. Breng een item terug.");
        Console.WriteLine("7. Wissel van gebruiker.");
        Console.WriteLine("8. Ga naar de volgende dag.");
        Console.WriteLine("9. Voeg balans toe.");
        Console.WriteLine("10. Bekijk alle items van gebruiker.");
        Console.WriteLine("Kies een optie.");
        
        var input = int.Parse(Console.ReadLine());
        switch (input)
        {
            case 1:
                AddItemLibrary();
                break;
            case 2:
                RemoveItemLibrary();
                break;
            case 3:
                ShowItems();
                break;
            case 4:
                Console.WriteLine("Gebruiker: " + ActiveUser.name);
                Console.WriteLine("Licentie: " + ActiveUser.licence.name);
                Console.WriteLine("Balans: " + ActiveUser.GetBalance());
                PrintMenu();
                break;
            case 5:
                LeenItem();
                break;
            case 6:
                BrengItemTerug();
                break;
            case 7:
                ActiveUser = null;
                // update user in library otherwise all changes will be lost
                
                PrintMenu();
                break;
            case 8:
                HandleNextDay();
                break;
            case 9:
                AddBalance();
                break;
            case 10:
                ViewAllItemsOfUser();
                break;
            default:
                Console.WriteLine("Ongeldige invoer.");
                PrintMenu();
                break;
        }
    }
}

void PrintUsers()
{
    var users = BierBib.getUsernames();
    if (users.Count != 0)
    {
        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine(i + ". " + BierBib.getUsernames()[i]);
        }

        Console.WriteLine($"{users.Count + 1}. Maak een nieuwe gebruiker aan.");
        Console.WriteLine("Selecteer een gebruiker, type het nummer.");

        var input = int.Parse(Console.ReadLine());

        if (input == users.Count + 1)
        {
            ActiveUser = CreateUser();
        }
        else
        {
            try
            {
                ActiveUser = BierBib.getUser(input);
            }
            catch (Exception e)
            {
                Console.WriteLine("Gebruiker niet gevonden.");
            }
        }
        PrintMenu();
    }
    else
    {
        var user = CreateUser();
        ActiveUser = user;
        PrintMenu();
    }
}

user CreateUser()
{
    Console.WriteLine("What is you name?");
    var name = Console.ReadLine();
    if (name == null || name == "")
    {
        name = "John Doe " + new Random().Next(1000);
    }

    for (int i = 0; i < BierBib.licences.Count; i++)
    {
        Console.WriteLine(i + ". " + BierBib.licences[i].name);
    }

    Console.WriteLine("Selecteer een licentie, type het nummer.");
    var licence = BierBib.licences[int.Parse(Console.ReadLine())];

    var user = new user(name, 50, licence);
    BierBib.addUser(user);
    return user;
}

void AddItemLibrary()
{
    Console.WriteLine("1. Boek");
    Console.WriteLine("2. Film");
    Console.WriteLine("3. Game");
    Console.WriteLine("Kies een optie.");
    var input = int.Parse(Console.ReadLine());
    
    Console.WriteLine("Naam:");
    var name = Console.ReadLine();
    
    Console.WriteLine("Genre:");
    var genre = Console.ReadLine();
    
    Console.WriteLine("Auteur:");
    var author = Console.ReadLine();
    
    Console.WriteLine("Taal:");
    var language = Console.ReadLine();
    
    switch (input)
    {
        case 1:
            BierBib.addItem(new book(name, genre, author, language));
            break;
        case 2:
            BierBib.addItem(new film(name, genre, author, language));
            break;
        case 3:
            BierBib.addItem(new game(name, genre, author, language));
            break;
        default:
            Console.WriteLine("Ongeldige invoer.");
            break;
    }
    PrintMenu();
}

void RemoveItemLibrary()
{
    Console.WriteLine("1. Boek");
    Console.WriteLine("2. Film");
    Console.WriteLine("3. Game");
    Console.WriteLine("Kies een optie.");
    var input = int.Parse(Console.ReadLine());

    for (int i = 0; i < BierBib.books.Count; i++)
    {
        Console.WriteLine(i + ". " + BierBib.books[i].name);
    }
    Console.WriteLine("Kies een item, type het nummer.");
    var item = BierBib.books[int.Parse(Console.ReadLine())];
    BierBib.removeItem(item);
    Console.WriteLine("Item verwijderd.");
    PrintMenu();
}

void ShowItems()
{
    Console.WriteLine("1. Boek");
    Console.WriteLine("2. Film");
    Console.WriteLine("3. Game");
    Console.WriteLine("Kies een optie.");
    var input = int.Parse(Console.ReadLine());
    
    switch (input)
    {
        case 1:
            foreach (var book in BierBib.books)
            {
                Console.WriteLine(book.name);
            }
            break;
        case 2:
            foreach (var film in BierBib.films)
            {
                Console.WriteLine(film.name);
            }
            break;
        case 3:
            foreach (var game in BierBib.games)
            {
                Console.WriteLine(game.name);
            }
            break;
        default:
            Console.WriteLine("Ongeldige invoer.");
            break;
    }
    PrintMenu();
}

void LeenItem()
{
    Console.WriteLine("1. Boek");
    Console.WriteLine("2. Film");
    Console.WriteLine("3. Game");
    Console.WriteLine("Kies een optie.");
    var input = int.Parse(Console.ReadLine());
    
    Item item = null;
    switch (input)
    {
        case 1:
            for (int i = 0; i < BierBib.books.Count; i++)
            {
                Console.WriteLine(i + ". " + BierBib.books[i].name);
            }
            Console.WriteLine("Kies een item, type het nummer.");
            item = BierBib.books[int.Parse(Console.ReadLine())];
            break;
        case 2:
            for (int i = 0; i < BierBib.films.Count; i++)
            {
                Console.WriteLine(i + ". " + BierBib.films[i].name);
            }
            Console.WriteLine("Kies een item, type het nummer.");
            item = BierBib.films[int.Parse(Console.ReadLine())];
            break;
        case 3:
            for (int i = 0; i < BierBib.games.Count; i++)
            {
                Console.WriteLine(i + ". " + BierBib.games[i].name);
            }
            Console.WriteLine("Kies een item, type het nummer.");
            item = BierBib.games[int.Parse(Console.ReadLine())];
            break;
        default:
            Console.WriteLine("Ongeldige invoer.");
            break;
    }
    
    ActiveUser.addItem(item);
    BierBib.removeItem(item);
    Console.WriteLine("Item toegevoegd.");
    PrintMenu();
}

void ViewAllItemsOfUser()
{
    var items = ActiveUser.getItems();
    foreach (var item in items)
    {
        Console.WriteLine(item.name);
    }
    PrintMenu();
}

void BrengItemTerug()
{
    PrintMenu();
}

void HandleNextDay()
{
    PrintMenu();
}

void AddBalance()
{
    Console.WriteLine("Hoeveel wil je toevoegen?");
    var input = double.Parse(Console.ReadLine());
    ActiveUser.AddBalance(input);
    Console.WriteLine($"{ActiveUser.GetBalance()} is nu je nieuwe balance.");
        PrintMenu();
}
