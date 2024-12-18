using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHelpers.TagCloudLayouterTests.Helpers.RectangleOnlyVisualiser
{
    public interface IRectangleVisualiser : IDisposable
    {
        public void DrawRectangle(Bitmap bitmap, Rectangle rectangle);
    }
}
