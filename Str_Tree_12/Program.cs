using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Str_Tree_12
{
    class Program
    {
        class Node
        {
            public string data;
            public Node left, right;
        };
        static Node NewNode(string data)
        {
            Node node = new Node();
            node.left = null;
            node.right = null;
            node.data = data;
            return node;
        }
        static void SolveExample(Node root, Queue<string> numbers, Queue<string> signs)
        {
            string allNumbers = "0123456789";
            string allSign = "+-*";
            string conv;
            int value;
            if (allSign.Contains(root.data.ToString()))
            {
                signs.Enqueue(root.data);
            }
            if (allNumbers.Contains(root.data.ToString()))
            {
                numbers.Enqueue(root.data);
            }
            // если нулл, вернуть ничего
            if (root == null)
                return;
            // если это листок, напечатать его содержимое    
            if (root.left == null &&
                root.right == null)
            {
                return;
            }
            // если левый потомок существует, искать лист
            // рекурсия
            if (root.left != null)
                SolveExample(root.left, numbers, signs);
            // If правый потомок существует, искать лист
            // рекурсия
            if (root.right != null)
                SolveExample(root.right, numbers, signs);
        }
        public static void Main()
        {
            Node root = new Node { };
            root = NewNode("+");
            root.left = NewNode("5");
            root.right = NewNode("*");
            root.right.left = NewNode("3");
            root.right.right = NewNode("8");
            Queue<string> numbers = new Queue<string> { };
            Queue<string> signs = new Queue<string> { };
            SolveExample(root, numbers, signs);
            signs = new Queue<string>(signs.Reverse());
            numbers = new Queue<string>(numbers.Reverse());
            while (signs.Count > 0)
            {
                string sign = signs.Dequeue();
                Console.WriteLine(sign);
                int number1;
                int number2;
                int res;
                string rem;
                if (sign == "+")
                {
                    rem = numbers.Dequeue();
                    number1 = int.Parse(rem);
                    rem = numbers.Dequeue();
                    number2 = int.Parse(rem);
                    res = number1 + number2;
                    numbers.Enqueue(res.ToString());
                }
                if (sign == "*")
                {
                    rem = numbers.Dequeue();
                    number1 = int.Parse(rem);
                    rem = numbers.Dequeue();
                    number2 = int.Parse(rem);
                    res = number1 * number2;
                    numbers.Enqueue(res.ToString());
                }
                if (sign == "-")
                {
                    rem = numbers.Dequeue();
                    number1 = int.Parse(rem);
                    rem = numbers.Dequeue();
                    number2 = int.Parse(rem);
                    res = number1 - number2;
                    numbers.Enqueue(res.ToString());
                }
            }
            Console.WriteLine(numbers.Dequeue());
        }
    }
}