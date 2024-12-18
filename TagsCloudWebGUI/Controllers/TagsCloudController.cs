using Microsoft.AspNetCore.Mvc;
using TagsCloudContainer;

namespace TagsWebGUI.Controllers;

public class TagsCloudController(AppConfig appConfig, App app) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(appConfig); // Отображает текущие настройки
    }

    [HttpPost]
    public IActionResult GenerateImage(AppConfig config, string excludedWords)
    {
        appConfig.MaxSize = config.MaxSize;
        appConfig.MinSize = config.MinSize;
        appConfig.BackgroundColor = config.BackgroundColor;
        appConfig.FontFamily = config.FontFamily;
        appConfig.TextColor = config.TextColor;
        appConfig.TextFilePath = config.TextFilePath;
        appConfig.Width = config.Width;
        appConfig.Height = config.Height;
        appConfig.AngleStep = config.AngleStep;
        appConfig.RadiusStep = config.RadiusStep;
        appConfig.LayoutType = config.LayoutType;
        
        if (!string.IsNullOrEmpty(excludedWords))
        {
            appConfig.ExcludedWords = excludedWords.Split(',')
                .Select(word => word.Trim())
                .ToHashSet();
        }
            
        app.Run();

        ViewBag.ImagePath = Path.Combine("images", appConfig.Filename);
        return View("Index", appConfig);
    }
}