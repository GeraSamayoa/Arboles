using Arboles.Models;

namespace Arboles.Services
{
    public class ArbolBinarioBusqueda
    {
        public Nodo? NodoRaiz { get; set; }
        public int? TotalNodos { get; set; }

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

        // Eliminar un nodo del árbol
        public bool Eliminar(int valor)
        {
            try
            {
                NodoRaiz = EliminarRecursivo(NodoRaiz, valor);
                return true;
            }
            catch (Exception ex)
            {
                // Manejar excepción aquí
                Console.WriteLine($"Error al eliminar el valor {valor}: {ex.Message}");
                return false;
            }
        }

        private Nodo EliminarRecursivo(Nodo actual, int valor)
        {
            if (actual == null)
            {
                return null;
            }

            if (valor == actual.Informacion)
            {
                if (actual.RamaIzquierda == null && actual.RamaDerecha == null)
                {
                    return null;
                }
                else if (actual.RamaIzquierda == null)
                {
                    return actual.RamaDerecha;
                }
                else if (actual.RamaDerecha == null)
                {
                    return actual.RamaIzquierda;
                }
                else
                {
                    Nodo sucesor = ObtenerSucesor(actual.RamaDerecha);
                    actual.Informacion = sucesor.Informacion;
                    actual.RamaDerecha = EliminarRecursivo(actual.RamaDerecha, sucesor.Informacion);
                    return actual;
                }
            }
            else if (valor < actual.Informacion)
            {
                actual.RamaIzquierda = EliminarRecursivo(actual.RamaIzquierda, valor);
            }
            else
            {
                actual.RamaDerecha = EliminarRecursivo(actual.RamaDerecha, valor);
            }

            return actual;
        }

        private Nodo ObtenerSucesor(Nodo actual)
        {
            while (actual.RamaIzquierda != null)
            {
                actual = actual.RamaIzquierda;
            }
            return actual;
        }
    }
}
