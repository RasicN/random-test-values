namespace RandomTestValues.UnitTests.Types
{
    public class CircularTypes1
    {
        public string SomeString1 { get; set; }
        public CircularTypes2 CircularType2 { get; set; }
    }

    public class CircularTypes2
    {
        public string SomeString2 { get; set; }
        public CircularTypes1 CircularType1 { get; set; }
    }
}
