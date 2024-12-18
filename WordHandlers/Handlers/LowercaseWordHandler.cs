using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordHandlers.Handlers
{
    public class LowercaseWordHandler : IWordHandler
    {
        public static IEnumerable<string> ApplyWordHandler(IEnumerable<string> words)
        {
            return words.Select(w => w.ToLower());
        }
    }
}
