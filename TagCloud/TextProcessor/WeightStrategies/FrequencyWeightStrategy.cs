public class FrequencyWeightStrategy : IWeightStrategy
{
    private readonly Dictionary<string, int> _frequency = new();
    
    public int CalculateWeight(string text)
    {
        return _frequency.TryGetValue(text, value: out var value) ? value : 1;
    }
    
    public void AddOccurrence(string text)
    {
        _frequency.TryAdd(text, 0);
        _frequency[text]++;
    }
}