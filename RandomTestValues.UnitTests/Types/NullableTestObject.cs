using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RandomTestValues.UnitTests.Types
{
    public class NullableTestObject
    {
        public int? RInt { get; set; }
        public decimal? RDecimal { get; set; }
        public double? RDouble { get; set; }
        public int? RInt2 { get; set; }
        public decimal? RDecimal2 { get; set; }
        public double? RDouble2 { get; set; }
        public TestEnum? REnum { get; set; }
        public ICollection<TestEnum?> REnumCollection { get; set; }
        public IList<TestEnum?> REnumList { get; set; }
        public Guid? RGuid { get; set; }
        public List<double?> RList { get; set; }
        public Collection<int?> RCollection { get; set; }
        public ICollection<bool?> RCollection2 { get; set; }
        public DateTime? RDateTime { get; set; }
        public IEnumerable<short?> Shorts { get; set; }
        public IEnumerable<List<Collection<bool?>>> CrazyBools { get; set; }
        public string GetOnly => "Test";
    }
}
