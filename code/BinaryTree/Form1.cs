using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] data = (textBox1.Text.Trim()).ToCharArray();
            //char[] data = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            BinaryTree<char> tree = new BinaryTree<char>(data);

            tree.leaves = 0;

            tree.PreTraversal(tree.Head);
            tree.InTraversal(tree.Head);
            tree.LastTraversal(tree.Head);

            ThrBinaryTree<char> tree1 = new ThrBinaryTree<char>();
            ThrTreeNode<char> root = tree1.CreatBinaryTree(data, 0);
            //Console.WriteLine("二叉树中序线索化...");
            tree1.InTreading(root);
            //Console.Write("中序按后继节点遍历线索二叉树结果：");
            tree1.InOrderTraversal(root);
            //Console.WriteLine();
            //Console.Write("中序按前驱节点遍历线索二叉树结果：");
            //Console.WriteLine();
            ThrTreeNode<char> root2 = tree1.CreatBinaryTree(data, 0);
            //Console.WriteLine("二叉树先序线索化...");
            tree1.PreThreading(root2);
            //Console.Write("先序按后继节点遍历线索二叉树结果：");
            tree1.PreInTraversal(root2);


            textBox2.Text = tree.resultpre;
            textBox3.Text = tree.resultin;
            textBox4.Text = tree.resultpost;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public bool PrintTree(TreeNode<char> T, int x, int y)
        {
            string Signchar;
            if (T != null)
            {
                {
                    Signchar = T.Data.ToString();
                    Pen p = new Pen(Color.Black, 1);
                    if (T.Data.Equals('#'))
                        p = new Pen(Color.LightGray, 1);

                    g.DrawEllipse(p, x, y, 20, 20);

                    Font drawFont = new Font("Arial", 16);
                    SolidBrush drawBrush = new SolidBrush(Color.Red);

                    if (T.Data.Equals('#'))
                        drawBrush = new SolidBrush(Color.LightGray);

                    PointF drawPoint = new PointF(x, y);
                    g.DrawString(Signchar, drawFont, drawBrush, drawPoint);
                    System.Threading.Thread.Sleep(100); //1 second
                }
                if (PrintTree(T.LChild, x - (240 - y), y + 30))
                {
                    Pen p = new Pen(Color.Black, 2);
                    if (T.LChild.Data.Equals('#'))
                        p = new Pen(Color.LightGray, 2);
                    g.DrawLine(p, x, y + 10, x - (240 - y) + 20, y + 40);
                }
                if (PrintTree(T.RChild, x + (240 - y), y + 30))
                {
                    Pen p = new Pen(Color.Black, 2);
                    if (T.RChild.Data.Equals('#'))
                        p = new Pen(Color.LightGray, 2);

                    g.DrawLine(p, x + 20, y + 10, x + (240 - y) + 2, y + 40);
                }
                return true;
            }
            return false;
        }

        private void show_Load(object sender, EventArgs e)
        {

        }

        private void show_Activated(object sender, EventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {
            char[] data = (textBox1.Text.Trim()).ToCharArray();

            BinaryTree<char> tree = new BinaryTree<char>(data);

            g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 1);
            g.DrawEllipse(p, 300, 100, 20, 20);
            button3_Click(sender, e);
            PrintTree(tree.Head, 500, 100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.LightGray);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            char[] data = (textBox1.Text.Trim()).ToCharArray();
            //char[] data = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            BinaryTree<char> tree = new BinaryTree<char>(data);

            tree.leaves = 0;

            tree.PreTraversal(tree.Head);
            tree.InTraversal(tree.Head);
            tree.LastTraversal(tree.Head);

            ThrBinaryTree<char> tree1 = new ThrBinaryTree<char>();
            ThrTreeNode<char> root = tree1.CreatBinaryTree(data, 0);
            //Console.WriteLine("二叉树中序线索化...");
            tree1.InTreading(root);
            //Console.Write("中序按后继节点遍历线索二叉树结果：");
            tree1.InOrderTraversal(root);
            //Console.WriteLine();
            //Console.Write("中序按前驱节点遍历线索二叉树结果：");
            //Console.WriteLine();
            ThrTreeNode<char> root2 = tree1.CreatBinaryTree(data, 0);
            //Console.WriteLine("二叉树先序线索化...");
            tree1.PreThreading(root2);
            //Console.Write("先序按后继节点遍历线索二叉树结果：");
            tree1.PreInTraversal(root2);

            textBox5.Text = tree1.resultthrpre;
            textBox6.Text = tree1.resultthrin;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            char[] data = (textBox1.Text.Trim()).ToCharArray();
            //char[] data = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            BinaryTree<char> tree = new BinaryTree<char>(data);

            tree.leaves = 0;

            tree.PreTraversal(tree.Head);
            tree.InTraversal(tree.Head);
            tree.LastTraversal(tree.Head);

            ThrBinaryTree<char> tree1 = new ThrBinaryTree<char>();
            ThrTreeNode<char> root = tree1.CreatBinaryTree(data, 0);
            //Console.WriteLine("二叉树中序线索化...");
            tree1.InTreading(root);
            //Console.Write("中序按后继节点遍历线索二叉树结果：");
            tree1.InOrderTraversal(root);
            //Console.WriteLine();
            //Console.Write("中序按前驱节点遍历线索二叉树结果：");
            //Console.WriteLine();
            ThrTreeNode<char> root2 = tree1.CreatBinaryTree(data, 0);
            //Console.WriteLine("二叉树先序线索化...");
            tree1.PreThreading(root2);
            //Console.Write("先序按后继节点遍历线索二叉树结果：");
            tree1.PreInTraversal(root2);


            textBox7.Text = tree.leaves.ToString();

        }
    }
}


