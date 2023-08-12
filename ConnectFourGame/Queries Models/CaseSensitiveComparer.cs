using System;
using System.Collections.Generic;

namespace ClientModels.Queries_Models
{
    public class CaseSensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.Ordinal);
        }
    }
}
