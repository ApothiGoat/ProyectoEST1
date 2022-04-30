using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoASE.Prueba_Arbol
{
    public class NodoArbol<T>
    {
        public T Value { get; set; }

        public NodoArbol<T>? Primero { get; set; }

        public NodoArbol<T>? Segundo { get; set; }

        public int Balance { get; set; }

        public NodoArbol(T Value)
        {
            this.Value = Value;
            Primero = null;
            Segundo = null;
        }
    }
}
