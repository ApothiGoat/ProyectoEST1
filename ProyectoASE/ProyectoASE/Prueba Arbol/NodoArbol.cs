using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoASE.Prueba_Arbol
{
    public class NodoArbol<T>
    {
        public T Value { get; set; }

        public NodoArbol<T>? Izquierdo { get; set; }

        public NodoArbol<T>? Derecho { get; set; }

        public int Balance { get; set; }

        public NodoArbol(T Value)
        {
            this.Value = Value;
            Izquierdo = null;
            Derecho = null;
        }
    }
}
