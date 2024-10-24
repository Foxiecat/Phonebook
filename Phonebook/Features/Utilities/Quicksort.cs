namespace Phonebook.Features.Utilities;

public static class Quicksort
{
    public static void QuickTextSort(Contact[] contacts, int low, int high, string propertyName, string order)
    {
        if (high <= low) return;

        int j = Partition(contacts, low, high, propertyName, order);

        QuickTextSort(contacts, low, j - 1, propertyName, order);
        QuickTextSort(contacts, j + 1, high, propertyName, order);
    }

    private static int Partition(Contact[] contactArray, int low, int high, string propertyName, string order)
    {
        //string pivot = contactArray[low].GetType().GetField(propertyName).ToString();
        
        string? pivot = contactArray[low].GetProperty(propertyName);
        
        int i = low;
        int j = high + 1;

        while (true)
        {
            switch (order)
            {
                case "Ascending":
                {
                    while (string.CompareOrdinal(contactArray[++i].GetProperty(propertyName), pivot) < 0)
                    { }

                    while (string.CompareOrdinal(pivot, contactArray[--j].GetProperty(propertyName)) < 0)
                    { }

                    break;
                }
                case "Descending":
                {
                    while (string.CompareOrdinal(contactArray[++i].GetProperty(propertyName), pivot) > 0)
                    { }

                    while (string.CompareOrdinal(pivot, contactArray[--j].GetProperty(propertyName)) > 0)
                    { }

                    break;
                }
            }
            
            if (i >= j) break;

            Swap(contactArray, i, j);
        }
        
        Swap(contactArray, low, j);
        return j;
    }

    private static void Swap(Contact[] array, int first, int second)
    {
        (array[first], array[second]) = (array[second], array[first]);
    }
}