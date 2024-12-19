using System.Drawing;

namespace TagCloud
{
    // В дальнейшем буду работать с сущностью Tag,
    // имеющей похожую структуру
    internal record Tag(string Text, Rectangle Rectangle);
}
