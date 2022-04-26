#Random Test Values
This project is to speed up and clean up unit testing by returning random values.

`Install-Package RandomTestValues`

Hopefully you can go from tests that look like this:
```csharp
[TestMethod]
public void Test()
{
  // Arrange
  var testPerson = new Person
    {
      FName = "Test",
      LName = "LastTest",
      Age = 50,
      Address = new Address
        {
          Street = "Test street",
          City = "Test City",
          State = "Test State",
          Zip = 55555
        }
    };
  var sut = new ShippingLabelCreator()
  
  // Act
  var result = sut.GenerateLableText(testPerson);
  
  // Assert
  Assert.AreEqual("Test LastTest - Test street Test City, Test State", result);
}
```

To tests that look like:
```csharp
[TestMethod]
public void Test()
{
  // Arrange
  var testPerson = RandomValue.Object<Person>();
  var sut = new ShippingLabelCreator()
  
  // Act
  var result = sut.GenerateLableText(testPerson);
  
  // Assert
  Assert.AreEqual($"{testPerson.FName} {testPerson.LName} - {testPerson.Address.Street} {testPerson.Address.City}, {testPerson.Address.State}", result);
}
```

The point here is that we don't care about the actual data of `testPerson` we just care that it is returned in the correct format.  *DO NOT* use RandomTestValues if you care about what the data actually is as it will by definition be random!

## Current functionality
- All primative types supported, `DateTime`, `Guid`
- `ICollection<T>`, `Collection<T>`, `IList<T>`, `List<T>`, `IEnumerable<T>`, `IEnumerable<ICollection<T>>`, `T[]`.
- Nullable types
- Random Enum Value:  This is random in the fact that it will pick one of the possible values at random.
- Random Object: `RandomTestValues.Object<T>();` where `T` follows above support
  
  *Note: Random Object may fail due to unsupported features.  Please submit a ticket if you come across this and I will get to it as soon as possible.

## Example Usage
- Primative Types
```csharp
  var testString = RandomTestValues.String();
  var testInt = RandomTestValues.Int();
```

- Generic Collection
```csharp
  var randomStringCollection = RandomTestValues.Collection<string>();
  var randomIntList = RandomTestValues.List<int>();
  var randomClassArray = RandomTestValues.Array<MyClass>();
```

- Enum
```csharp
  var randomEnum = RandomTestValues.Enum<MyEnum>();
```

- Object
```csharp
  var randomMyClass = RandomTestValues.Object<MyClass>();
```

- Object Instance
```csharp
  var myClass = new MyClass();
  // Note: any property that has a setter will be set even if it previously contained a value.
  var randomMyClass = RandomTestValues.Object(myClass);
```

### Dependencies
- RandomTestValues
  - System
  - System.Core
