# Sorted List using AVL Tree

This repository contains an implementation of a sorted list in C# using an AVL tree data structure. The SortedList<T> class provides efficient Add and Remove operations with O(log n) time complexity, where n is the number of elements in the list.

### Features

 - Generic type support, allowing you to store any type that implements the IComparable<T> interface.
 - Efficient Add and Remove operations with O(log n) time complexity.
 - Simple and clean API for managing a sorted list.

### Usage

To use the SortedList<T> class, simply create an instance and call the Add and Remove methods to insert and delete elements.


``` csharp
Copy code
SortedList<int> sortedList = new SortedList<int>();

sortedList.Add(9);
sortedList.Add(5);
sortedList.Add(10);
sortedList.Add(0);
sortedList.Add(6);
sortedList.Add(11);
sortedList.Add(-1);
sortedList.Add(1);
sortedList.Add(2);

// The sorted list now contains: -1, 0, 1, 2, 5, 6, 9, 10, 11

sortedList.Remove(10);

// The sorted list now contains: -1, 0, 1, 2, 5, 6, 9, 11
```

Interface ISortedList implements IEnumerable<T> - so you can use LINQ methods 
``` csharp
int[] sortedArray = sortedList.ToArray();
``` 

### Installation

To use the SortedList<T> class in your project, copy the SortedList.cs file into your project directory and add it to your project.

### Contributing

If you'd like to contribute to this project, feel free to submit a pull request. We welcome any improvements or bug fixes you'd like to share.

### License

This project is licensed under the MIT License. See the LICENSE file for more information.