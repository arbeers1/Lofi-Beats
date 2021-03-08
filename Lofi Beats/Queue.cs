using System;

namespace Lofi_Beats
{
    public class Queue<T>
    {
        public int Size { get; private set; }

        private MusicNode Head;

        private MusicNode Tail;

        public Queue(MusicNode node)
        {
            Head = node;
            Tail = node;
            Size = 1;
        }

        /// <summary>
        /// Adds a MusicNode to the end of the list
        /// </summary>
        /// <param name="node">Node to add</param>
        public void Add(MusicNode node)
        {
            if(Size == 0)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            Size++;
        }

        /// <summary>
        /// Removes and returns first most Node
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws when list is empty</exception>
        /// <returns>Head MusicNode</returns>
        public MusicNode Pop()
        {
            if(Size == 0)
            {
                throw new IndexOutOfRangeException();
            }
            MusicNode temp = Head;
            Head = Head.Next;
            if(Size == 1)
            {
                Tail = null;
            }
            Size--;
            return temp;
        }

        /// <summary>
        /// Returns if list is empty
        /// </summary>
        /// <returns>bool</returns>
        public bool isEmpty()
        {
            return (Size == 0);
        }

        /// <summary>
        /// Clears all nodes from list
        /// </summary>
        public void clear()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }
    }
}