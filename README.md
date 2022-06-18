# modern-large-numbers
A library to handle creation and usage of large numbers up to 999.999 Quadragintillion, or 10^123 decimal places.

------

### Setup for Unity 2021.3+

Import the `ModernProgramming` namespace into your project file to start using Modern Large Numbers.

------

### Public Enums
`LargeNumber.Suffixes` - Names for all large numbers.

### Public Methods
`LargeNumber()` - Creates a new large number with default value of zero.

`LargeNumber(int newNumber)` - Creates a new large number clamped between 0 and 999.

`LargeNumber(int newNumber, int newSegments)` - Creates a new large number with up to forty-two 3 digit segments (10^123)
