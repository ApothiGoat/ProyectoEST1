using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using ProyectoASE.Models;

namespace ProyectoASE.Prueba_Arbol
{
    public class ArbolAVL<T> : IEnumerable<T>
    {
        private NodoArbol<T>  Raiz;
        private NodoArbol<T> resultDPI = null;
        private int citas = 0;

        public ArbolAVL()
        {
            Raiz = null;
        }
        public bool Vacio
        {
            get { return this.Raiz == null; }
        }
        public bool Ingresar(T dato, Comparar<T> Comparador, CheckDay<T> Check)
        {
            bool flag = false;
            bool succes = false;
            this.Raiz = Agregar(this.Raiz!, dato, ref flag, Comparador, Check, ref succes);
            if(succes == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public NodoArbol<T> Agregar(NodoArbol<T> Raiz, T dato, ref bool Flag, Comparar<T> Comparador, CheckDay<T> check, ref bool succes)
        {
            NodoArbol<T> nodo;
            if (Raiz == null)
            {
                Raiz = new NodoArbol<T>(dato);
                Flag = true;
                succes = true;
            }
            else
            {
                citas = 0;
                if (Check(dato, ref citas, Raiz, check) <= 6)
                {
                    succes = true;
                    if (Comparador(dato, Raiz.Value) < 0)
                    {
                        Raiz.Izquierdo = Agregar(Raiz.Izquierdo!, dato, ref Flag, Comparador, check, ref  succes);
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
                            Raiz.Derecho = Agregar(Raiz.Derecho!, dato, ref Flag, Comparador, check, ref succes);
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
                else
                {
                    succes = false;
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

        //Verificación de día
        public int Check(T dato, ref int contador, NodoArbol<T> nodo, CheckDay<T> check)
        {
            if(nodo != null)
            {
                if (check(dato, nodo.Value) == 1)
                {
                    if (nodo.Izquierdo != null)
                    {
                        contador++;
                        Check(dato, ref contador, nodo.Izquierdo, check);
                    }
                    if (nodo.Derecho != null)
                    {
                        contador++;
                        Check(dato, ref contador, nodo.Derecho, check);
                    }
                }
                else
                {
                    if (nodo.Izquierdo != null)
                    {
                        Check(dato, ref contador, nodo.Izquierdo, check);
                    }
                    if (nodo.Derecho != null)
                    {
                        Check(dato, ref contador, nodo.Derecho, check);
                    }
                }
            }
            return contador;


        }

        //Busquedas
        public List<T> BusquedaCN(string buscar, CompararN<T> busqueda)
        {
            List<T> nombres = new List<T>();
            BusquedaN(buscar, Raiz, busqueda, ref nombres);
            return nombres;
        }
        public T BusquedaCD(long buscar, CompararD<T> busqueda)
        {
            resultDPI = null;
            return BusquedaD(buscar, Raiz, busqueda);
        }
        public T BusquedaD(long buscar, NodoArbol<T> nodo, CompararD<T> busqueda)
        {
            if(nodo != null)
            {
                if (busqueda(buscar, nodo.Value) == 1)
                {
                    resultDPI = nodo;
                    return resultDPI.Value;
                }
                else if (busqueda(buscar, nodo.Value) == 0)
                {
                    if (nodo.Izquierdo != null)
                    {
                        resultDPI = null;
                        BusquedaD(buscar, nodo.Izquierdo, busqueda);
                    }
                    else if (nodo.Derecho != null)
                    {
                        resultDPI = null;
                        BusquedaD(buscar, nodo.Derecho, busqueda);
                    }
                    if (resultDPI == null)
                    {
                        return default;
                    }
                    else
                    {
                        return resultDPI.Value;
                    }
                }
                else
                {
                    return default;
                }
            }
            else
            {
                return default;
            }
        }
        public void BusquedaN(string buscar, NodoArbol<T> nodo, CompararN<T> busqueda, ref List<T> Nombres)
        {
            if(nodo != null)
            {
                if(busqueda(buscar, nodo.Value) == 1)
                {
                    Nombres.Add(nodo.Value);
                    if(nodo.Izquierdo != null)
                    {
                        BusquedaN(buscar, nodo.Izquierdo, busqueda, ref Nombres);
                    }
                    if (nodo.Derecho != null)
                    {
                        BusquedaN(buscar, nodo.Derecho, busqueda, ref Nombres);
                    }
                }
                else
                {
                    if (nodo.Izquierdo != null)
                    {
                        BusquedaN(buscar, nodo.Izquierdo, busqueda, ref Nombres);
                    }
                    if (nodo.Derecho != null)
                    {
                        BusquedaN(buscar, nodo.Derecho, busqueda, ref Nombres);
                    }
                }
            }
        }

        //Edit
        public void EditarCall(T nuevo, long dpi, CompararD<T> busqueda, CheckDay<T> check)
        {
            Editar(nuevo, dpi, Raiz, busqueda, check);
        }
        public void Editar(T nuevo, long buscar, NodoArbol<T> nodo, CompararD<T> busqueda, CheckDay<T> check)
        {
            if (Check(nuevo, ref citas, Raiz, check) <= 6)
            {
                if (busqueda(buscar, nodo.Value) == 1)
                {
                    nodo.Value = nuevo;
                }
                else if (busqueda(buscar, nodo.Value) == 0)
                {
                    if (nodo.Izquierdo != null)
                    {
                        resultDPI = null;
                        Editar(nuevo, buscar, nodo.Izquierdo, busqueda, check);
                    }
                    else if (nodo.Derecho != null)
                    {
                        resultDPI = null;
                        Editar(nuevo, buscar, nodo.Derecho, busqueda, check);
                    }
                }
            }
        }

        //Seguimientos
        public List<T> FindFollowUpNeeded(CompararTime<T> compare)
        {
            List<T> lista = new List<T>();
            FollowUp(Raiz, compare, ref lista);
            return lista;
        }
        public void FollowUp(NodoArbol<T> nodo, CompararTime<T> compare, ref List<T> followUpList)
        {
            if(nodo != null)
            {
                if (compare(nodo.Value) == 1)
                {
                    followUpList.Add(nodo.Value);
                    if (nodo.Izquierdo != null)
                    {
                        FollowUp(nodo.Izquierdo, compare, ref followUpList);
                    }
                    if (nodo.Derecho != null)
                    {
                        FollowUp(nodo.Derecho, compare, ref followUpList);
                    }
                }
                else
                {
                    if (nodo.Izquierdo != null)
                    {
                        FollowUp(nodo.Izquierdo, compare, ref followUpList);
                    }
                    if (nodo.Derecho != null)
                    {
                        FollowUp(nodo.Derecho, compare, ref followUpList);
                    }
                }
            }
        }

        //Two Months && Ortodoncia
        public List<T> FindOrtodoncia(CompararDescription<T> compare)
        {
            List<T> lista = new List<T>();
            OrtodonciaFollowUp(Raiz, compare, ref lista);
            return lista;
        }
        public void OrtodonciaFollowUp(NodoArbol<T> nodo, CompararDescription<T> compare, ref List<T> OrtodonciafollowUpList)
        {
            if(nodo != null)
            {
                if (compare(nodo.Value) == 1)
                {
                    OrtodonciafollowUpList.Add(nodo.Value);
                    if (nodo.Izquierdo != null)
                    {
                        OrtodonciaFollowUp(nodo.Izquierdo, compare, ref OrtodonciafollowUpList);
                    }
                    if (nodo.Derecho != null)
                    {
                        OrtodonciaFollowUp(nodo.Derecho, compare, ref OrtodonciafollowUpList);
                    }
                }
                else
                {
                    if (nodo.Izquierdo != null)
                    {
                        OrtodonciaFollowUp(nodo.Izquierdo, compare, ref OrtodonciafollowUpList);
                    }
                    if (nodo.Derecho != null)
                    {
                        OrtodonciaFollowUp(nodo.Derecho, compare, ref OrtodonciafollowUpList);
                    }
                }
            }
        }

        //Search Caries && 4 months
        public List<T> FindCaries(CompararDescription<T> compare)
        {
            List<T> lista = new List<T>();
            CariesFollowUp(Raiz, compare, ref lista);
            return lista;
        }
        public void CariesFollowUp(NodoArbol<T> nodo, CompararDescription<T> compare, ref List<T> CariesfollowUpList)
        {
            if(nodo != null)
            {
                if (compare(nodo.Value) == 1)
                {
                    CariesfollowUpList.Add(nodo.Value);
                    if (nodo.Izquierdo != null)
                    {
                        CariesFollowUp(nodo.Izquierdo, compare, ref CariesfollowUpList);
                    }
                    if (nodo.Derecho != null)
                    {
                        CariesFollowUp(nodo.Derecho, compare, ref CariesfollowUpList);
                    }
                }
                else
                {
                    if (nodo.Izquierdo != null)
                    {
                        CariesFollowUp(nodo.Izquierdo, compare, ref CariesfollowUpList);
                    }
                    if (nodo.Derecho != null)
                    {
                        CariesFollowUp(nodo.Derecho, compare, ref CariesfollowUpList);
                    }
                }
            }
        }

        //Search Specific && 6 months
        public List<T> FindSpecific(CompararDescription<T> compare)
        {
            List<T> lista = new List<T>();
            SpecificFollowUp(Raiz, compare, ref lista);
            return lista;
        }
        public void SpecificFollowUp(NodoArbol<T> nodo, CompararDescription<T> compare, ref List<T> SpecificfollowUpList)
        {
            if(nodo != null)
            {
                if (compare(nodo.Value) == 1)
                {
                    SpecificfollowUpList.Add(nodo.Value);
                    if (nodo.Izquierdo != null)
                    {
                        SpecificFollowUp(nodo.Izquierdo, compare, ref SpecificfollowUpList);
                    }
                    if (nodo.Derecho != null)
                    {
                        SpecificFollowUp(nodo.Derecho, compare, ref SpecificfollowUpList);
                    }
                }
                else
                {
                    if (nodo.Izquierdo != null)
                    {
                        SpecificFollowUp(nodo.Izquierdo, compare, ref SpecificfollowUpList);
                    }
                    if (nodo.Derecho != null)
                    {
                        SpecificFollowUp(nodo.Derecho, compare, ref SpecificfollowUpList);
                    }
                }
            }
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