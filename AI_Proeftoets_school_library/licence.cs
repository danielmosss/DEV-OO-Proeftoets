using System.Transactions;

namespace AI_Proeftoets_school_library;

public abstract class licence
{
    public string name { get; set; }
    public int MaxBooks { get; set; }
    public double PricePerFilm { get; set; }
    public double PricePerGame { get; set; }

    public bool FirstFilmFree { get; set; }
    public bool FirstGameFree { get; set; }
    public DateTime validUntil { get; set; }

    public abstract void SetValidUntil();
}

public class beginner : licence
{
    public beginner(DateTime validUntil)
    {
        this.name = "beginner";
        this.MaxBooks = 3;
        this.validUntil = validUntil;
        this.PricePerFilm = 0.30;
        this.PricePerGame = 0.6;
        this.FirstFilmFree = false;
        this.FirstGameFree = false;
    }

    public override void SetValidUntil()
    {
        validUntil = DateTime.Now.AddDays(7);
    }
}

public class pro : licence
{
    public pro(DateTime validUntil)
    {
        this.name = "pro";
        this.MaxBooks = 5;
        this.validUntil = validUntil;
        this.PricePerFilm = 0.15;
        this.PricePerGame = 0.30;
        this.FirstFilmFree = false;
        this.FirstGameFree = false;
    }

    public override void SetValidUntil()
    {
        validUntil = DateTime.Now.AddDays(14);
    }
}

public class nerd : licence
{
    public nerd(DateTime validUntil)
    {
        this.name = "nerd";
        this.MaxBooks = 8;
        this.validUntil = validUntil;
        this.PricePerFilm = 0.15;
        this.PricePerGame = 0.30;
        this.FirstFilmFree = true;
        this.FirstGameFree = true;
    }

    public override void SetValidUntil()
    {
        validUntil = DateTime.Now.AddDays(28);
    }
}

//
// public class licence2
// {
//     public string name { get; set; }
//     private int MaxBooks { get; set; }
//     
//     private int MaxFilms { get; set; }
//     private double PricePerFilm { get; set; }
//     private bool FirstFilmFree { get; set; }
//     
//     private int MaxGames { get; set; }
//     private double PricePerGame { get; set; }
//     private bool FirstGameFree { get; set; }
//     
//     private DateTime validUntil { get; set; }
//
//     public licence(string name, int MBooks, int MFilms, int MGames, DateTime validUntil, double PricePerFilm, double PricePerGame, bool FirstFilmFree, bool FirstGameFree)
//     {
//         this.name = name;
//         MaxBooks = MBooks;
//         MaxFilms = MFilms;
//         MaxGames = MGames;
//         this.validUntil = validUntil;
//         this.PricePerFilm = PricePerFilm;
//         this.PricePerGame = PricePerGame;
//         this.FirstFilmFree = FirstFilmFree;
//         this.FirstGameFree = FirstGameFree;
//     }
//     
//     public bool IsValid(DateTime date)
//     {
//         return date < validUntil;
//     }
//     
//     public double GetPriceForFilm()
//     {
//         if (FirstFilmFree)
//         {
//             return 0;
//         }
//         return PricePerFilm;
//     } 
//     
//     public double GetPriceForGame()
//     {
//         if (FirstGameFree)
//         {
//             return 0;
//         }
//         return PricePerGame;
//     }
//     
//     public void SetValidUntil(DateTime date)
//     {
//         validUntil = date;
//     }
//
//     public int GetMaxBooks()
//     {
//         return MaxBooks;
//     }
// }