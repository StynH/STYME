# ![Icon](logo.png) 
![NuGet Version](https://img.shields.io/nuget/v/STYME) ![NuGet Downloads](https://img.shields.io/nuget/dt/STYME)

STYME is a lightweight, zero-dependency C# library for parsing simple natural-language date/time expressions and applying them to a base date/time.

## Usage Examples

### Basic

```csharp
using STYME;

// By default NaturalDateTime uses the current system time as the base
var parser = new NaturalDateTime();
var result = parser.Parse("add 2 days");
Console.WriteLine(result);
```

Output (example):

```
2025-10-04T14:23:00
```

You can parse expressions relative to a specific `DateTime` using `NaturalDateTime.From`.

```csharp
using STYME;

var baseTime = new DateTime(2020, 1, 1, 0, 0, 0);
var parser = NaturalDateTime.From(baseTime);
var result = parser.Parse("add 1 month");
Console.WriteLine(result);
```

Output:

```
2020-02-01T00:00:00
```

### Add

You can add time using the `add` keyword.

```csharp
using STYME;

var baseTime = new DateTime(2020, 3, 1, 12, 0, 0);
var parser = NaturalDateTime.From(baseTime);
var result = parser.Parse("add 1 year");
Console.WriteLine(result);
```

Output:

```
2021-03-01T00:00:00
```


### Deduct / Subtract

You can subtract time using the `deduct` (or `subtract`) keyword.

```csharp
using STYME;

var baseTime = new DateTime(2020, 3, 1, 12, 0, 0);
var parser = NaturalDateTime.From(baseTime);
var result = parser.Parse("deduct 1 month");
Console.WriteLine(result);
```

Output:

```
2020-02-01T12:00:00
```

### Supported units with `add` and `deduct`

The `add` and `deduct` expressions support the following units (singular and plural forms):

- `second`, `seconds`
- `minute`, `minutes`
- `hour`, `hours`
- `day`, `days`
- `week`, `weeks`
- `month`, `months`
- `year`, `years`
- `decade`, `decades`
- `century`, `centuries`
- `millennium`, `millennia`

Example:

```csharp
using STYME;

var parser = NaturalDateTime.From(new DateTime(2000, 1, 1));
Console.WriteLine(parser.Parse("add 2 decades")); // 2020-01-01
Console.WriteLine(parser.Parse("deduct 1 century")); // 1900-01-01
```

### Todo

[ ] Add month support (set DateTime to specific month)
[ ] Add day support (i.e. "next friday")
[ ] Add complex time support (i.e. "quarter past five")
[ ] Add multiple complex operations (i.e. "add one year then next friday")

## Support

* .NET 8.0 and later

## License

STYME is licensed under the [MIT License](LICENSE).
