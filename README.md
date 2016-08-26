#Random Test Values
This project is to speed up and clean up unit testing by returning random values.  This is still a work in progress an very much in its infancy.

## Current functionality
- All (I think) primative types:

  Random String Example
  `var testValue = RandomTestValues.String();`
  
- `ICollection<T>`, `Collection<T>`, `IList<T>`, `List<T>` where `T` is a supported primative type (`ICollection<MyClass>` NOT SUPPORTED)
- Random Object: `RandomTestValues.Object<T>();` where `T` follows above support
  
  *Note: Random Object only works with classes that contain only currently supported primative types or other user defined types.  See "RandomTestValues.Tests/TestObject.cs" for an example.  If this is still unclear I suggest just downloading and debuging through some of the unit tests and inspect what is happening to the object.
  
## Features I Want to Add
- Collection Support
- More primative types

### Dependencies
- RandomTestValues
  - System
  - System.Core
- RandomTestValues.Tests **(Not necessary to pull down)**
  - Microsoft.VisualStudio.TestPlatform.TestFramework
  - Microsoft.VisualStudio.TestPlatform.TestFramework.Extensions
  - RandomTestValues
  - Should
  - System
  - System.Core
