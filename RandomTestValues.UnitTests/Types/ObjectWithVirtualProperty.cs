namespace RandomTestValues.UnitTests.Types
{
    public class ObjectWithRecursiveProperty
    {
        public virtual ObjectWithRecursiveProperty RecursiveProperty { get; set; }

        public ObjectWithRecursiveProperty RecursiveProperty2 { get; set; }

        public int Int { get; set; }
    }
}
