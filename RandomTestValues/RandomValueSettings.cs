using System;

namespace RandomTestValues
{
    public class RandomValueSettings
    {
        private static readonly Random _Random = new Random();

        private int? lengthOfCollection;

        public RandomValueSettings()
        {
            SetDefaultSettings();
        }

        public RandomValueSettings(int? lengthOfCollection)
        {
            SetDefaultSettings();

            this.lengthOfCollection = lengthOfCollection;
        }

        public bool IncludeNullAsPossibleValueForNullables { get; set; }
        public int RecursiveDepth { get; set; }

        public int LengthOfCollection
        {
            get
            {
                return lengthOfCollection ?? _Random.Next(1, 10);
            }
            set
            {
                lengthOfCollection = value;
            }
        }

        private void SetDefaultSettings()
        {
            IncludeNullAsPossibleValueForNullables = false;
            RecursiveDepth = 0;
        }
    }
}
