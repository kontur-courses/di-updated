using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordHandlers.Handlers
{
    public class BoringWordHandler : IWordHandler
    {
        //Прокрастинация, потом добавим
        public static IEnumerable<string> ApplyWordHandler(IEnumerable<string> words)
        {
            throw new NotImplementedException();
        }
    }
}
