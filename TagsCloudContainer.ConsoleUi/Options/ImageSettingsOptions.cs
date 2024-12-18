using System.Drawing;
using System.Drawing.Imaging;
using CommandLine;
using TagsCloudContainer.ConsoleUi.Options.Interfaces;

namespace TagsCloudContainer.ConsoleUi.Options;

[Verb("image", HelpText = "Настройка изображения")]
public class ImageSettingsOptions : IOptions
{
    [Option('w', "width", HelpText = "Ширина")]
    public int Width { get; set; }

    [Option('h', "height", HelpText = "Высота")]
    public int Height { get; set; }

    [Option('e', "extension", HelpText = "формат файла")]
    public ImageFormat ImageFormat { get; set; }

    [Option('b', "background", HelpText = "Цвет фона")]
    public Color BackgroundColor { get; set; }

    [Option('c', "color", HelpText = "Цвет слов")]
    public Color WordColor { get; set; }

    [Option('f', "font", HelpText = "Шрифт")]
    public FontFamily FontFamily { get; set; }
}