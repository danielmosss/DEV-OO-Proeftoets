// See https://aka.ms/new-console-template for more information

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
        // - toevoegen van items (film,boek,game(name, genre, author, language))
        Console.WriteLine("1. Voeg een item toe.");
        // - verwijderen van items (film,boek,game)
        Console.WriteLine("2. Verwijder een item.");
        // - bekijken van items (film,boek,game)
        Console.WriteLine("3. Bekijk items.");
        // - bekijken van gebruiker, huidige
        Console.WriteLine("4. Bekijk gebruiker.");
        // - item lenen (max 21 dagen, + check licentie)
        Console.WriteLine("5. Leen een item.");
        // - item terugbrengen
        Console.WriteLine("6. Breng een item terug.");
        // - gebruiker wisselen
        Console.WriteLine("7. Wissel van gebruiker.");
        // - naar de volgende dag gaan
        Console.WriteLine("8. Ga naar de volgende dag.");
        Console.WriteLine("9. Voeg balans toe.");
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
                break;
            case 5:
                LeenItem();
                break;
            case 6:
                BrengItemTerug();
                break;
            case 7:
                ActiveUser = null;
                PrintMenu();
                break;
            case 8:
                HandleNextDay();
                break;
            
            PrintMenu();
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
    return user;
}