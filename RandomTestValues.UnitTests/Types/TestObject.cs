using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RandomTestValues.UnitTests.Types
{
    public class TestObject
    {
        public int RInt { get; set; }
        public string RString { get; set; }
        public decimal RDecimal { get; set; }
        public double RDouble { get; set; }
        public int RInt2 { get; set; }
        public string RString2 { get; set; }
        public decimal RDecimal2 { get; set; }
        public double RDouble2 { get; set; }
        public TestEnum REnum { get; set; }
        public ICollection<TestEnum> REnumCollection { get; set; }
        public IList<TestEnum> REnumList { get; set; }
        public Guid RGuid { get; set; }
        public TestObject2 TestObject2 { get; set; }
        public TestObject2 TestObject3 { get; set; }
        public List<double> RList { get; set; }
        public IList<string> RList2 { get; set; }
        public Collection<int> RCollection { get; set; }
        public ICollection<bool> RCollection2 { get; set; }
        public List<TestObject2> RTestObject2List { get; set; }
        public ICollection<TestObject2> RTestObject2Collection { get; set; }
        public DateTime RDateTime { get; set; }
        public IEnumerable<short> Shorts { get; set; }
        public IEnumerable<List<Collection<bool>>> CrazyBools { get; set; }
        public string GetOnly => "Test";
        public string[] Strings { get; set; }
        public TestObject2[] RTestObject2Array { get; set; }
        public TimeSpan TimeSpan { get; set; }

        public IDictionary<TimeSpan, Collection<bool>> RIDictionary {get;set;}

        public Dictionary<DateTime, int> RDictionary { get; set; }

        public DateTimeOffset DateTimeOffset { get; set; }
        public Uri RUri { get; set; }
    }
}
