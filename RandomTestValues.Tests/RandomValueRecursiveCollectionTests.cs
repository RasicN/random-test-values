using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomTestValues.Tests.ShouldExtensions;
using RandomTestValues.Tests.Types;
using System.Linq;

namespace RandomTestValues.Tests
{
    [TestClass]
    public class RandomValueRecursiveCollectionTests
    {
        private readonly RandomValueSettings Depth2Settings = new RandomValueSettings { RecursiveDepth = 2, LengthOfCollection = 3 };

        [TestMethod]
        public void RandomLazyEnumerableWithRecursiveWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            var result = RandomValue.LazyIEnumerable<ObjectWithRecursiveCollections>(Depth2Settings);

            var depth1 = result.FirstOrDefault();
            depth1.RecursiveIEnumerable.ShouldNotBeDefault();
            depth1.Int.ShouldNotBeDefault();

            var depth2 = depth1.RecursiveIEnumerable.FirstOrDefault();
            depth2.RecursiveIEnumerable.ShouldNotBeDefault();
            depth2.Int.ShouldNotBeDefault();

            var depth3 = depth2.RecursiveIEnumerable.FirstOrDefault();
            depth3.RecursiveIEnumerable.ShouldEqual(null);
            depth3.Int.ShouldNotBeDefault();
        }

        [TestMethod]
        public void RandomIEnumerableWithRecursiveWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            var result = RandomValue.IEnumerable<ObjectWithRecursiveCollections>(Depth2Settings);

            var depth1 = result.FirstOrDefault();
            depth1.RecursiveIEnumerable.ShouldNotBeDefault();
            depth1.Int.ShouldNotBeDefault();

            var depth2 = depth1.RecursiveIEnumerable.FirstOrDefault();
            depth2.RecursiveIEnumerable.ShouldNotBeDefault();
            depth2.Int.ShouldNotBeDefault();

