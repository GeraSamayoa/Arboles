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

        bool ArbolVacio()=> NodoRaiz == null;

        public string InsertarNodo (string nodo)
        {
            if(ArbolVacio()) { }
            return "Hola mundo";
        }
    }
}