namespace WindowsFormsApp2
{

    //二叉树结点类
    public class TreeNode<T>
    {
        private T data; //数据域
        private TreeNode<T> lChild; //左孩子
        private TreeNode<T> rChild; //右孩子


        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public TreeNode<T> LChild
        {
            get { return lChild; }
            set { lChild = value; }
        }

        public TreeNode<T> RChild
        {
            get { return rChild; }
            set { rChild = value; }
        }

        public TreeNode()
        {
            data = default(T);
            lChild = null;
            rChild = null;
        }

        public TreeNode(T val)
        {
            data = val;
            lChild = null;
            rChild = null;
        }
    }

    class BinaryTree<T>
    {
        private TreeNode<T> head; //头指针
        private T[] datas; //用于构造二叉树的字符串

        public string resultpre, resultin, resultpost;
        public int leaves;
        public TreeNode<T> Head
        {
            get { return head; }
        }

        //创建二叉树
        public BinaryTree(T[] vals)
        {
            datas = vals;
            Add(head, 0); //给头结点添加孩子节点
        }

        //使用先序创建二叉树 #:表示该位置无节点
        private void Add(TreeNode<T> parent, int index)
        {
            if (parent == null)
            {
                parent = new TreeNode<T>(datas[index]);
                head = parent;
            }

            int leftIndex = 2 * index + 1; //计算当前结点左孩子的索引
            int rightIndex = 2 * index + 2; //计算当前结点右孩子的索引

            if (leftIndex < datas.Length)
            {
                if (!datas[leftIndex].Equals("#"))
                {
                    parent.LChild = new TreeNode<T>(datas[leftIndex]);
                    Add(parent.LChild, leftIndex);
                }
                else
                {
                    parent.LChild = null;
                }
            }
            if (rightIndex < datas.Length)
            {
                if (!datas[rightIndex].Equals("#"))
                {
                    parent.RChild = new TreeNode<T>(datas[rightIndex]);
                    Add(parent.RChild, rightIndex);
                }
                else
                {
                    parent.RChild = null;
                }
            }
        }

        //先序遍历
        public void PreTraversal(TreeNode<T> node)
        {
            if (node != null && (!node.Data.Equals('#')))
            {
                if (node.LChild == null && node.RChild == null)
                    leaves += 1;
                //Console.Write(node.Data + " ");
                resultpre += node.Data;

                PreTraversal(node.LChild);
                PreTraversal(node.RChild);
            }
        }

        //中序遍历
        public void InTraversal(TreeNode<T> node)
        {
            if (node != null && (!node.Data.Equals('#')))
            {
                InTraversal(node.LChild);
                // Console.Write(node.Data + " ");
                resultin += node.Data;

                InTraversal(node.RChild);
            }
        }

