namespace MtgApiProject;

public class MtgCard
{
    public string Name { get; set; }
    public IDictionary<string, bool> Legality;

    public bool IsLegalInFormat(string format) => Legality.TryGetValue(format, out var legality) && legality;
}