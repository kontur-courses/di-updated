using System.Drawing;
using Autofac;
using TagsCloudContainer;
using TagsCloudVisualization;
using TagsCloudVisualization.Interfaces;

var container = DependencyInjectionConfig.BuildContainer();

using var scope = container.BeginLifetimeScope();
var tagCloudGenerator = scope.Resolve<ITagCloudGenerator>();

var inputFilePath = "input.txt";  
var outputFilePath = "output.png";
var imageSize = new Size(1000, 1000);

tagCloudGenerator.GenerateCloud(inputFilePath, outputFilePath, imageSize);