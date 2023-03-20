namespace Pents.SortedList.UnitTests;

[TestFixture]
public class SortedListTests
{
    [Test]
    public void ItShould_AddValuesToList()
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
    public void ItShould_RemoveValueFromList()
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
    public void ItShould_ProperlyExecuteToArrayAndToList()
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
        
        Assert.Multiple(() =>
        {
            Assert.That(actualArray, Is.EqualTo(expectedArray));
            Assert.That(actualList, Is.EqualTo(expectedList));
        });
    }
    
    [Test]
    public void ItShould_AddNonUniqueValues()
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
        sortedList.Add(9); // Duplicate value

        int[] expected = { -1, 0, 1, 2, 5, 6, 9, 9, 10, 11 };
        int[] actual = sortedList.ToArray();

        Assert.That(actual, Is.EqualTo(expected));
    }
}