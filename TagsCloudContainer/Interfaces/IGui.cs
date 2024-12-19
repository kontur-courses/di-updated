namespace TagsCloudContainer.Interfaces;

public record InputParameters(string InputFilePath, string OutputFilePath);

public interface IGui
{
    public InputParameters GetInputParameters();
}