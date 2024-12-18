using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagCloud.RayMovers;
using TagCloud;
using TagCloud.SpiralPointGenerators;
using TestHelpers.TagCloudLayouterTests.Helpers.RectangleOnlyVisualiser;
using Tests.TagCloudLayouterTests.TestHelpers;
using NUnit.Framework.Interfaces;

namespace Tests.TagCloudLayouterTests
{
    [TestFixture]
    public class SquareTagCloudTests : BaseTagCloudTests
    {
        public override void Setup()
        {
            _center = new Point(WIDTH / 2, HEIGHT / 2);

            var mover = new SquareSpiralPointCreator(_center, 2, 2);

            _layouter = new TagCloudLayouter(mover);

            _visualiser = new RectangleVisualiser(Color.Black, 1);

            _tagCloudImageGenerator = new TagCloudImageGenerator(_visualiser);

            _errorImageSize = new Size(WIDTH, HEIGHT);
        }

        public override void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                using var errorBitmap = _tagCloudImageGenerator.CreateNewBitmap(_errorImageSize, _layouter.Rectangles);

                var fileName = $"{TestContext.CurrentContext.Test.MethodName + Guid.NewGuid()}.png";
                BitmapSaver.SaveToFail(errorBitmap, "Square", fileName);
            }
            else if (_layouter.Rectangles.Count > 0)
            {
                using var correctBitmap = _tagCloudImageGenerator.CreateNewBitmap(_errorImageSize, _layouter.Rectangles);

                var fileName = $"{TestContext.CurrentContext.Test.MethodName + Guid.NewGuid()}.png";
                BitmapSaver.SaveToCorrect(correctBitmap, "Square", fileName);
            }

            _visualiser.Dispose();
            _tagCloudImageGenerator.Dispose();
        }

        [Ignore("Not applicable")]
        public override void TagCloudLayouter_WhenCreated_FirstPointEqualsCenter()
        {
            base.TagCloudLayouter_WhenCreated_FirstPointEqualsCenter();
        }
    }
}
