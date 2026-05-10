# C# Data Structures Implementation: Linked List, Queue & Stack

## 📌 Project Overview
This project is a custom implementation of fundamental data structures within the .NET environment. The primary objective was to gain a deep understanding of memory management, reference manipulation, and the implementation of algorithms with specific computational complexities without relying on built-in system collections (like `System.Collections.Generic`).

## 🛠 Technical Stack
*   **Language:** C# 10.0+
*   **Framework:** .NET 6.0 / 8.0
*   **Paradigm:** Object-Oriented Programming (OOP)
*   **IDE:** Visual Studio / JetBrains Rider

## 🏗 System Architecture & Features

### 1. Singly Linked List (The Core Engine)
The foundation of the project is a dynamic singly linked list that manages `Node` objects.
*   **Manual Reference Management:** Implementation of manual pointer-like control using `Next` references between nodes.
*   **CRUD Operations:** 
    *   `AddFirst`, `AddNode` (AddLast): $O(1)$ complexity achieved by maintaining `Head` and `Tail` pointers.
    *   `AddAtN`, `RemoveAtN`: Insertion and deletion at any given index ($O(n)$ complexity).
    *   `Contains`: Linear search algorithm implementation.
    *   `Traverse`: Full list iteration for data visualization and debugging.

### 2. Queue (FIFO - First In, First Out)
A queue data structure implemented as a wrapper around the Linked List engine.
*   **Key Methods:** `Enqueue` (push to tail), `Dequeue` (pull from head).
*   **Use Case:** Modeling task/process workflows in queuing systems.

### 3. Stack (LIFO - Last In, First Out)
A stack implementation utilizing the linked list's ability to handle end-of-list operations.
*   **Key Methods:** `StackAdd` (Push), `StackRemove` (Pop).
*   **Use Case:** Managing application state and backtracking algorithms.

## 💻 Code Example

```csharp
// Initialize the structures
Node root = new Node(100);
Queue processingQueue = new Queue(root);

// Queue Operations
processingQueue.Enqueue(new Node(200));
Node? processedItem = processingQueue.Dequeue(); // Returns Node(100)

// Stack Operations
Stack undoStack = new Stack(new Node(1));
undoStack.StackAdd(new Node(2));
Node? lastAction = undoStack.StackRemove(); // Returns Node(2)
