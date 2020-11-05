using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaSimpleEstatica
{
    class Cola
    {
        private int final;
        public int tail
        {
            get { return final; }
            set { final = value; }
        }
        private int frente;
        public int head
        {
            get { return frente; }
            set { frente = value; }
        }
        private int maximo;
        public int Maximo
        {
            get { return maximo; }
            set { maximo = value; }
        }
        public string[] arregloCola;
        public Cola(int Tamaño)
        {
            Maximo = Tamaño;
            arregloCola = new string[Maximo];
            tail = head = -1;
        }
        public bool EstaLlena()
        {
            if(tail == Maximo - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EstaVacia()
        {
            if(head == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Encolar(string dato)
        {
            if (EstaLlena())
            {
                return;
            }
            if (EstaVacia())
            {
                tail = head = 0;
                arregloCola[head] = dato;
            }
            else
            {
                arregloCola[++tail] = dato;
            }
        }
        public void Desencolar()
        {
            if (EstaVacia())
            {
                return;
            }
            if(head == tail)
            {
                arregloCola[head] = null;
                head = tail = -1;
            }
            int contador = 0;
            for(int i = 0; i < tail; i++)
            {
                arregloCola[contador] = arregloCola[++contador];
            }
            arregloCola[tail] = null;
            tail--;
        }
        public string Front()
        {
            return arregloCola[0];
        }
        public string Imprimir()
        {
            string colaString = "";
            if (EstaVacia())
            {
                return "La cola esta vacia";
            }
            else
            {   
                colaString += arregloCola[head];
                for (int i = 0; i < tail; i++)
                {
                    colaString += "," + arregloCola[i + 1];
                }
                return colaString;
            }
        }
    }
}
