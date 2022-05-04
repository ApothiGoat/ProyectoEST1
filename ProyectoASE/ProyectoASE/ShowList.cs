using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoASE
{
    public class ShowList<T>
    {
        NodeList<T> Head = new NodeList<T>();
        NodeList<T> Cola = new NodeList<T>();
        NodeList<T> Return = new NodeList<T>();

        NodeList<T> SixMonths = new NodeList<T>();

        public void Add(T Value)
        {
            NodeList<T> Nuevo = new NodeList<T>();
            Nuevo.value = Value;

            if (Head.value == null)
            {
                Head = Nuevo;
                Cola = Nuevo;
            }
            else
            {
                Cola.Next = Nuevo;
                Cola = Nuevo;
            }
        }
        public T Dequeue()
        {
            if (Head != null)
            {
                Return = Head;
                Head = Head.Next;
                if (Head == null)
                {
                    Cola = null;
                }
            }
            return Return.value;
        }
        public bool Empty()
        {
            return Head == null || Head.value == null;
        }
    }
}
