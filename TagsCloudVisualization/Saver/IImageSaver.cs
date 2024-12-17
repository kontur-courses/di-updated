using TagsCloudVisualization.Draw;

namespace TagsCloudVisualization.Saver;

public interface IImageSaver
{
    public void SaveImageToFile(IRectangleDraftsman rectangleDraftsman, string filename);
}