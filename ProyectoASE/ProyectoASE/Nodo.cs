using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoASE
{
    public class Nodo<T>
    {
        public T info;
        public int altura;
        public Nodo<T> nodo;
        public Nodo<T> izq;
        public Nodo<T> der;
    }
}
