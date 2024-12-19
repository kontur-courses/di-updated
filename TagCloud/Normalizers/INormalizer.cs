namespace TagCloud.Normalizers
{
    // Интерфейс нормализации количества каждого слова
    internal interface INormalizer
    {
        public Dictionary<string, double> Normalize(Dictionary<string, uint> values);
    }
}
