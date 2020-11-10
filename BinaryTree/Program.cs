using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public bool IsEmpty() 
        {
            return (Head == null) ? true : false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bs = new BinarySearchTree();
            Random rn = new Random();
            /*for (int i = 0; i < 10; i++) 
            {
                int n = rn.Next(10, 99);
                bs.Push(n);
                Console.Write(n + " ");

            }  */
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
            bs.PRound();
            Console.WriteLine();
            Console.WriteLine(bs.GetMin());


        }
    }
}
