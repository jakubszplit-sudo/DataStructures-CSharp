namespace LinkedListANG
{
    class Program
    {
        class Node
        {
            private int Code { get; }
            private Node? Next { get; set; }

            public Node(int code)
            {
                this.Code = code;
                this.Next = null;
            }

            public override string ToString()
            {
                return Code.ToString();
            }

            public int GetCode()
            {
                return Code;
            }

            public void SetNext(Node? next)
            {
                this.Next = next;
            }

            public Node? GetNext()
            {
                return Next;
            }
        }

        class LinkedList
        {
            private Node? Head { get; set; }
            private Node? Tail { get; set; }
            private int Length { get; set; }

            public LinkedList(Node node)
            {
                this.Head = node;
                this.Tail = node;
                this.Length = 1;
            }

            public int GetLength()
            {
                return Length;
            }

            public void AddNode(Node next)
            {
                if (Tail != null)
                {
                    Tail.SetNext(next);
                }

                Tail = next;
                Length++;
            }

            public void Traverse()
            {
                Node? current = this.Head;

                while (current != null)
                {
                    Console.WriteLine(current);
                    current = current.GetNext();
                }
            }

            public bool Contains(int value)
            {
                Node? current = this.Head;

                while (current != null)
                {
                    if (current.GetCode() == value)
                        return true;

                    current = current.GetNext();
                }

                return false;
            }

            public Node? GetNodeN(int n)
            {
                Node? current = this.Head;
                int index = 0;

                while (current != null)
                {
                    if (index == n)
                        return current;

                    current = current.GetNext();
                    index++;
                }

                return null;
            }

            public void AddFirst(Node node)
            {
                if (Length == 0)
                {
                    Head = node;
                    Tail = node;
                    Length++;
                    return;
                }

                node.SetNext(Head);
                Head = node;
                Length++;
            }

            public bool AddAtN(Node node, int n)
            {
                if (n == 0)
                {
                    AddFirst(node);
                    return true;
                }

                if (n > Length)
                    return false;

                Node? before = GetNodeN(n - 1);
                if (before == null) return false;

                Node? next = before.GetNext();

                before.SetNext(node);
                node.SetNext(next);

                if (next == null)
                    Tail = node;

                Length++;
                return true;
            }

            public Node? RemoveFirst()
            {
                if (Head == null) return null;

                Node? temp = Head;
                Head = Head.GetNext();
                Length--;

                if (Length == 0)
                    Tail = null;

                return temp;
            }

            public Node? RemoveLast()
            {
                if (Length == 0) return null;

                if (Length == 1)
                {
                    Node? temp = Head;
                    Head = null;
                    Tail = null;
                    Length = 0;
                    return temp;
                }

                Node? beforeLast = GetNodeN(Length - 2);
                if (beforeLast == null) return null;

                Node? last = beforeLast.GetNext();

                beforeLast.SetNext(null);
                Tail = beforeLast;
                Length--;

                return last;
            }

            public bool RemoveAtN(int n)
            {
                if (n == 0)
                {
                    RemoveFirst();
                    return true;
                }

                if (n == Length - 1)
                {
                    RemoveLast();
                    return true;
                }

                if (n > Length || n < 0) return false;
                Node? before = GetNodeN(n - 1);
                Node? next = GetNodeN(n + 1);
                before!.SetNext(next);
                Length--;
                return true;
            }
        }

        class Queue
        {
            private LinkedList _myList;

            public Queue(Node newNode)
            {
                this._myList = new LinkedList(newNode);
            }

            public void Enqueue(Node node)
            {
                _myList.AddNode(node);
            }

            public Node? Dequeue()
            {
                return _myList.RemoveFirst();
            }

            public void Traverse()
            {
                _myList.Traverse();
            }
        }

        class Stack
        {
            private LinkedList _myList;

            public Stack(Node newNode)
            {
                this._myList = new LinkedList(newNode);
            }

            public void StackPush(Node node)
            {
                _myList.AddNode(node);
            }

            public Node? StackPop()
            {
                return _myList.RemoveLast();
            }

            public void Traverse()
            {
                _myList.Traverse();
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("CREATING LIST");
            Node n1 = new Node(10);
            LinkedList list = new LinkedList(n1);

            Console.WriteLine("Adding more elements (AddNode): 20, 30");
            list.AddNode(new Node(20));
            list.AddNode(new Node(30));

            Console.WriteLine("\nTraverse() - iterating through the list:");
            list.Traverse();

            Console.WriteLine("\nGetLength() - list length:");
            Console.WriteLine(list.GetLength());

            Console.WriteLine("\nContains(20) - does list contain 20?");
            Console.WriteLine(list.Contains(20));

            Console.WriteLine("\nContains(99) - does list contain 99?");
            Console.WriteLine(list.Contains(99));

            Console.WriteLine("\nGetNodeN(1) - element at index 1:");
            Node? nodeAt1 = list.GetNodeN(1);
            Console.WriteLine(nodeAt1);

            Console.WriteLine("\nAddFirst()");
            Console.WriteLine("Adding 5 to the beginning:");
            list.AddFirst(new Node(5));
            list.Traverse();

            Console.WriteLine("\nAddAtN()");
            Console.WriteLine("Adding 99 at index 1:");
            Console.WriteLine($"Operation successful: {list.AddAtN(new Node(99), 1)}");
            list.Traverse();

            Console.WriteLine("\nRemoveFirst()");
            Console.WriteLine("Removing first element:");
            Node? removedFirst = list.RemoveFirst();
            Console.WriteLine("Removed: " + removedFirst);
            list.Traverse();

            Console.WriteLine("\nRemoveLast()");
            Console.WriteLine("Removing last element:");
            Node? removedLast = list.RemoveLast();
            Console.WriteLine("Removed: " + removedLast);
            list.Traverse();

            Console.WriteLine("\nRemoveAtN()");
            Console.WriteLine("Removing element at index 1:");
            Console.WriteLine($"Operation successful: {list.RemoveAtN(1)}");
            list.Traverse();

            Console.WriteLine("\nQUEUE");
            Console.WriteLine("Creating queue and adding elements: 1, 2, 3");

            Queue queue = new Queue(new Node(1));
            queue.Enqueue(new Node(2));
            queue.Enqueue(new Node(3));

            Console.WriteLine("\nTraverse() - queue content:");
            queue.Traverse();

            Console.WriteLine("\nDequeue() - removing first element (FIFO):");
            Node? dq = queue.Dequeue();
            Console.WriteLine("Removed: " + dq);

            Console.WriteLine("\nQueue state after Dequeue:");
            queue.Traverse();

            Console.WriteLine("\nSTACK");
            Console.WriteLine("Creating stack and adding elements: 1, 2, 3");

            Stack stack = new Stack(new Node(1));
            stack.StackPush(new Node(2));
            stack.StackPush(new Node(3));

            Console.WriteLine("\nTraverse() - stack content:");
            stack.Traverse();

            Console.WriteLine("\nStackPop() - removing last element (LIFO):");
            Node? sr = stack.StackPop();
            Console.WriteLine("Removed: " + sr);

            Console.WriteLine("\nStack state after StackPop():");
            stack.Traverse();

            Console.WriteLine("\nEND OF TESTS");
        }
    }
}