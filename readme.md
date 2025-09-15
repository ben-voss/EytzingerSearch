# Eytzinger Binary Search

An implementation of the Eytzinger binary search algorithm.

References:

- "ARRAY LAYOUTS FOR COMPARISON-BASED SEARCHING" : https://arxiv.org/pdf/1509.05053
- "Eytzinger Binary Search" : https://algorithmica.org/en/eytzinger

# Example

```
    # Initialise an array
    var myArray = new int[15];

    for (var i = 0; i < myArray.Length; i++)
    {
        myArray[i] = i;
    }

    # Sort the elements into the Eytzinger sort order
    var eytzingerSorted = myArray.EytzingerSort();

    # Search for an element
    if (eytzingerSorted.TryEytzingerSearch(5, out var index)) {
        // Found
    } else {
        // Not Found
    }

    # Search for an element and validate the index
    var index = eytzingerSorted.EytzingerSearch(5);

    if (index < 0) {
        // Not Found
    } else {
        // Found
    }

```