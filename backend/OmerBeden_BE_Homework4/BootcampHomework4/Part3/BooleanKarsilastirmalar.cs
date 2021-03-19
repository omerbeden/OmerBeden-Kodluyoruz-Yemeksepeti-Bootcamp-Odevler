using System;
using System.Collections.Generic;
using System.Text;

namespace Part3
{
    class BooleanKarsilastirmalar
    {
        private const string rootPath=@"C:\root";
        
        
        public static bool isRoot(string path)
        {
            return rootPath == path;
        }
    }
}
