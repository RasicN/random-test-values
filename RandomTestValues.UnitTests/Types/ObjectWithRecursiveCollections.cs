using System.Collections.Generic;

namespace RandomTestValues.UnitTests.Types
{
    public class ObjectWithRecursiveCollections
    {
        public IEnumerable<ObjectWithRecursiveCollections> RecursiveIEnumerable { get; set; }
        public ICollection<ObjectWithRecursiveCollections> RecursiveICollection { get; set; }
        public ICollection<ObjectWithRecursiveCollections> RecursiveCollection { get; set; }
        public IList<ObjectWithRecursiveCollections> RecursiveIList { get; set; }
        public List<ObjectWithRecursiveCollections> RecursiveList { get; set; }
        public ObjectWithRecursiveCollections[] RecursiveArray { get; set; }
        public IDictionary<int, ObjectWithRecursiveCollections> RecursiveIDictionary { get; set; }
        public Dictionary<int, ObjectWithRecursiveCollections> RecursiveDictionary { get; set; }

        public int Int { get; set; }
    }
}
