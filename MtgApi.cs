using Newtonsoft.Json.Linq;

namespace MtgApiProject;

public class MtgApi
{
    public static async Task<JToken?> GetRandCard()
    {
        var client = new HttpClient();
        var mtgUrl = "https://api.magicthegathering.io/v1/cards?random=true&pageSize=1";
        var cardsResponse = await client.GetStringAsync(mtgUrl);

        var cardsParsed = JObject.Parse(cardsResponse).GetValue("cards");

        return cardsParsed;
    }

    public static async Task<string> GetText(JToken? card)
    {
        var cardBaseText = card[0].Value<string>("text");
        var cardFlavour = card[0].Value<string>("flavor") ?? "No flavour text";
        

        return $"Text: {cardBaseText}\nFlavour: {cardFlavour}";
    }
}