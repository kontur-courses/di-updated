namespace TagCloud.Utility;

public static class EnumerableExtensions
{
    public static string Join(this IEnumerable<string> words, string separator = "") => string.Join(separator, words);
    
    public static IEnumerable<string> ToLower(this IEnumerable<string> words) => words.Select(w => w.ToLower());
}