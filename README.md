#Random Test Values
This project is to speed up and clean up unit testing by returning random values.  This is still a work in progress an very much in its infancy.

## Current functionality
- Random String:
  
  `var testValue = RandomTestValues.String();`
  
  `//  testvalue == '"31145662-00f2-4a07-b517-d1c6df6d2bb5"'`
  
- Random Int: `RandomTestValues.Int();`
- Random Decimal: `RandomTestValues.Decimal();`
- Random Double: `RandomTestValues.Double();`
- Random Object: `RandomTestValues.Object<T>();`
  
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
