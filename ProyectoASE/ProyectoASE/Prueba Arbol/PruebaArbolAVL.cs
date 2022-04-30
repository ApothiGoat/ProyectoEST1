using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoASE.Prueba_Arbol
{
    public class PruebaArbolAVL<T> : IEnumerable<T>
    {
        private NodoArbol<T> ? Raiz;

        public PruebaArbolAVL()
        {
            Raiz = null;
        }
        public virtual bool Vacio
        {
            get { return this.Raiz == null; }
        }
    }
}
