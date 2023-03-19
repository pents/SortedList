namespace Pents.SortedList.UnitTests;

[TestFixture]
public class SortedListTests
{
    [Test]
    public void TestAdd()
    {
        var sortedList = new SortedList<int>();

        sortedList.Add(9);
        sortedList.Add(5);
        sortedList.Add(10);
        sortedList.Add(0);
        sortedList.Add(6);
        sortedList.Add(11);
        sortedList.Add(-1);
        sortedList.Add(1);
        sortedList.Add(2);

        int[] expected = { -1, 0, 1, 2, 5, 6, 9, 10, 11 };
        int[] actual = sortedList.ToArray();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestRemove()
    {
        var sortedList = new SortedList<int>();

        sortedList.Add(9);
        sortedList.Add(5);
        sortedList.Add(10);
        sortedList.Add(0);
        sortedList.Add(6);
        sortedList.Add(11);
        sortedList.Add(-1);
        sortedList.Add(1);
        sortedList.Add(2);

        sortedList.Remove(10);

        int[] expected = { -1, 0, 1, 2, 5, 6, 9, 11 };
        var actual = sortedList.ToArray();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestToArrayAndToList()
    {
        var sortedList = new SortedList<int>();

        sortedList.Add(9);
        sortedList.Add(5);
        sortedList.Add(10);
        sortedList.Add(0);
        sortedList.Add(6);
        sortedList.Add(11);
        sortedList.Add(-1);
        sortedList.Add(1);
        sortedList.Add(2);

        int[] expectedArray = { -1, 0, 1, 2, 5, 6, 9, 10, 11 };
        var expectedList = expectedArray.ToList();

        var actualArray = sortedList.ToArray();
        var actualList = sortedList.ToList();

        Assert.That(actualArray, Is.EqualTo(expectedArray));
        Assert.That(actualList, Is.EqualTo(expectedList));
    }
}