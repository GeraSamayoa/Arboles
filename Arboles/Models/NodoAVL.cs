namespace Arboles.Models
{
    public class NodoAVL<T> where T : IComparable<T>
    {
       
            public T Value { get; set; }
            public NodoAVL<T> Left { get; set; }
            public NodoAVL<T> Right { get; set; }
            public int Height { get; set; }
        

    }
}
