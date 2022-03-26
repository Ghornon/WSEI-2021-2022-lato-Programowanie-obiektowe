# class Fraction : IComparable, IEquatable

## Create Fraction

```C#
Fraction a = new Fraction(1, 4); //Create Fraction with arguments
Fraction b = new Fraction(a); //Copy object to create Fraction
Fraction c = new Fraction(); //Create Fraction without arguments
```

## Public properties

```C#
public int Numerator { get => numerator; }
public int Denominator { get => denominator; }
```

## Public methods

### ToString()

```C#
Fraction a = new Fraction(1, 4);
Console.WriteLine($"Fraction: {a}");
```

### CompareTo(Fraction)

Implementation of IComparable

```C#
var a = new Fraction(1, 2);
var b = new Fraction(1, 4);
a.CompareTo(a) // Return 0
a.CompareTo(b) // Return -1
b.CompareTo(a) // Return 1
```

### Equals(obj?)

Implementation of IEquatable

```C#
var a = new Fraction(1, 2);
var b = new Fraction(1, 4);
a.Equals(a) // Return true
a.Equals(b) // Return false
```

### GetHashCode

return Numerator + Denominator

### RoundDown()

```C#
var a = new Fraction(1, 2);
a.RoundDown() // Return 0
```

### RoundUp()

```C#
var a = new Fraction(1, 2);
a.RoundUp() // Return 1
```
