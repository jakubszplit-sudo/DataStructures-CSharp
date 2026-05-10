namespace LinkedList
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

            public LinkedList(Node numb)
            {
                this.Head = numb;
                this.Tail = numb;
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

            public bool Contains(int numb)
            {
                Node? current = this.Head;

                while (current != null)
                {
                    if (current.GetCode() == numb)
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

            public bool RemoveAtN( int n)
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

            public void StackAdd(Node node)
            {
                _myList.AddNode(node); 
            }

            public Node? StackRemove()
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
            Console.WriteLine("TWORZENIE LISTY");
            Node n1 = new Node(10);
            LinkedList list = new LinkedList(n1);

            Console.WriteLine("Dodajemy kolejne elementy (AddNode): 20, 30");
            list.AddNode(new Node(20));
            list.AddNode(new Node(30));

            Console.WriteLine("\nTraverse() - przejście po liście:");
            list.Traverse();

            Console.WriteLine("\nGetLength() - długość listy:");
            Console.WriteLine(list.GetLength());

            Console.WriteLine("\nContains(20) - czy lista zawiera 20?");
            Console.WriteLine(list.Contains(20));

            Console.WriteLine("\nContains(99) - czy lista zawiera 99?");
            Console.WriteLine(list.Contains(99));

            Console.WriteLine("\nGetNodeN(1) - element o indeksie 1:");
            Node? nodeAt1 = list.GetNodeN(1);
            Console.WriteLine(nodeAt1);

            Console.WriteLine("\nAddFirst()");
            Console.WriteLine("Dodajemy 5 na początek:");
            list.AddFirst(new Node(5));
            list.Traverse();
            
            Console.WriteLine("\nAddAtN()");
            Console.WriteLine("Dodajemy 99 na indeks 1:");
            Console.WriteLine($"Operacja udana: {list.AddAtN(new Node(99), 1)}");
            list.Traverse();

            Console.WriteLine("\nRemoveFirst()");
            Console.WriteLine("Usuwamy pierwszy element:");
            Node? removedFirst = list.RemoveFirst();
            Console.WriteLine("Usunięto: " + removedFirst);
            list.Traverse();
            
            Console.WriteLine("\nRemoveLast()");
            Console.WriteLine("Usuwamy ostatni element:");
            Node? removedLast = list.RemoveLast();
            Console.WriteLine("Usunięto: " + removedLast);
            list.Traverse();

            Console.WriteLine("\nRemoveAtN()");
            Console.WriteLine("Usuwamy element o indeksie 1:");
            Console.WriteLine($"Operacja udana: {list.RemoveAtN(1)}");
            list.Traverse();

            Console.WriteLine("\nKOLEJKA (Queue)");
            Console.WriteLine("Tworzymy kolejkę i dodajemy elementy: 1, 2, 3");

            Queue queue = new Queue(new Node(1));
            queue.Enqueue(new Node(2));
            queue.Enqueue(new Node(3));

            Console.WriteLine("\nTraverse() - zawartość kolejki:");
            queue.Traverse();

            Console.WriteLine("\nDequeue() - usuwamy pierwszy element (FIFO):");
            Node? dq = queue.Dequeue();
            Console.WriteLine("Usunięto: " + dq);

            Console.WriteLine("\nStan kolejki po Dequeue:");
            queue.Traverse();
            
            Console.WriteLine("\nSTOS (stack)");
            Console.WriteLine("Tworzymy stos i dodajemy elementy: 1, 2, 3");
            
            Stack stack = new Stack(new Node(1));
            stack.StackAdd(new Node(2));
            stack.StackAdd(new Node(3));
            
            Console.WriteLine("\nTraverse() - zawartość stosu:");
            stack.Traverse();
            
            Console.WriteLine("\nStackRemove() - usuwamy ostatni element (LIFO):");
            Node? sr = stack.StackRemove();
            Console.WriteLine("Usunięto: " + sr);

            Console.WriteLine("\nStan stosu po StackRemove():");
            stack.Traverse();

            Console.WriteLine("\nKONIEC TESTÓW");
        }
    }
}