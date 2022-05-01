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
        private NodoArbol<T> resultDPI = null;
        private NodoArbol<T> resultName = null;

        public PruebaArbolAVL()
        {
            Raiz = null;
        }
        public bool Vacio
        {
            get { return this.Raiz == null; }
        }

        public void Ingresar(T dato, Comparar<T> Comparador)
        {
            bool flag = false;
            this.Raiz = Agregar(this.Raiz!, dato, ref flag, Comparador);
        }

        public NodoArbol<T> Agregar(NodoArbol<T> Raiz, T dato, ref bool Flag, Comparar<T> Comparador)
        {
            NodoArbol<T> nodo;
            if (Raiz == null)
            {
                Raiz = new NodoArbol<T>(dato);
                Flag = true;
            }
            else
            {
                
                if (Comparador(dato, Raiz.Value) < 0)
                {
                    Raiz.Izquierdo = Agregar(Raiz.Izquierdo!, dato, ref Flag, Comparador);
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
                            nodo = Raiz.Izquierdo;
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
                    if (Comparador(dato, Raiz.Value) > 0)
                    {
                        Raiz.Derecho = Agregar(Raiz.Derecho!, dato, ref Flag, Comparador);
                        if (Flag)
                        {
                            if (Raiz.Balance == -1)
                            {
                                nodo = Raiz.Derecho;
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
            nodo.Izquierdo = nodo2.Derecho;
            nodo2.Derecho = nodo;
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
            NodoArbol<T> NODO = nodo2.Derecho;
            nodo.Izquierdo = NODO!.Derecho;
            NODO.Derecho = nodo;
            nodo2.Derecho = NODO.Izquierdo;
            NODO.Izquierdo = nodo2;
            nodo2.Balance = (NODO.Balance == -1) ? 1 : 0;
            nodo.Balance = (NODO.Balance == 1) ? -1 : 0;
            NODO.Balance = 0;
            return NODO;
        }

        public NodoArbol<T> Rotacion_simple_izquierda(NodoArbol<T> nodo, NodoArbol<T> nodo2)
        {
            nodo.Derecho = nodo2.Izquierdo;
            nodo2.Izquierdo = nodo;
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
            NodoArbol<T> NODO = nodo2.Izquierdo;
            nodo.Derecho = NODO!.Izquierdo;
            NODO.Izquierdo = nodo;
            nodo2.Izquierdo = NODO.Derecho;
            NODO.Derecho = nodo2;
            nodo.Balance = (NODO.Balance == -1) ? 1 : 0;
            nodo2.Balance = (NODO.Balance == 1) ? -1 : 0;
            NODO.Balance = 0;
            return NODO;
        }


        private void InOrderAVL(NodoArbol<T> root, ref ShowList<T> queueAVL)
        {
            if (root != null)
            {
                InOrderAVL(root.Izquierdo, ref queueAVL);
                queueAVL.Add(root.Value);
                InOrderAVL(root.Derecho, ref queueAVL);
            }
            return;
        }

        //Busquedas
        public T BusquedaCN(string buscar, CompararN<T> busqueda)
        {
            NodoArbol<T> search = Raiz;
            return BusquedaN(buscar, search, busqueda, resultName);
        }
        public T BusquedaCD(int buscar, CompararD<T> busqueda)
        {
            NodoArbol<T> search = Raiz;
            return BusquedaD(buscar, search, busqueda, resultDPI);
        }
        public T BusquedaD(int buscar, NodoArbol<T> nodo, CompararD<T> busqueda, NodoArbol<T> resultado)
        {
            if (busqueda(buscar, nodo.Value) == 1)
            {
                resultado = nodo;
                return resultado.Value;
            }
            else if (busqueda(buscar, nodo.Value) == 0)
            {
                if (nodo.Izquierdo != null)
                {
                    BusquedaD(buscar, nodo.Izquierdo, busqueda, resultado);
                }
                if (nodo.Derecho != null)
                {
                    BusquedaD(buscar, nodo.Derecho, busqueda, resultado);
                }
                if (resultado == null)
                {
                    return default;
                }
                else
                {
                    return resultado.Value;
                }
            }
            else
            {
                return default;
            }
        }
        public T BusquedaN(string buscar, NodoArbol<T> nodo, CompararN<T> busqueda, NodoArbol<T> resultado)
        {
            if (busqueda(buscar, nodo.Value) == 1)
            {
                resultado = nodo;
                return resultado.Value;
            }
            else if (busqueda(buscar, nodo.Value) == 0)
            {
                if (nodo.Izquierdo != null)
                {
                    BusquedaN(buscar, nodo.Izquierdo, busqueda, resultado);
                }
                if (nodo.Derecho != null)
                {
                    BusquedaN(buscar, nodo.Derecho, busqueda, resultado);
                }
                if (resultado == null)
                {
                    return default;
                }
                else
                {
                    return resultado.Value;
                }
            }
            else
            {
                return default;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queueAVL = new ShowList<T>();
            InOrderAVL(Raiz, ref queueAVL);

            while (!queueAVL.Empty())
            {
                yield return queueAVL.Dequeue();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
