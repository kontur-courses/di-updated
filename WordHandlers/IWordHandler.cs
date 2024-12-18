using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordHandlers
{
    public interface IWordHandler
    {
        public static abstract IEnumerable<string> ApplyWordHandler(IEnumerable<string> words);
    }
}
