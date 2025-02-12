using LINQRevision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBigTask
{
    public class CaseInSenstive : IComparer<string>
    {

        public int Compare(string? x, string? y)
        {
            if (string.IsNullOrEmpty(x) && string.IsNullOrEmpty(y) ) return 0;
            if (string.IsNullOrEmpty(x)) return -1; 
            if (string.IsNullOrEmpty(y)) return 1;  

            return string.Compare(x, y ,StringComparison.OrdinalIgnoreCase);
         
        }
    }
}
