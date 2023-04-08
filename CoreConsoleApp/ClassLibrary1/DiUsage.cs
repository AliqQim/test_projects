using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class DiUsage
    {
        public static void DoIt()
        {
            new Container().Run(x => x.f());
        }
    }
}
