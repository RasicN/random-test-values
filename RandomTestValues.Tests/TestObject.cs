using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RandomTestValues.Tests
{
    public class TestObject
    {
        public int RInt { get; set; }
        public string RString { get; set; } 
        public decimal RDecimal { get; set; }
        public double RDouble { get; set; }
        public int RInt2 { get; set; }
        public string RString2 { get; set; }
        public decimal RDecimal2{ get; set; }
        public double RDouble2 { get; set; }
        public TestEnum REnum { get; set; }
        public TestObject2 TestObject2 { get; set; }
        public TestObject2 TestObject3 { get; set; }
        public List<double> RList { get; set; }
        public IList<string> RList2 { get; set; }
        public Collection<int> RCollection { get; set; }
        public ICollection<bool> RCollection2 { get; set; }
    }
}
