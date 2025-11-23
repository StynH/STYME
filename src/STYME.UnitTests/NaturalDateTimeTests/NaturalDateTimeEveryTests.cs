namespace STYME.UnitTests.NaturalDateTimeTests;

[TestClass]
public sealed class NaturalDateTimeEveryTests
{
    [TestMethod]
    public void Given_2025_01_01T00_00_00_When_Every_2_Weeks_Then_Yields_Expected_Sequence()
    {
        var baseDate = new DateTime(2025, 1, 1, 0, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var results = new List<DateTime>();
        foreach (var occurrence in sut.Enumerate("every 2 weeks"))
        {
            results.Add(occurrence);

            if (occurrence >= new DateTime(2025, 2, 12, 0, 0, 0))
            {
                break;
            }
        }

        var expected = new[]
        {
            new DateTime(2025, 1, 1, 0, 0, 0),
            new DateTime(2025, 1, 15, 0, 0, 0),
            new DateTime(2025, 1, 29, 0, 0, 0),
            new DateTime(2025, 2, 12, 0, 0, 0),
        };

        CollectionAssert.AreEqual(expected, results);
    }

    [TestMethod]
    public void Given_2025_01_01T10_00_00_When_Every_3_Days_Then_Yields_Expected_Sequence()
    {
        var baseDate = new DateTime(2025, 1, 1, 10, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var results = new List<DateTime>();
        foreach (var occurrence in sut.Enumerate("every 3 days"))
        {
            results.Add(occurrence);

            if (occurrence >= new DateTime(2025, 1, 7, 10, 0, 0))
            {
                break;
            }
        }

        var expected = new[]
        {
            new DateTime(2025, 1, 1, 10, 0, 0),
            new DateTime(2025, 1, 4, 10, 0, 0),
            new DateTime(2025, 1, 7, 10, 0, 0),
        };

        CollectionAssert.AreEqual(expected, results);
    }

    [TestMethod]
    public void Given_2025_01_01T12_00_00_When_Every_12_Hours_Then_Yields_Expected_Sequence()
    {
        var baseDate = new DateTime(2025, 1, 1, 12, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var results = new List<DateTime>();
        foreach (var occurrence in sut.Enumerate("every 12 hours"))
        {
            results.Add(occurrence);

            if (occurrence >= new DateTime(2025, 1, 2, 12, 0, 0))
            {
                break;
            }
        }

        var expected = new[]
        {
            new DateTime(2025, 1, 1, 12, 0, 0),
            new DateTime(2025, 1, 2, 0, 0, 0),
            new DateTime(2025, 1, 2, 12, 0, 0),
        };

        CollectionAssert.AreEqual(expected, results);
    }

    [TestMethod]
    public void Given_2024_01_31T09_00_00_When_Every_1_Month_Then_Adjusts_For_Month_Length()
    {
        var baseDate = new DateTime(2024, 1, 31, 9, 0, 0);
        var sut = NaturalDateTime.From(baseDate);

        var results = new List<DateTime>();
        foreach (var occurrence in sut.Enumerate("every 1 month"))
        {
            results.Add(occurrence);

            if (occurrence >= new DateTime(2024, 4, 29, 9, 0, 0))
            {
                break;
            }
        }

        var expected = new[]
        {
            new DateTime(2024, 1, 31, 9, 0, 0),
            new DateTime(2024, 2, 29, 9, 0, 0),
            new DateTime(2024, 3, 29, 9, 0, 0),
            new DateTime(2024, 4, 29, 9, 0, 0),
        };

        CollectionAssert.AreEqual(expected, results);
    }

    [TestMethod]
    public void Given_2020_02_29T15_45_00_When_Every_1_Year_Then_Preserves_Leap_Day_Context()
    {
        var baseDate = new DateTime(2020, 2, 29, 15, 45, 0);
        var sut = NaturalDateTime.From(baseDate);

        var results = new List<DateTime>();
        foreach (var occurrence in sut.Enumerate("every 1 year"))
        {
            results.Add(occurrence);

            if (occurrence >= new DateTime(2023, 2, 28, 15, 45, 0))
            {
                break;
            }
        }

        var expected = new[]
        {
            new DateTime(2020, 2, 29, 15, 45, 0),
            new DateTime(2021, 2, 28, 15, 45, 0),
            new DateTime(2022, 2, 28, 15, 45, 0),
            new DateTime(2023, 2, 28, 15, 45, 0),
        };

        CollectionAssert.AreEqual(expected, results);
    }
}


