using System;

namespace RandomTestValues.UnitTests.Types
{
    public class TestObjectWithConstructor
    {
        public TestObjectWithConstructor(int testInt, string testString)
        {
            TestInt = testInt;
            TestString = testString;
        }

        public int TestInt { get; set; }
        public string TestString { get; set; }
        public Guid TestGuid { get; set; }

    }
}
