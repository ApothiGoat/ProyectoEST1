using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoASE.Prueba_Arbol
{
    public class PruebaArbolAVL<T> : IEnumerable<T>
    {
        private NodoArbol<T>  Raiz;

        public PruebaArbolAVL()
        {
            Raiz = null;
        }
        public bool Vacio
        {
            get { return this.Raiz == null; }
        }

        public void Ingresar(T dato, Delegate Comparador)
        {
            bool flag = false;
            this.Raiz = Agregar(this.Raiz!, dato, ref flag, Comparador);
        }

        public NodoArbol<T> Agregar(NodoArbol<T> Raiz, T dato, ref bool Flag, Delegate Comparador)
        {
            NodoArbol<T> nodo;
            if (Raiz == null)
            {
                Raiz = new NodoArbol<T>(dato);
                Flag = true;
            }
            else
            {
                
                if ((int)Comparador.DynamicInvoke(dato, Raiz.Value) < 0)
                {
                    Raiz.Primero = Agregar(Raiz.Primero!, dato, ref Flag, Comparador);
                    if (Flag)
                    {
                        if (Raiz.Balance == -1)
                        {
                            Raiz.Balance = 0;
                            Flag = false;
                        }
                        else if (Raiz.Balance == 0)
                        {
                            Raiz.Balance = 1;
                        }
                        else if (Raiz.Balance == 1)
                        {
                            nodo = Raiz.Primero;
                            if (nodo.Balance == 1)
                            {
                                Raiz = Rotacion_simple_derecha(Raiz, nodo);
                            }
                            else
                            {
                                Raiz = Rotacion_doble_derecha(Raiz, nodo);
                            }
                            Flag = false;
                        }
                    }
                }
                else
                {
                    if ((int)Comparador.DynamicInvoke(dato, Raiz.Value) > 0)
                    {
                        Raiz.Segundo = Agregar(Raiz.Segundo!, dato, ref Flag, Comparador);
                        if (Flag)
                        {
                            if (Raiz.Balance == -1)
                            {
                                nodo = Raiz.Segundo;
                                if (nodo.Balance == -1)
                                {
                                    Raiz = Rotacion_simple_izquierda(Raiz, nodo);
                                }
                                else
                                {
                                    Raiz = Rotacion_doble_izquierda(Raiz, nodo);
                                }
                                Flag = false;
                            }
                            else if (Raiz.Balance == 0)
                            {
                                Raiz.Balance = -1;
                            }
                            else if (Raiz.Balance == 1)
                            {
                                Raiz.Balance = 0;
                                Flag = false;
                            }
                        }
                    }
                }
            }
            return Raiz;
        }

        public NodoArbol<T> Rotacion_simple_derecha(NodoArbol<T> nodo, NodoArbol<T> nodo2)
        {
            nodo.Primero = nodo2.Segundo;
            nodo2.Segundo = nodo;
            if (nodo2.Balance == 1)
            {
                nodo.Balance = 0;
                nodo2.Balance = 0;
            }
            else
            {
                nodo.Balance = 1;
                nodo2.Balance = -1;
            }
            return nodo2;
        }

        public NodoArbol<T> Rotacion_doble_derecha(NodoArbol<T> nodo, NodoArbol<T> nodo2)
        {
            NodoArbol<T> NODO = nodo2.Segundo;
            nodo.Primero = NODO!.Segundo;
            NODO.Segundo = nodo;
            nodo2.Segundo = NODO.Primero;
            NODO.Primero = nodo2;
            nodo2.Balance = (NODO.Balance == -1) ? 1 : 0;
            nodo.Balance = (NODO.Balance == 1) ? -1 : 0;
            NODO.Balance = 0;
            return NODO;
        }

        public NodoArbol<T> Rotacion_simple_izquierda(NodoArbol<T> nodo, NodoArbol<T> nodo2)
        {
            nodo.Segundo = nodo2.Primero;
            nodo2.Primero = nodo;
            if (nodo2.Balance == -1)
            {
                nodo.Balance = 0;
                nodo2.Balance = 0;
            }
            else
            {
                nodo.Balance = -1;
                nodo2.Balance = -1;
            }
            return nodo2;
        }

        public NodoArbol<T> Rotacion_doble_izquierda(NodoArbol<T> nodo, NodoArbol<T> nodo2)
        {
            NodoArbol<T> NODO = nodo2.Primero;
            nodo.Segundo = NODO!.Primero;
            NODO.Primero = nodo;
            nodo2.Primero = NODO.Segundo;
            NODO.Segundo = nodo2;
            nodo.Balance = (NODO.Balance == -1) ? 1 : 0;
            nodo2.Balance = (NODO.Balance == 1) ? -1 : 0;
            NODO.Balance = 0;
            return NODO;
        }

        public void Ruta(NodoArbol<T> Nodo, Queue<T> Items)
        {
            if (Nodo!.Primero != null)
            {
                Ruta(Nodo.Primero, Items);
            }
            Items.Enqueue(Nodo.Value);
            if (Nodo!.Segundo != null)
            {
                Ruta(Nodo.Segundo, Items);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            Queue<T> Elements = new Queue<T>();
            Ruta(Raiz, Elements);
            while (Elements.Count != 0)
            {
                yield return Elements.Dequeue();
            }
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }
    }
}
