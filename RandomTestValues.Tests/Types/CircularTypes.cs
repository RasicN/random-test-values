using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomTestValues.Tests.Types
{
    public class CircularTypes1
    {
        public string SomeString1 { get; set; }
        public CircularTypes2 Circular { get; set; }
    }

    public class CircularTypes2
    {
        public string SomeString2 { get; set; }
        public CircularTypes1 Circular { get; set; }
    }
}
