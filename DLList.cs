
namespace FileManagementApp
{
    internal class DLList<T>
    {
        public GenericNode<T>? Head { get; set; }
        public GenericNode<T>? Tail { get; set; }

        public DLList()
        {
            Head = null;
            Tail = null;
        }

        public void InsertFirst(T t)
        {
            GenericNode<T> tmp = new GenericNode<T>();
            tmp.Value = t;
            tmp.Next = Head;
            tmp.Prev = null;

            // Add one to node count.
            tmp.Count++;

            // If list is empty, Tail must point to first and only item.
            if (isEmpty())
            {
                Tail = tmp;
            }

            Head = tmp;
        }

        public void InsertLast(T t)
        {
            if (Head == null)
            {
                InsertFirst(t);
                return;
            }

            GenericNode<T> tmp = new();

            tmp.Value = t;
            tmp.Next = null;
            tmp.Prev = Tail!;

            tmp.Count++;

            Tail!.Next = tmp!;

            Tail = tmp!;
        }

        public void Traverse(int count)
        {
            if (Head == null)
            {
                Console.WriteLine("Empty List");
                return;
            }

            Console.WriteLine($"TotalChars: {count}");
            for (GenericNode<T> node = Head; node != null; node = node.Next)
            {
                Console.WriteLine($"Value: {node.Value}, Count: {node.Count}, Frequency: {(double)node.Count / count:P}");
            }
        }

        public GenericNode<T> GetNodePosition(T t)
        {
            GenericNode<T> tmp = Head;
            while (tmp != null)
            {
                if (tmp.Value.Equals(t))
                {
                    return tmp;
                }
                tmp = tmp.Next;
            }

            return null;
        }

        public void IncreaseCount(GenericNode<T> node)
        {
            node.Count++;
        }

        public void IncreaseCound(T t)
        {
            GetNodePosition(t).Count++;
        }

        public void SortByValAsc()
        {
            for (GenericNode<T> iNode = Head; iNode != null; iNode = iNode.Next)
            {
                T minVal = iNode.Value;
                GenericNode<T> minPos = iNode;

                for (GenericNode<T> jNode = iNode; jNode != null; jNode = jNode.Next)
                {
                    if (jNode.Value is char)
                    {
                        if (Convert.ToChar(jNode.Value) < Convert.ToChar(minVal))
                        {
                            minVal = jNode.Value; 
                            minPos = jNode;
                        }
                    }
                }
                Swap(iNode, minPos);
            }
        }

        public void Swap (GenericNode<T> iNode, GenericNode<T> jNode)
        {
            T tempVal = iNode.Value;
            int tempCound = iNode.Count;

            iNode.Value = jNode.Value;
            iNode.Count = jNode.Count;

            jNode.Value = tempVal;
            jNode.Count = tempCound;
        }

        public void SortByFrequencyDesc()
        {
            for (GenericNode<T> iNode = Head; iNode != null; iNode = iNode.Next)
            {
                int minVal = iNode.Count;
                GenericNode<T> minPos = iNode;

                for (GenericNode<T> jNode = iNode; jNode != null; jNode = jNode.Next)
                {
                    if (jNode.Count > minVal)
                    {
                        minVal = jNode.Count;
                        minPos = jNode;
                    }
                }
                Swap(iNode, minPos);
            }
        }




        public bool isEmpty()
        {
            return Head == null || Tail == null;
        }
    }
}
