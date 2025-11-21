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
}


