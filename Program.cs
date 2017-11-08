using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Сиакод_стр_20
{
    public class MyTree
    {
        public MyTree parent { get; set; }
        public MyTree root { get; set; }
        public string value { get; set; }
        public MyTree rightKnot { get; set; }
        public MyTree leftKnot { get; set; }
        public MyTree WithoutBalanceTree { get; set; }
        public MyTree(MyTree par)
        {
            parent = par;
        }
        public MyTree()
        {

        }
        public MyTree DisbalanseTree(MyTree tree)
        {
            if (tree.leftKnot != null)
                if (tree.leftKnot.value == " ")
                DisbalanseTree(tree.leftKnot);
            if(tree.rightKnot != null)
            if (tree.rightKnot.value == " ")
                DisbalanseTree(tree.rightKnot);
            tree = null;
            return tree; 
        }
        private static int ppp;
        private static int CountElements = 0;
        public void Paint1(MyTree Tree, string[] ArrayElements)
        {
            mas = new string[countLevels(ArrayElements)][];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = new string[0];
            }
            ForlevelFix1(Tree, ref mas);

            for (int i = 0; i < mas.Length; i++)
            {
                for (int probel = 0; probel < Math.Pow(2,mas.Length- 1-i)-1; probel++)
                    Console.Write(" ");
                for (int j = 0; j < mas[i].Length; j++)
                {
                    Console.Write(mas[i][j]);
                    if(i != 0)
                        for (int probel = 0; probel < Math.Pow(2, mas.Length - i) - 1; probel++)
                            Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        private int ForCL2()
        {
            int i = 0;
            while (Math.Pow(2, i) <= CountElements)
                i++;
            return i;
        }
        public void PaintForHand(MyTree Tree)
        {
            mas = new string[ForCL2()][];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = new string[0];
            }
            Lvl = 0;
            WithoutBalanceTree = Tree;
            MethodForBalance(Tree);
            ForlevelFix(Tree, ref mas);

            for (int i = 0; i < mas.Length; i++)
            {
                for (int probel = 0; probel < Math.Pow(2, mas.Length - 1 - i) - 1; probel++)
                    Console.Write(" ");
                for (int j = 0; j < mas[i].Length; j++)
                {
                    Console.Write(mas[i][j]);
                    if (i != 0)
                        for (int probel = 0; probel < Math.Pow(2, mas.Length - i) - 1; probel++)
                            Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        public MyTree Filling()
        {
            Console.WriteLine("Введите количество элементов");
            int n = int.Parse(Console.ReadLine());
            MyTree tree = new MyTree();
            WithoutBalanceTree = new MyTree();
            Console.WriteLine("Введите значение корня");
            tree.value = Console.ReadLine();
            CountElements++;
            ppp = n;
            tree = ForFilling(tree);
            HowFindLevels(tree);
            return tree;
        }
        private static int ForBalance = 0;
        private static int HowLevels = 0;//количество уровней с 0
        private static int u = 0;//для  HowLevels
        private void HowFindLevels(MyTree tree)
        {
            
            if (tree.leftKnot != null)
            {
                u++;
                HowFindLevels(tree.leftKnot);
            }
            if (tree.rightKnot != null)
            {
                u++;
                HowFindLevels(tree.rightKnot);
            }
            HowLevels = Math.Max(HowLevels, u);
            u--;
        }
        public MyTree MethodForBalance(MyTree tree)
        {
            if (tree.leftKnot != null)
            {
                ForBalance++;
                MethodForBalance(tree.leftKnot);
            }
            if (tree.rightKnot == null && tree.leftKnot == null && ForBalance < HowLevels)
            {
                tree.rightKnot = new MyTree(tree);
                tree.rightKnot.value = " ";
                tree.leftKnot = new MyTree(tree);
                tree.leftKnot.value = " ";
                ForBalance++;
                MethodForBalance(tree.leftKnot);
                ForBalance++;
                MethodForBalance(tree.rightKnot);
            }
            if (tree.rightKnot == null && tree.leftKnot != null)
            {
                tree.rightKnot = new MyTree();
                tree.rightKnot.value = " ";
                ForBalance++;
                MethodForBalance(tree.rightKnot);
            }
            if (tree.leftKnot == null && tree.rightKnot != null)
            {
                tree.leftKnot = new MyTree();
                tree.leftKnot.value = " ";
                ForBalance++;
                MethodForBalance(tree.leftKnot);
            }
            if (tree.rightKnot != null)
            {
                ForBalance++;
                MethodForBalance(tree.rightKnot);
            }
            ForBalance--;
            return tree;
        }
        private MyTree ForFilling(MyTree Tree)
        {
            point1:
            if (ppp > 1)
            {

                Console.WriteLine("Выберите заполенение левого(введите 1) или правого(введите 2) листа");
                Console.WriteLine("Чтобы вернуться на 1 лист назад нажимте ноль");
                int r = int.Parse(Console.ReadLine());
                if (r != 0)
                {
                    ppp--;
                    switch (r)
                    {
                        case 1:
                            Console.WriteLine("Введите значение левого узла");
                            Tree.leftKnot = new MyTree();
                            Tree.leftKnot.parent = Tree;
                            Tree.leftKnot.value = Console.ReadLine();
                            CountElements++;
                            Tree.leftKnot = ForFilling(Tree.leftKnot);
                            break;
                        case 2:
                            Console.WriteLine("Введите значение правого узла");
                            Tree.rightKnot = new MyTree();
                            Tree.rightKnot.parent = Tree;
                            Tree.rightKnot.value = Console.ReadLine();
                            CountElements++;
                            Tree.rightKnot = ForFilling(Tree.rightKnot);
                            break;
                    }
                }
                if (ppp > 1 && r != 0) goto point1;
            }
            return Tree;
        }
        int Lvl = 0;
        private string[][] mas;
        public void levelFix(MyTree Tree, string[] ArrayElements)
        {
            mas = new string[countLevels(ArrayElements)][];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = new string[0];
            }
            Lvl = 0;
            ForlevelFix(Tree,ref mas);
            for (int i = 0; i < mas.Length; i++)
                for (int j = 0; j < mas[i].Length; j++)
                    if (mas[i][j] != " ") Console.Write(mas[i][j] + " "); 
        }
        public void levelFixForHand(MyTree Tree)
        {
            mas = new string[HowLevels+1][];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = new string[0];
            }
            Lvl = 0;
            ForlevelFix(Tree, ref mas);
            for (int i = 0; i < mas.Length; i++)
                for (int j = 0; j < mas[i].Length; j++)
                    if (mas[i][j] != " ") Console.Write(mas[i][j] + " ");
        }
        private MyTree ForlevelFix1(MyTree Tree, ref string[][] arrayEl)//не работает
        {

            if (Tree.leftKnot != null)
            {
                Lvl++;
                ForlevelFix1(Tree.leftKnot, ref arrayEl);
            }
            if (Tree.rightKnot != null)
            {
                Lvl++;
                ForlevelFix1(Tree.rightKnot, ref arrayEl);

            }

            Array.Resize(ref arrayEl[Lvl], arrayEl[Lvl].Length + 1);
            arrayEl[Lvl][arrayEl[Lvl].Length - 1] = Tree.value;
            if (Tree.leftKnot != null && Tree.rightKnot == null || Lvl + 1 == arrayEl.Length - 1)
            {
                Array.Resize(ref arrayEl[Lvl + 1], arrayEl[Lvl + 1].Length + 1);
                arrayEl[Lvl + 1][arrayEl[Lvl + 1].Length - 1] = " ";
            }
            if (Tree.leftKnot == null && Tree.rightKnot != null || Lvl + 1 == arrayEl.Length - 1)
            {
                Array.Resize(ref arrayEl[Lvl + 1], arrayEl[Lvl + 1].Length + 1);
                arrayEl[Lvl + 1][arrayEl[Lvl + 1].Length - 1] = " ";
            }
            Lvl--;
            return null;
        }
        private MyTree ForlevelFix(MyTree Tree, ref string[][] arrayEl)//не работает
        {
            
            if (Tree.leftKnot != null)
            {
                Lvl++;
                ForlevelFix(Tree.leftKnot,ref arrayEl);
            }
            if (Tree.rightKnot != null)
            {
                Lvl++;
                ForlevelFix(Tree.rightKnot,ref arrayEl);

            }
            
            Array.Resize(ref arrayEl[Lvl], arrayEl[Lvl].Length + 1);
            arrayEl[Lvl][arrayEl[Lvl].Length-1] = Tree.value;
            Lvl--;
            return null;
        }
        int k = 0;
        int level = 0;
        private int countLevels(string[] arrayEl)
        {
            int i = 0; 
            while(Math.Pow(2,i) <= arrayEl.Length)
                i++;
            return i;
        }
        public MyTree IBTFill(string[] arrayEl, int Count)
        {
            level++;
            MyTree Tree = new MyTree();
            int countLeft = Count / 2;
            int countRight = Count - countLeft - 1;
            Tree.value = arrayEl[k];
            k++;
            if (countLeft > 0)
            {
                Tree.leftKnot = IBTFill(arrayEl, countLeft);
                Tree.leftKnot.parent = Tree;
            }
            if (countRight > 0)
            {
                Tree.rightKnot = IBTFill(arrayEl, countRight);
                Tree.rightKnot.parent = Tree;
            }
            level--;
            return Tree;
        }
        public MyTree Infix(MyTree tree)
        {
           if (tree.leftKnot != null)
                Infix(tree.leftKnot);
            Console.Write(tree.value + " ");
            if (tree.rightKnot != null)
                Infix(tree.rightKnot);
            return tree;
        }
        public MyTree Postfix(MyTree tree)
        {
            if (tree.leftKnot != null)
                Postfix(tree.leftKnot);
            if (tree.rightKnot != null)
                Postfix(tree.rightKnot);
            Console.Write(tree.value + " ");
            return tree;
        }
        public MyTree Prefix(MyTree tree)
        {
            Console.Write(tree.value + " ");
            if (tree.leftKnot != null)
                Prefix(tree.leftKnot);
            if (tree.rightKnot != null)
                Prefix(tree.rightKnot);
            return tree;
        }
    }
    class Program
    {
        static string[] readingFile()
        {
             
            FileStream fs = new FileStream("tree.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string st = sr.ReadToEnd();
            string[] Mas = st.Split(' ');
            sr.Close();
            fs.Close();
            return Mas;
        }
        static MyTree NRInfix(MyTree tree)
        {
            MyTree tags = new MyTree();
            tags.leftKnot = new MyTree();
            tags.leftKnot.parent = tags;
            tags.rightKnot = new MyTree();
            tags.rightKnot.parent = tags;
            point2:
            bool flag = true;
            if (tree.leftKnot != null && tags.leftKnot.value != "0_O")
            {
                tree = tree.leftKnot;
                tags = tags.leftKnot;
                tags.leftKnot = new MyTree();
                tags.rightKnot = new MyTree();
                tags.leftKnot.parent = tags;
                tags.rightKnot.parent = tags;
                flag = false;
            }
            if (!flag) goto point2;
            if ((tags.rightKnot.value == "0_O") && (tags.leftKnot.value != "0_O"))
            { }
            else
            if ((tags.rightKnot.value != "0_O") || (tags.leftKnot.value != "0_O"))
            {
                tags.value = "0_O";
                if (tree.value != " ") Console.Write(tree.value + " ");
            }
            if (tree.rightKnot != null && tags.rightKnot.value != "0_O")
            {
                tree = tree.rightKnot;
                tags = tags.rightKnot;
                tags.leftKnot = new MyTree();
                tags.rightKnot = new MyTree();
                tags.leftKnot.parent = tags;
                tags.rightKnot.parent = tags;
                flag = false;
            }
            if (!flag) goto point2;
            if (tree.parent != null)
            {
                tree = tree.parent;
                tags = tags.parent;
                goto point2;
            }
            return tree;
        }
        static MyTree NRPostfix(MyTree tree)
        {
            MyTree tags = new MyTree();
            tags.leftKnot = new MyTree();
            tags.leftKnot.parent = tags;
            tags.rightKnot = new MyTree();
            tags.rightKnot.parent = tags;
            point2:
            bool flag = true;
            if (tree.leftKnot != null && tags.leftKnot.value != "0_O")
            {
                tree = tree.leftKnot;
                tags = tags.leftKnot;
                tags.leftKnot = new MyTree();
                tags.rightKnot = new MyTree();
                tags.leftKnot.parent = tags;
                tags.rightKnot.parent = tags;
                flag = false;
            }
            if (!flag) goto point2;
            if (tree.rightKnot != null && tags.rightKnot.value != "0_O")
            {
                tree = tree.rightKnot;
                tags = tags.rightKnot;
                tags.leftKnot = new MyTree();
                tags.rightKnot = new MyTree();
                tags.leftKnot.parent = tags;
                tags.rightKnot.parent = tags;
                flag = false;
            }
            if (!flag) goto point2;
            tags.value = "0_O";
            Console.Write(tree.value + " ");
            if (tree.parent != null)
            {
                tree = tree.parent;
                tags = tags.parent;
                goto point2;
            }
            return tree;
        }
        static MyTree NRPrefix(MyTree tree)
        {
            MyTree tags = new MyTree();
            tags.leftKnot = new MyTree();
            tags.leftKnot.parent = tags;
            tags.rightKnot = new MyTree();
            tags.rightKnot.parent = tags;
            point2:
            tags.value = "0_O";
            Console.Write(tree.value + " ");
            point3:
            bool flag = true;
            if (tree.leftKnot != null && tags.leftKnot.value != "0_O")
            {
                tree = tree.leftKnot;
                tags = tags.leftKnot;
                tags.leftKnot = new MyTree();
                tags.rightKnot = new MyTree();
                tags.leftKnot.parent = tags;
                tags.rightKnot.parent = tags;
                flag = false;
            }
            if (!flag) goto point2;
            if (tree.rightKnot != null && tags.rightKnot.value != "0_O")
            {
                tree = tree.rightKnot;
                tags = tags.rightKnot;
                tags.leftKnot = new MyTree();
                tags.rightKnot = new MyTree();
                tags.leftKnot.parent = tags;
                tags.rightKnot.parent = tags;
                flag = false;
            }
            if (!flag) goto point2;
            if (tree.parent != null)
            {
                tree = tree.parent;
                tags = tags.parent;
                goto point3;
            }
            return tree;
        }
        static void Main(string[] args)
        {
            MyTree Tree = new MyTree();
            Console.WriteLine("Выберите:\n1.Рекурсивное построение идеально сбалансированного бинарного дерева\n для N узлов хранящихся в файле");
            Console.WriteLine("2.Задание дерева вручную");
            int n = int.Parse(Console.ReadLine());
            string[] arrayEl = new string[0];
            if (n == 1)
            {
                arrayEl = readingFile();
                Tree = Tree.IBTFill(arrayEl, arrayEl.Length);
                Tree.Paint1(Tree, arrayEl);
            }
            else
            {
                Tree = Tree.Filling();
                Tree.PaintForHand(Tree);
            }
            Console.WriteLine("Если вы хотите вывести процедуры нерекурсивных обходов нажмите 1");
            int m = int.Parse(Console.ReadLine());
            if (m == 1)
            {
                Console.WriteLine("Инфиксный обход");
                NRInfix(Tree);
                Console.WriteLine();
                Console.WriteLine("Постфиксный обход");
                NRPostfix(Tree);
                Console.WriteLine();
                Console.WriteLine("Префиксный обход");
                NRPrefix(Tree);
                Console.WriteLine();
                Console.WriteLine("Поуровневый обход");
                if (n == 1)
                    Tree.levelFix(Tree, arrayEl);
                else Tree.levelFixForHand(Tree);
            }
            Console.ReadKey();

        }
    }
}