            var depth3 = depth2.RecursiveIEnumerable.FirstOrDefault();
            depth3.RecursiveIEnumerable.ShouldEqual(null);
            depth3.Int.ShouldNotBeDefault();
        }

        [TestMethod]
        public void RandomIColletionWithRecursiveWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            var result = RandomValue.ICollection<ObjectWithRecursiveCollections>(Depth2Settings);
            result.Count().ShouldBeInRange(1, 3);

            var depth1 = result.FirstOrDefault();
            depth1.RecursiveICollection.ShouldNotBeDefault();
            depth1.Int.ShouldNotBeDefault();
            depth1.RecursiveICollection.Count.ShouldBeInRange(1, 3);

            var depth2 = depth1.RecursiveICollection.FirstOrDefault();
            depth2.RecursiveICollection.ShouldNotBeDefault();
            depth2.Int.ShouldNotBeDefault();
            depth2.RecursiveICollection.Count.ShouldBeInRange(1, 3);

            var depth3 = depth2.RecursiveICollection.FirstOrDefault();
            depth3.RecursiveICollection.ShouldEqual(null);
            depth3.Int.ShouldNotBeDefault();
        }

        [TestMethod]
        public void RandomColletionWithRecursiveWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            var result = RandomValue.Collection<ObjectWithRecursiveCollections>(Depth2Settings);
            result.Count().ShouldBeInRange(1, 3);

            var depth1 = result.FirstOrDefault();
            depth1.RecursiveCollection.ShouldNotBeDefault();
            depth1.Int.ShouldNotBeDefault();
            depth1.RecursiveCollection.Count.ShouldBeInRange(1, 3);

            var depth2 = depth1.RecursiveCollection.FirstOrDefault();
            depth2.RecursiveCollection.ShouldNotBeDefault();
            depth2.Int.ShouldNotBeDefault();
            depth2.RecursiveCollection.Count.ShouldBeInRange(1, 3);

            var depth3 = depth2.RecursiveCollection.FirstOrDefault();
            depth3.RecursiveCollection.ShouldEqual(null);
            depth3.Int.ShouldNotBeDefault();
        }

        [TestMethod]
        public void RandomIListWithRecursiveWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            var result = RandomValue.IList<ObjectWithRecursiveCollections>(Depth2Settings);
            result.Count().ShouldBeInRange(1, 3);

            var depth1 = result.FirstOrDefault();
            depth1.RecursiveIList.ShouldNotBeDefault();
            depth1.Int.ShouldNotBeDefault();
            depth1.RecursiveIList.Count.ShouldBeInRange(1, 3);

            var depth2 = depth1.RecursiveIList.FirstOrDefault();
            depth2.RecursiveIList.ShouldNotBeDefault();
            depth2.Int.ShouldNotBeDefault();
            depth2.RecursiveIList.Count.ShouldBeInRange(1, 3);

            var depth3 = depth2.RecursiveIList.FirstOrDefault();
            depth3.RecursiveIList.ShouldEqual(null);
            depth3.Int.ShouldNotBeDefault();
        }

        [TestMethod]
        public void RandomListWithRecursiveWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            var result = RandomValue.List<ObjectWithRecursiveCollections>(Depth2Settings);
            result.Count().ShouldBeInRange(1, 3);

            var depth1 = result.FirstOrDefault();
            depth1.RecursiveList.ShouldNotBeDefault();
            depth1.Int.ShouldNotBeDefault();
            depth1.RecursiveList.Count.ShouldBeInRange(1, 3);

            var depth2 = depth1.RecursiveList.FirstOrDefault();
            depth2.RecursiveList.ShouldNotBeDefault();
            depth2.Int.ShouldNotBeDefault();
            depth2.RecursiveList.Count.ShouldBeInRange(1, 3);

            var depth3 = depth2.RecursiveList.FirstOrDefault();
            depth3.RecursiveList.ShouldEqual(null);
            depth3.Int.ShouldNotBeDefault();
        }

        [TestMethod]
        public void RandomArrayWithRecursiveWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            var result = RandomValue.Array<ObjectWithRecursiveCollections>(Depth2Settings);
            result.Count().ShouldBeInRange(1, 3);

            var depth1 = result.FirstOrDefault();
            depth1.RecursiveArray.ShouldNotBeDefault();
            depth1.Int.ShouldNotBeDefault();
            depth1.RecursiveArray.Length.ShouldBeInRange(1, 3);

            var depth2 = depth1.RecursiveArray.FirstOrDefault();
            depth2.RecursiveArray.ShouldNotBeDefault();
            depth2.Int.ShouldNotBeDefault();
            depth2.RecursiveArray.Length.ShouldBeInRange(1, 3);

            var depth3 = depth2.RecursiveArray.FirstOrDefault();
            depth3.RecursiveArray.ShouldEqual(null);
            depth3.Int.ShouldNotBeDefault();
        }

        [TestMethod]
        public void RandomIDictionaryWithRecursiveWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            var result = RandomValue.IDictionary<int, ObjectWithRecursiveCollections>(Depth2Settings);
            result.Count().ShouldBeInRange(1, 3);

            var depth1 = result.FirstOrDefault();
            depth1.Value.RecursiveIDictionary.ShouldNotBeDefault();
            depth1.Value.Int.ShouldNotBeDefault();
            depth1.Value.RecursiveIDictionary.Count.ShouldBeInRange(1, 3);

            var depth2 = depth1.Value.RecursiveIDictionary.FirstOrDefault();
            depth2.Value.RecursiveIDictionary.ShouldNotBeDefault();
            depth2.Value.Int.ShouldNotBeDefault();
            depth2.Value.RecursiveIDictionary.Count.ShouldBeInRange(1, 3);

            var depth3 = depth2.Value.RecursiveIDictionary.FirstOrDefault();
            depth3.Value.RecursiveIDictionary.ShouldEqual(null);
            depth3.Value.Int.ShouldNotBeDefault();
        }

        [TestMethod]
        public void RandomDictionaryWithRecursiveWillGenerateChildObjectsToTheSpecifiedDepthWithSettings()
        {
            var result = RandomValue.Dictionary<int, ObjectWithRecursiveCollections>(Depth2Settings);
            result.Count().ShouldBeInRange(1, 3);

            var depth1 = result.FirstOrDefault();
            depth1.Value.RecursiveDictionary.ShouldNotBeDefault();
            depth1.Value.Int.ShouldNotBeDefault();
            depth1.Value.RecursiveDictionary.Count.ShouldBeInRange(1, 3);

            var depth2 = depth1.Value.RecursiveDictionary.FirstOrDefault();
            depth2.Value.RecursiveDictionary.ShouldNotBeDefault();
            depth2.Value.Int.ShouldNotBeDefault();
            depth2.Value.RecursiveDictionary.Count.ShouldBeInRange(1, 3);

            var depth3 = depth2.Value.RecursiveDictionary.FirstOrDefault();
            depth3.Value.RecursiveDictionary.ShouldEqual(null);
            depth3.Value.Int.ShouldNotBeDefault();
        }
    }
}
