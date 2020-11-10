using System;

namespace BinaryTree
{
    class Node 
    {
        public Node() 
        {
            Value = 0;
            right = null;
            left = null;
            previous = null;
        }

        public int Value;
        public Node right;
        public Node left;
        public Node previous;

        
    }
    class BinarySearchTree 
    {
        Node Head;
        public int count = 0;

        /// <summary>
        /// Максимальное значение в дереве
        /// </summary>
        /// <returns></returns>
        public int GetMin() 
        {
            Node temp = new Node();
            temp = Head;
            while (temp.left != null) 
            {
                temp = temp.left;
            }
            return temp.Value;
        }

        /// <summary>
        /// Минимальное значение в дереве
        /// </summary>
        /// <returns></returns>
        public int GetMax()
        {
            Node temp = new Node();
            temp = Head;
            while (temp.right != null)
            {
                temp = temp.right;
            }
            return temp.Value;
        }

        /// <summary>
        /// Удалить элемент дерева по значению
        /// </summary>
        /// <param name="n">Значение элемента, который нужно удалить</param>
        /// <returns></returns>
        public bool RemoveNode(int n) 
        {
            Node actual = Search(n);
            if (actual == null) return false;

            Node p = actual.previous;
            if (actual.right == null && actual.left == null) //листик
            {
                if (actual.Value < p.Value) p.left = null;
                else p.right = null;
                return true;
            }
            else 
            {
                if (actual.left == null) 
                {
                    p.right = actual.right;
                    actual.right.previous = p;
                    return true;

                }
                else if(actual.right == null)
                {
                    p.left = actual.left;
                    actual.left.previous = p;
                    return true;
                }
                else 
                {
                    Node temp = new Node();
                    temp = actual.left;
                    while (temp.right != null) 
                    {
                        temp = temp.right;
                    }
                    actual.Value = temp.Value;
                    temp.previous.right = null;
                    return true;
                }

            }
        }

        /// <summary>
        /// Найти элемент по значению
        /// </summary>
        /// <param name="n">Значение элемента</param>
        /// <returns></returns>
        private Node Search(int n) 
        {
            Node temp = new Node();
            temp = Head;
            while (temp != null && temp.Value != n) 
            {
                if (temp.Value < n)
                {
                    temp = temp.right;
                }
                else temp = temp.left;
            }
            return temp;
        }

        /// <summary>
        /// Добавить элемент в дерево
        /// </summary>
        /// <param name="n">Значение элемента</param>
        /// <returns></returns>
        public bool Push(int n) 
        {
            Node newNode = new Node();
            newNode.Value = n;
            count++;

            if (IsEmpty())
            {
                Head = newNode;
            }
            else 
            {
                Node actual = new Node();
                Node p = new Node();
                actual = Head;
                bool flag = false;//false - лево; true - право
                while(actual != null)
                {
                    p = actual;
                    if (n < actual.Value)
                    {
                        actual = actual.left;
                        flag = false;
                    }
                    else 
                    {
                        actual = actual.right;
                        flag = true;
                    }
                }
                if (flag)
                {
                    p.right = newNode;

                }
                else 
                {
                    p.left = newNode;
                }
                newNode.previous = p;
            }
            return true;
        }

        /// <summary>
        /// Пямой обход дерева
        /// </summary>
        public void PRound() 
        {
            if (IsEmpty()) Console.WriteLine("Дерева нет");
            else
            {
                pRoundRec(Head);
            }
        }
        private void pRoundRec(Node node) 
        {
            
            if (node != null)
            {
                Console.Write(node.Value + " ");
                pRoundRec(node.left);
                pRoundRec(node.right);

            }

        }
        
        /// <summary>
        /// Симметричный обход дерева
        /// </summary>
        public void SRound()
        {
            if (IsEmpty()) Console.WriteLine("Дерева нет");
            else
            {
                sRoundRec(Head);
            }
        }
        private void sRoundRec(Node node)
        {

            if (node != null)
            {
               
                sRoundRec(node.left);
                Console.Write(node.Value + " ");
                sRoundRec(node.right);

            }

        }

        /// <summary>
        /// Обратный обход дерева
        /// </summary>
        public void ORound()
        {
            if (IsEmpty()) Console.WriteLine("Дерева нет");
            else
            {
                oRoundRec(Head);
            }
        }
        private void oRoundRec(Node node)
        {

            if (node != null)
            {

                sRoundRec(node.left);
                
                sRoundRec(node.right);

                Console.Write(node.Value + " ");

            }

        }

        /// <summary>
        /// Определить, пустое ли дерево
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() 
        {
            return (Head == null) ? true : false;
        }

        /// <summary>
        /// Высота дерева
        /// </summary>
        /// <returns></returns>
        public int Height() 
        {
            return height(Head);
        }
        private int height(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(height(node.left), height(node.right));
            }

        }

        /// <summary>
        /// Количество листьев в дереве
        /// </summary>
        /// <returns></returns>
        public int CountLeaves() 
        {
            return countLeaves(Head);
        }
        private int countLeaves(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else if (node.left == null && node.right == null)
            {
                return 1;
            }
            else
                return countLeaves(node.left) + countLeaves(node.right);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bs = new BinarySearchTree();
            bs.Push(30);
            bs.Push(25);
            bs.Push(40);
            bs.Push(17);
            bs.Push(26);
            bs.Push(33);
            bs.Push(43);
            bs.Push(32);
            bs.Push(35);
            bs.Push(50);
            Console.WriteLine();
            Console.WriteLine(bs.CountLeaves());


        }
    }
}
