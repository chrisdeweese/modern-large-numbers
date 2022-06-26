# modern-large-numbers
A library to handle creation and usage of large numbers up to 999.999 Quadragintillion, or 10^123 decimal places.

------

### Setup for Unity 2021.3+

Import the `ModernProgramming` namespace into your project file to start using Modern Large Numbers.

------

### Public Enums
`LargeNumber.Suffixes` - Names for all large numbers.

------

### Public Methods

#### Creating a new Large Number

`LargeNumber()` - Creates a new large number with default value of zero.

`LargeNumber(int newNumber)` - Creates a new large number clamped between 0 and 999.

`LargeNumber(int newNumber, int newSegments)` - Creates a new large number with up to forty-two 3 digit segments (10^123)

------

#### Basic Math Operations

`LargeNumber.AddOne()` - Add one to the large number.

`LargeNumber.SubtractOne()` - Subtract one from the large number.

`LargeNumber.AddLargeNumber(LargeNumber numberToAdd)` - Adds a large number to this large number.

`LargeNumber.SubtractLargeNumber(LargeNumber numberToSubtract)` - Subtracts a large number from this large number.

------

#### Equality Checks

`LargeNumber.IsGreaterThan(LargeNumber numberToCompare)` - (bool) Checks if a large number is greater than this large number.

`LargeNumber.IsLessThan(LargeNumber numberToCompare)` - (bool) Checks if a large number is less than this large number.

`LargeNumber.IsEqual(LargeNumber numberToCompare)` - (bool) Checks if a large number is equal to this large number.

------

#### Utility Methods

`LargeNumber.Assign(LargeNumber numberToAssign)` - Assign a large number to this variable.

`LargeNumber.RemoveLeadingZeros()` - Removes leading zeroes from this large number.

`LargeNumber.LargeNumberToShortString()` - (string) Converts this large number into a string with a suffix.

`LargeNumber.LargeNumberToString()` - (string) Converts this large number into a string.

`LargeNumber.StringToLargeNumber(string stringToConvert)` - (LargeNumber) Converts this string into a large number.

`LargeNumber.ClampList()` - Clamps the number list.

------

### TO-DO

- Test backwards compatability.