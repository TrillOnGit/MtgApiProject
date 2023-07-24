namespace MtgApiProject;

public class MtgDeck
{
    public List<MtgCard> Cards;

    public void Shuffle()
    {
        var rng = new Random();
        
        int deckLength = Cards.Count;

        while (deckLength > 1)
        {
            deckLength--;
            int randLocale = rng.Next(deckLength + 1);
            (Cards[randLocale], Cards[deckLength]) = (Cards[deckLength], Cards[randLocale]);
            
        }
    }

    public int GetNumCards()
    {
        return Cards.Count;
    }

    public static int GetStandardMinimum()
    {
        return 60;
    }

    public static int GetEdhMinimum()
    {
        return 100;
    }

    public MtgCard[] Draw(int numCard)
    {
        var cardsDrawn = Cards.Take(numCard).ToArray();
        
        if (Cards.Count < numCard)
        {
            Console.WriteLine("Bottomed Out");
        }
        
        Cards.RemoveRange(0, Math.Min(numCard, Cards.Count));

        return cardsDrawn;
    }

    public bool IsStandardLegal()
    {
        return Cards.All(x => x.IsLegalInFormat("standard"));
    }

    public static bool IsCardEdhLegal(MtgCard card)
    {
        return card.IsLegalInFormat("EDH");
    }
}