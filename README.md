#Random Test Values
This project is to speed up and clean up unit testing by returning random values.  This is still a work in progress an very much in its infancy.

## Current functionality
- All primative types supporte (I think)
- `ICollection<T>`, `Collection<T>`, `IList<T>`, `List<T>` where `T` is a supported primative type (`ICollection<MyClass>` NOT SUPPORTED)
- Random Enum Value:  This is random in the fact that it will pick one of the possible values at random.  (NOT SUPPORTED WITH COLLECTIONS BUT IS SUPPORTED WITH `Object<T>()`)
- Random Object: `RandomTestValues.Object<T>();` where `T` follows above support
  
  *Note: Random Object only works with classes that contain only currently supported primative types or other user defined types.  See "RandomTestValues.Tests/TestObject.cs" for an example.  If this is still unclear I suggest just downloading and debuging through some of the unit tests and inspect what is happening to the object.

## Example Usage
- Primative Types
```
  var testString = RandomTestValues.String();
  var testInt = RandomTestValues.Int();
```

- Supported Generic Collection
```
  var randomStringCollection = RandomTestValues.Collection<string>();
  var randomIntList = RandomTestValues.List<int>();
```

- Enum
```
  var randomEnum = RandomTestValues.Enum<MyEnum>();
```

- Object
```
  var randomMyClass = RandomTestValues.Object<MyClass>();
```

## Features I Want to Add
- More Collection Support with `Object<T>()`
  - Dictionary, IDictionary
  - Readonly (if possible)
  - User Defined Types

### Dependencies
- RandomTestValues
  - System
  - System.Core
