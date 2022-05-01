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

        public virtual void Ingresar(T dato, Delegate Comparador)
        {
            bool flag = false;
            this.Raiz = Agregar(this.Raiz!, dato, ref flag, Comparador);
        }

        public virtual NodoArbol<T> Agregar(NodoArbol<T> Raiz, T dato, ref bool Flag, Delegate Comparador)
        {
            NodoArbol<T> nodo;
            if (Raiz == null)
            {
                Raiz = new NodoArbol<T>(dato);
                Flag = true;
            }
            else
            {
                //Ingresa si el valor es menor que el valor en el nodo real.
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
                                //Rotacion simple a la derecha
                            }
                            else
                            {
                                //Rotacion doble a la derecha
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
                                    //rotacion simple a l izquierda
                                }
                                else
                                {
                                    //rotacion doble a la izquierda
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
    }
}
