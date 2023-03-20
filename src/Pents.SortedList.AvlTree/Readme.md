# AVL Tree Implementation

C# implementation of an AVL (Adelson-Velsky and Landis) tree, a self-balancing binary search tree. The AVL tree ensures that the height of the tree remains balanced, resulting in efficient search, insertion, and removal operations.

### Features

- Generic implementation: The AVL tree can store any data type that implements the IComparable<T> interface.
- Self-balancing: The tree remains balanced after each insertion and removal operation, maintaining a height of O(log n) where n is the number of nodes in the tree.
- Efficient operations: Search, insertion, and removal operations have a time complexity of O(log n).

### Usage

To use the AVL tree implementation in your project, create a new instance of the AVLTree<T> class, where T is the data type of the values you want to store:

```csharp
AVLTreeNode<int> avlTree = new AVLTreeNode<int>();

// Insert values into the AVL tree using the Add method:

avlTree.Add(10);
avlTree.Add(20);
avlTree.Add(30);

// Remove values from the AVL tree using the Remove method:

avlTree.Remove(20);
```
