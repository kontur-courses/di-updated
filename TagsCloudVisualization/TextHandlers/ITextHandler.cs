namespace TagsCloudVisualization.TextHandlers;

public interface ITextHandler
{
    /// <summary>
    /// Метод-обработчик исходного текста
    /// </summary>
    /// <returns> Словарь: слово - количество </returns>
    Dictionary<string, int> HandleText();
}