using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionT3
{
    internal class GrafoT3
    {
        public int[,] matriz;

        public int nodos { get; }

        public GrafoT3(int n)
        {
            nodos = n;

            matriz = new int[n, n];
        }
        public void AgregarArista(int origen, int destino, int peso)

        {
            matriz[origen, destino] = peso;
            matriz[destino, origen] = peso; 
        }

        public void MostrarMatriz()
        {
            for(int i= 0;i<matriz.GetLength(0);i++)
            {
                for(int j=0;j<matriz.GetLength(1);j++)
                {
                    Console.Write(matriz[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int NumGrupos()
        {
            bool[] visitado = new bool[nodos];

            int grupos = 0;

            for (int i = 0; i < nodos; i++)
            {
                if (!visitado[i])
                {

                    DFS(i, visitado);

                    grupos++;
                }
            }
            return grupos;
        }

        private void DFS(int nodo, bool[] visitado)
        {
            Stack<int> pila = new Stack<int>();

            pila.Push(nodo);

            while (pila.Count > 0)
            {
                int actual = pila.Pop();
                if (!visitado[actual])
                {
                    visitado[actual] = true;
                    for (int i = 0; i < nodos; i++)
                    {
                        if (matriz[actual, i] > 0 && !visitado[i])
                        {
                            pila.Push(i);
                        }
                    }
                }
            }
        }

        public bool GrupoCorrelativo(int nodo)

        {
            List<int> grupo = new List<int>();
            bool[] visitado = new bool[nodos];
            DFSColectar(nodo, visitado, grupo);
            grupo.Sort();

            for (int i = 1; i < grupo.Count; i++)
            {
                if (grupo[i] != grupo[i - 1] + 1)

                    return false;
            }
            return true;

        }

        private void DFSColectar(int nodo, bool[] visitado, List<int> grupo)

        {
            Stack<int> pila = new Stack<int>();
            pila.Push(nodo);
            while (pila.Count > 0)
            {
                int actual = pila.Pop();
                if (!visitado[actual])
                {
                    visitado[actual] = true;
                    grupo.Add(actual);
                    for (int i = 0; i < nodos; i++)
                    {
                        if (matriz[actual, i] > 0 && !visitado[i])
                        {
                            pila.Push(i);
                        }
                    }
                }
            }
        }


    }
}
