using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmberMug.Lib
{
    public partial class SinglyLinkedList<T>: IEnumerable<LinkedNode<T>>
    {

        public class Enumerator : IEnumerator<LinkedNode<T>>
        {
            public LinkedNode<T> Current { get; private set; }

            public Enumerator(LinkedNode<T> node)
            {
                this.Current = node;
            }

            object IEnumerator.Current
            {
                get => Current;
            }

            public void Dispose()
            {
                return;
                // throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                if (Current.Next is { })
                {
                    Current = Current.Next;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        public LinkedNode<T> Head { get; set; }
        public LinkedNode<T> Tail { get; set; }

        public SinglyLinkedList()
        {
            Head = null;
            Tail = null;
        }

        public LinkedNode<T> Add(T newData)
        {
            var node = new LinkedNode<T>(newData);

            // if no elements exist in this linked list
            if (Head is null)
            {
                Head = node;
                Tail = node;
                return node;
            }

            if (Tail is { })
            {
                Tail.Next = node;
            }

            Tail = node;

            return node;

        }

        public LinkedNode<T> DeleteNode(LinkedNode<T> deleteNode)
        {
            // Deleting the head
            if (deleteNode.Next is { })
            {
                Head = deleteNode.Next;
                deleteNode.Next = null;
            } else
            // Deleting the last node
            {
                Head = null;
                Tail = null;
            }
            return deleteNode;
        }

        public LinkedNode<T> DeleteNode(LinkedNode<T> deleteNode, LinkedNode<T> prevNode)
        {
            // Deleting the node in the middle
            if (deleteNode.Next is { })
            {
                prevNode.Next = deleteNode.Next;
                deleteNode.Next = null;
            } else
            // Deleting the tail
            {
                prevNode.Next = null;
                Tail = prevNode;
            }
            return deleteNode;
        }

        public LinkedNode<T> RemoveAt(string id)
        {
            LinkedNode<T> currentNode = Head;

            // Head node is the one to delete (only 1 node in the list and it matches)

            if (currentNode is { } && currentNode.ID.Equals(id))
            {
                return DeleteNode(currentNode);
            }

            // >= 2 Nodes in the list
            while (currentNode.Next is { })
            {
                if (currentNode.Next.ID.Equals(id))
                {
                    return DeleteNode(currentNode.Next, currentNode);
                }
                currentNode = currentNode.Next;
            }

            // 0 node in the list or no matches
            return null;

        }

        public LinkedNode<T> Remove(LinkedNode<T> node)
        {
            LinkedNode<T> currentNode = Head;

            // Head node is the one to delete (only 1 node in the list and it matches)

            if (currentNode.Equals(node))
            {
                return DeleteNode(currentNode);
            }

            // >= 2 Nodes in the list
            while (currentNode.Next is { })
            {
                if (currentNode.Next.Equals(node))
                {
                    return DeleteNode(currentNode.Next, currentNode);
                }
                currentNode = currentNode.Next;
            }

            // 0 node in the list or no matches
            return null;
        }



        public IEnumerator<LinkedNode<T>> GetEnumerator()
        {
            // Enumerators are positioned before the first element
            // until the first MoveNext() call. That's why we need a
            // virtual init node
            return new Enumerator(new LinkedNode<T>() { Next=Head });
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
