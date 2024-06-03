using Arboles.Models;

namespace Arboles.Services
{
    public class ArbolBinarioBusqueda
    {
        public Nodo? NodoRaiz { get; set; }
        public int ? TotalNodos { get; set; }

        public ArbolBinarioBusqueda()
        {
            NodoRaiz = null;
        }

        public bool Insertar(int valor)
        {
            try
            {
                NodoRaiz = InsertarNodo(NodoRaiz, valor);
                return true;
            }
            catch (Exception ex)
            {
                // Manejar excepción aquí
                Console.WriteLine($"Error al insertar el valor {valor}: {ex.Message}");
                return false;
            }
        }

        private Nodo InsertarNodo(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                nodo = new Nodo(valor);
                return nodo;
            }

            if (valor == nodo.Informacion)
                throw new Exception("El valor ya existe en el árbol");

            if (valor < nodo.Informacion)
                nodo.RamaIzquierda = InsertarNodo(nodo.RamaIzquierda, valor);
            else
                nodo.RamaDerecha = InsertarNodo(nodo.RamaDerecha, valor);

            return nodo;
        }

        // Búsqueda de un valor en el árbol
        public bool Buscar(int valor)
        {
            return Buscar(NodoRaiz, valor);
        }

        private bool Buscar(Nodo? nodo, int valor)
        {
            if (nodo == null)
                return false;

            if (valor == nodo.Informacion)
                return true;

            if (valor < nodo.Informacion)
                return Buscar(nodo.RamaIzquierda, valor);
            else
                return Buscar(nodo.RamaDerecha, valor);
        }
    }
}