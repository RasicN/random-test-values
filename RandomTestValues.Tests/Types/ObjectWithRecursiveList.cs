using System.Collections.Generic;

namespace RandomTestValues.Tests.Types
{
    public class ObjectWithRecursiveList
    {
        public List<ObjectWithRecursiveList> RecursiveList { get; set; }

        public int Int { get; set; }
    }
}