        //后序遍历
        public void LastTraversal(TreeNode<T> node)
        {
            if (node != null && (!node.Data.Equals('#')))
            {
                LastTraversal(node.LChild);
                LastTraversal(node.RChild);
                //Console.Write(node.Data + " ");
                resultpost += node.Data;

            }
        }


    }

    class ThrTreeNode<T>
    {
        private T data; //数据域
        public ThrTreeNode<T> lChild; //左孩子
        public ThrTreeNode<T> rChild; //右孩子
        private bool ltag; //true表线索, false结点
        private bool rtag;

        public Boolean Ltag
        {
            get { return ltag; }
            set { ltag = value; }
        }

        public Boolean Rtag
        {
            get { return rtag; }
            set { rtag = value; }
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public ThrTreeNode(T val)
        {
            this.data = val;
            this.lChild = null;
            this.rChild = null;
        }
    }

    class ThrBinaryTree<T>
    {
        private ThrTreeNode<T> pre; //指向刚刚访问过的结点
        public string resultthrpre, resultthrin;

        //通过数组构建二叉树
        public ThrTreeNode<T> CreatBinaryTree(T[] vals, int index)
        {
            ThrTreeNode<T> root = null;

            if (index < vals.Length)
            {
                root = new ThrTreeNode<T>(vals[index]);
                root.lChild = CreatBinaryTree(vals, index * 2 + 1);
                root.rChild = CreatBinaryTree(vals, index * 2 + 2);
            }
            return root;
        }


        //中序遍历线索化 
        // 如果当前结点无左孩子，则刚刚访问的pre结点为当前结点的前驱
        // 如果刚刚访问的pre结点无右孩子，则当前结点为pre结点的后继
        public void InTreading(ThrTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }
            //处理左子树
            InTreading(root.lChild);

            //左指针为空,将左指针指向前驱节点
            if (root.lChild == null)
            {
                root.lChild = pre;
                root.Ltag = true;
            }
            //前一个节点的后继节点指向当前节点
            if (pre != null && pre.rChild == null)
            {
                pre.rChild = root;
                pre.Rtag = true;
            }
            pre = root;
            //处理右子树
            InTreading(root.rChild);
        }

        //中序遍历线索二叉树，按照后继方式进行遍历
        public void InOrderTraversal(ThrTreeNode<T> root)
        {
            //1、找中序遍历方式最开始的节点
            while (root != null && !root.Ltag)
            {
                root = root.lChild;
            }

            while (root != null)
            {
                //Console.Write(root.Data + " ");
                if (!root.Data.Equals('#'))
                    resultthrin += root.Data;

                //如果右指针是线索
                if (root.Rtag)
                {
                    root = root.rChild;
                }
                //如果右指针不是线索，找到右子树开始的节点(即右子树最左边的结点)
                else
                {
                    root = root.rChild;
                    while (root != null && !root.Ltag)
                    {
                        root = root.lChild;
                    }
                }
            }
        }


        //前序线索化二叉树
        public void PreThreading(ThrTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }
            //左指针为空,将左指针指向前驱节点
            if (root.lChild == null)
            {
                root.lChild = pre;
                root.Ltag = true;
            }
            //前一个节点的后继节点指向当前节点
            if (pre != null && pre.rChild == null)
            {
                pre.rChild = root;
                pre.Rtag = true;
            }
            pre = root;
            //如果左指针不是索引，处理左子树
            if (!root.Ltag)
            {
                PreThreading(root.lChild);
            }
            //如果右指针不是索引，处理右子树
            if (!root.Rtag)
            {
                PreThreading(root.rChild);
            }
        }

        //前序遍历线索二叉树（按照后继线索遍历）
        public void PreInTraversal(ThrTreeNode<T> root)
        {
            while (root != null)
            {
                while (!root.Ltag)
                {
                    //Console.Write(root.Data + " ");
                    if (!root.Data.Equals('#'))
                        resultthrpre += root.Data;

                    root = root.lChild;
                }
                //Console.Write(root.Data + " ");
                if (!root.Data.Equals('#'))
                    resultthrpre += root.Data;

                root = root.rChild;
            }
        }
    }



}
