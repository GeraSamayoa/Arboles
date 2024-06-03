namespace Arboles.Models
{
    public class Nodo
    {
        public Nodo? RamaIzquierda { get; set; }

        public int Informacion { get; set; }

        public Nodo? RamaDerecha { get; set; }
        public Nodo()
        {
            RamaIzquierda = null;
            Informacion = 0;
            RamaDerecha = null;
        }

        public Nodo(int informacion)
        {
            RamaIzquierda = null;
            Informacion = informacion;
            RamaDerecha = null;
        }
    }
}
