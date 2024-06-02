
using Arboles.Models;
using System;
using System.Collections.Generic;

namespace ArbolBalanceado.Services
{
    public class ArbolBalanceadoNodo<T> where T : IComparable<T>
    {
        private NodoAVL<T> root;

        public void Insert(T value)
        {
            root = Insert(root, value);
        }

        private NodoAVL<T> Insert(NodoAVL<T> nodo, T value)
        {
            if (nodo == null)
            {
                return new NodoAVL<T> { Value = value, Height = 1 };
            }

            int compareResult = value.CompareTo(nodo.Value);

            if (compareResult < 0)
            {
                nodo.Left = Insert(nodo.Left, value);
            }
            else if (compareResult > 0)
            {
                nodo.Right = Insert(nodo.Right, value);
            }

            nodo.Height = 1 + Math.Max(Height(nodo.Left), Height(nodo.Right));

            int balance = BalanceFactor(nodo);

            if (balance > 1)
            {
                if (value.CompareTo(nodo.Left.Value) < 0)
                {
                    return RotateRight(nodo);
                }
                else
                {
                    nodo.Left = RotateLeft(nodo.Left);
                    return RotateRight(nodo);
                }
            }
            else if (balance < -1)
            {
                if (value.CompareTo(nodo.Right.Value) > 0)
                {
                    return RotateLeft(nodo);
                }
                else
                {
                    nodo.Right = RotateRight(nodo.Right);
                    return RotateLeft(nodo);
                }
            }

            return nodo;
        }

        public void Remove(T value)
        {
            root = Remove(root, value);
        }

        private NodoAVL<T> Remove(NodoAVL<T> nodo, T value)
        {
            if (nodo == null) return nodo;

            int compareResult = value.CompareTo(nodo.Value);

            if (compareResult < 0)
            {
                nodo.Left = Remove(nodo.Left, value);
            }
            else if (compareResult > 0)
            {
                nodo.Right = Remove(nodo.Right, value);
            }
            else
            {
                if ((nodo.Left == null) || (nodo.Right == null))
                {
                    nodo = (nodo.Left ?? nodo.Right);
                }
                else
                {
                    NodoAVL<T> temp = MinValueNodo(nodo.Right);
                    nodo.Value = temp.Value;
                    nodo.Right = Remove(nodo.Right, temp.Value);
                }
            }

            if (nodo == null) return nodo;

            nodo.Height = 1 + Math.Max(Height(nodo.Left), Height(nodo.Right));

            int balance = BalanceFactor(nodo);

            if (balance > 1)
            {
                if (BalanceFactor(nodo.Left) >= 0)
                {
                    return RotateRight(nodo);
                }
                else
                {
                    nodo.Left = RotateLeft(nodo.Left);
                    return RotateRight(nodo);
                }
            }
            else if (balance < -1)
            {
                if (BalanceFactor(nodo.Right) <= 0)
                {
                    return RotateLeft(nodo);
                }
                else
                {
                    nodo.Right = RotateRight(nodo.Right);
                    return RotateLeft(nodo);
                }
            }

            return nodo;
        }

        private NodoAVL<T> MinValueNodo(NodoAVL<T> nodo)
        {
            NodoAVL<T> current = nodo;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        public bool Contains(T value)
        {
            return Contains(root, value);
        }

        private bool Contains(NodoAVL<T> nodo, T value)
        {
            if (nodo == null) return false;

            int compareResult = value.CompareTo(nodo.Value);

            if (compareResult < 0)
                return Contains(nodo.Left, value);
            else if (compareResult > 0)
                return Contains(nodo.Right, value);
            else
                return true;
        }

        public IEnumerable<T> PreOrderTraversal()
        {
            List<T> result = new List<T>();
            PreOrderTraversal(root, result);
            return result;
        }

        private void PreOrderTraversal(NodoAVL<T> nodo, List<T> result)
        {
            if (nodo != null)
            {
                result.Add(nodo.Value);
                PreOrderTraversal(nodo.Left, result);
                PreOrderTraversal(nodo.Right, result);
            }
        }

        public IEnumerable<T> InOrderTraversal()
        {
            List<T> result = new List<T>();
            InOrderTraversal(root, result);
            return result;
        }

        private void InOrderTraversal(NodoAVL<T> nodo, List<T> result)
        {
            if (nodo != null)
            {
                InOrderTraversal(nodo.Left, result);
                result.Add(nodo.Value);
                InOrderTraversal(nodo.Right, result);
            }
        }

        public IEnumerable<T> PostOrderTraversal()
        {
            List<T> result = new List<T>();
            PostOrderTraversal(root, result);
            return result;
        }

        private void PostOrderTraversal(NodoAVL<T> nodo, List<T> result)
        {
            if (nodo != null)
            {
                PostOrderTraversal(nodo.Left, result);
                PostOrderTraversal(nodo.Right, result);
                result.Add(nodo.Value);
            }
        }

        private int Height(NodoAVL<T> nodo) => nodo?.Height ?? 0;

        private int BalanceFactor(NodoAVL<T> nodo) => Height(nodo.Left) - Height(nodo.Right);

        private NodoAVL<T> RotateRight(NodoAVL<T> nodo)
        {
            NodoAVL<T> newRoot = nodo.Left;
            nodo.Left = newRoot.Right;
            newRoot.Right = nodo;
            nodo.Height = 1 + Math.Max(Height(nodo.Left), Height(nodo.Right));
            newRoot.Height = 1 + Math.Max(Height(newRoot.Left), Height(newRoot.Right));
            return newRoot;
        }

        private NodoAVL<T> RotateLeft(NodoAVL<T> nodo)
        {
            NodoAVL<T> newRoot = nodo.Right;
            nodo.Right = newRoot.Left;
            newRoot.Left = nodo;
            nodo.Height = 1 + Math.Max(Height(nodo.Left), Height(nodo.Right));
            newRoot.Height = 1 + Math.Max(Height(newRoot.Left), Height(newRoot.Right));
            return newRoot;
        }
    }
}
