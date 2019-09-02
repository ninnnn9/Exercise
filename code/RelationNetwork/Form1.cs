using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;


namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public int Mouse_x;
        public int Mouse_y;
        public bool draw_vertex = false;
        public bool draw_Arc = false;
        public int vertexCount = 0;
        public int ArcCount = 0;
        public Vertex start, end;                   //一条直线的起始点和终点
        public int firstOutput = 0;
        public int maxvertex = 200;
        public Vertex changeVertexLoc;             //选中的要改变位置的点
        public int change = 0;                     //为0 时可以修改节点位置
        public int againV = 0;                     //在同一位置重画顶点
        public int againA = 0;                     //在同一位置重画边
        public int ac = 0, vc = 0;


        public int choose;
        public int[] result=new int[100];
        public int resultsum;
        public int[] asso = new int[100];

        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.White;
            for (int i = 0; i < 100; i++)
                for (int j = 0; j < 100; j++)
                {
                    Statistic.AdjMatrix[i, j] = 0;
                    Statistic.Sim[i, j] = 0;
                }
            //textBox1.Text = "";
            button4.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vc == 0)
            {
                draw_vertex = true;
                draw_Arc = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ac == 0)
            {
                draw_Arc = true;
                draw_vertex = false;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (draw_vertex == true)
            {
                double l;
                if (vertexCount > 0)                                                              //画过顶点的地方不可再画
                {
                    for (Vertex v = Statistic.list.start; v != null; v = v.next_adjcent)
                    {
                        l = (v.cx - e.X) * (v.cx - e.X) + (v.cy - e.Y) * (v.cy - e.Y);
                        if (l <= 2 * v.radius * v.radius)
                        {
                            againV = 1;
                            break;
                        }
                    }
                }
                if (againV == 0)//在同一位置重画顶点
                {
                    Vertex vertex = new Vertex(e.X, e.Y, 10, ++vertexCount);
                    vertex.paper = pictureBox1;
                    Statistic.list.insert(vertex);
                    vertex.draw(Color.Black);
                }
                againV = 0;
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (draw_Arc == true)
            {
                int len = Statistic.list.length();
                start = Statistic.list.search(e.X, e.Y, len);
                /*if (start != null)
                    textBox1.Text += start.name + " ";
                else
                    textBox1.Text += "null ";
                    */
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            {
                if (draw_Arc == true && start != null)
                {
                    int len = Statistic.list.length();
                    end = Statistic.list.search(e.X, e.Y, len);
                    if (againA == 0)   //不在相同位置重画边
                    {
                        if (start == end)//不在一个顶点画边
                        {
                            againA = 1;
                        }
                        for (int i = 0; i < ArcCount; i++)
                            if (start == Statistic.arcnode[i].start && end == Statistic.arcnode[i].end)
                            {
                                againA = 1;
                                break;
                            }

                    }
                    if (againA == 0)
                    {

                        /*if (end != null)
                            textBox1.Text += end.name + "\r\n";
                        else
                            textBox1.Text += "null" + "\r\n";
                        */
                        if (end != null)
                        {
                            Arcs arc = new Arcs(ArcCount + 1, "e" + ArcCount.ToString(), start, end);
                            arc.paper = pictureBox1;
                            Statistic.arcnode[ArcCount] = arc;
                            ArcCount++;

                            arc.draw(Color.Black);
                            start.draw(Color.Black);
                            Statistic.AdjMatrix[start.NO, end.NO] = 1;
                            Statistic.AdjMatrix[end.NO, start.NO] = 1;
                        }
                    }
                    againA = 0;
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            choose=int.Parse(textBox1.Text);
            int count = 0;
            int[] flag = new int[vertexCount];
            for (int i = 0; i < vertexCount; i++)
                flag[i] = 0;
            for(int i=0;i< vertexCount;i++)
            {
                if(Statistic.AdjMatrix[choose,i]==1)
                {
                    for(int j=0;j<vertexCount;j++)
                        if(choose!=j&&Statistic.AdjMatrix[i,j]==1&& Statistic.AdjMatrix[choose, j] == 0)
                        {
                            if(flag[j]==0)
                            {
                                textBox2.Text += j.ToString() + '\r' + '\n';
                                result[count++] = j;
                                flag[j] = 1;
                            }
                        }
                }
            }
            resultsum = count;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < resultsum; k++)
                asso[k] = 0;
            for (int i = 0; i < resultsum; i++)
            {
                for (int j = 0; j < vertexCount; j++)
                {
                    if (Statistic.AdjMatrix[result[i], j] == 1 && Statistic.AdjMatrix[choose, j] == 1)
                    {
                        asso[i] += 1;
                    }
                }
            }
            //冒泡排序 
            int test = 0;//定义一个中间变量，用来交换值

            for (int i = 0; i < resultsum - 1; i++)//我们外层循环需要循环n-1次
            {
                for (int j = 0; j < resultsum - 1 - i; j++)
                {
                    if (asso[j] > asso[j + 1])//判断两个值大小是否要交换值
                    {
                        test = asso[j + 1];//如果数组第二个数小于前一个数，那么把第二个小的数先存放在 test中
                        asso[j + 1] = asso[j];//把前一个大的数放到后面
                        asso[j] = test;//再把我们存放在test中的小的数放到前面

                        test = result[j + 1];//如果数组第二个数小于前一个数，那么把第二个小的数先存放在 test中
                        result[j + 1] = result[j];//把前一个大的数放到后面
                        result[j] = test;//再把我们存放在test中的小的数放到前面

                    }
                }
            }

            for(int t=0;t< resultsum;t++)
            textBox3.Text += result[t].ToString() +"："+ asso[t].ToString() + "\r\n";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (vertexCount == 0)
                MessageBox.Show("绘制为空，请继续绘制。", "提示");
            if (Statistic.graph == null && vertexCount != 0)
            {
                Statistic.graph = new Graph(Statistic.arcnode, Statistic.list, ArcCount, vertexCount);
                ac = 1;
                vc = 1;

                //可能没必要
                //Vertex_button1.Visible = false;
                //Arcs_button_.Visible = false;

                //Form1 f1 = new Form1();
                //f1.Show();
            }

            button4.Visible = false;
            button1.Visible = false;
            button2.Visible = false;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Statistic.graph = null;
            button1.Visible = true;
            button2.Visible = true;
            draw_vertex = false;
            draw_Arc = false;
            vertexCount = 0;
            ArcCount = 0;
            maxvertex = 200;
            againV = 0;
            againA = 0;
            ac = 0;
            vc = 0;
            for (int i = 0; i < 100; i++)
                for (int j = 0; j < 100; j++)
                {
                    /*                   if (i == j)
                                       {
                                           Statistic.AdjMatrix[i, j] = 1;
                                           Statistic.Sim[i, j] = 0;
                                       }
                                       else
                                       {
                                           Statistic.AdjMatrix[i, j] = 0;
                                           Statistic.Sim[i, j] = 0;
                                       }
                                       */
                    Statistic.AdjMatrix[i, j] = 0;
                    Statistic.Sim[i, j] = 0;
                }
            //textBox1.Text = "";
            Statistic.list.clear();

        }
    }
}


namespace WindowsFormsApp4
{
    class Graph
    {
        public LinkVertex Adjlist;             //存储头结点
                                               //        public string DFSlist = "";      //存储DFS访问的节点
                                               //        public string BFSlist = "";      //存储BFS访问的节点
                                               //        public string Toploglist = "";   //存储拓扑排序当吻得节点
                                               //        public String criticArcs = "";   //存储关键路径上的边
        public int arcnum;               //弧节点数
        public int vertexnum;            //顶点数
        Arcs[] arcs = new Arcs[100];

        public Graph(Arcs[] a, LinkVertex l, int an, int vn)
        {
            Arcs pre = null;
            Arcs a1;
            for (int i = 0; i < arcs.Length; i++)
            {
                for (Vertex v = l.start; v != null; v = v.next_adjcent)
                    if (a[i] != null && a[i].start == v)
                    {
                        if (v.first == null)
                            v.first = a[i];
                        else
                        {
                            a1 = v.first;
                            while (a1 != null)
                            {
                                pre = a1;
                                a1 = a1.next_arcs;
                            }
                            if (pre != null)
                                pre.next_arcs = a[i];
                        }
                    }
            }
            vertexnum = l.length();
            arcnum = an;
            Adjlist = l;
            arcs = a;
        }
    }

    public class Vertex
    {
        public int NO;
        public string name;
        public double cx;
        public double cy;
        public Arcs first;                   //第一条以该点为尾的弧
                                             //       public bool visited;                 //顶点是否访问过
        public int radius;
        //        public int indegree;                 //顶点入度
        //        public int outdegree;                //顶点出度
        //        public int ve;                       //顶点事件发生的最早时间
        //        public int vl;                       //顶点事件发生的最晚时间
        public Vertex next_adjcent;
        public PictureBox paper;

        public Vertex(float xx, float yy, int r, int no)
        {
            cx = xx;
            cy = yy;
            radius = r;
            NO = no - 1;
            name = "v" + NO.ToString();
        }

        public void draw(Color color)
        {
            Graphics g = paper.CreateGraphics();
            Pen p = new Pen(Color.White);
            g.DrawEllipse(p, (float)(cx - radius), (float)(cy - radius), (float)(2 * radius), (float)(2 * radius));
            SolidBrush myBrush = new SolidBrush(color);
            g.FillEllipse(myBrush, (float)(cx - radius), (float)(cy - radius), (float)(2 * radius), (float)(2 * radius));
            Font font = new Font("宋体", 9f);
            if (color == paper.BackColor)
                g.DrawString(name, font, Brushes.White, (float)cx, (float)cy);
            else
                g.DrawString(name, font, Brushes.White, (float)cx - 7, (float)cy - 5);
        }
    }

    public class Arcs
    {
        public int NO;
        public int weight;
        public Vertex start;
        public Vertex end;
        public string name;
        public bool used;
        public Arcs next_arcs;
        public PictureBox paper;
        //        public int ee;                    //弧事件发生的最早时间
        //        public int el;                    //弧事件发生的最晚时间


        public Arcs(int no, string Name, Vertex startPoint, Vertex endPoint)
        {
            NO = no;
            name = "e" + no.ToString();
            start = startPoint;
            end = endPoint;
            //weight = (int)System.Math.Sqrt(System.Math.Pow((endPoint.cx - startPoint.cx), 2.0) + System.Math.Pow((endPoint.cy - startPoint.cy), 2.0));

        }
        public void draw(Color color)
        {
            Pen p = new Pen(color, 3);
            // if (color != Color.Black)
            //     p.EndCap = LineCap.ArrowAnchor;
            Graphics g = paper.CreateGraphics();

            double x1, y1, x2, y2, x0, y0;
            double a, b, c;
            double k;
            k = (end.cy - start.cy) / (end.cx - start.cx);
            a = ((end.radius + 2) * (end.radius + 2) * (end.cx - start.cx) * (end.cx - start.cx));
            b = ((end.cy - start.cy) * (end.cy - start.cy) + (end.cx - start.cx) * (end.cx - start.cx));
            c = a / b;
            x1 = end.cx + Math.Sqrt(c);
            x2 = end.cx - Math.Sqrt(c);
            y1 = k * (x1 - end.cx) + end.cy;
            y2 = k * (x2 - end.cx) + end.cy;

            if ((start.cx - x1) * (start.cx - x1) + (start.cy - y1) * (start.cy - y1) <= (start.cx - x2) * (start.cx - x2) + (start.cy - y2) * (start.cy - y2))
            {
                x0 = x1;
                y0 = y1;
            }
            else
            {
                x0 = x2;
                y0 = y2;
            }
            Font font = new Font("宋体", 9f);
            g.DrawLine(p, (float)start.cx, (float)start.cy, (float)x0, (float)y0);
            if (color == paper.BackColor)
                g.DrawString(name + ":" + weight.ToString(), font, Brushes.White, (float)(start.cx + x0) / 2, (float)(start.cy + y0) / 2);
            else
                g.DrawString(name, font, Brushes.Black, (float)(start.cx + x0) / 2, (float)(start.cy + y0) / 2);
        }
    }

    public class LinkVertex
    {
        public Vertex start;
        public PictureBox paper;
        //        public Bitmap theimage;
        public LinkVertex()
        {
            start = null;
        }
        public void insert(Vertex n)
        {
            Vertex pre;
            Vertex cur;
            pre = cur = start;
            while (start != null && cur != null && n.NO > cur.NO)
            {
                pre = cur;
                cur = cur.next_adjcent;
            }
            if (start == null)
            {
                n.next_adjcent = start;
                start = n;
            }
            else
            {
                pre.next_adjcent = n;
                n.next_adjcent = cur;
            }
        }
        public int length()
        {
            int num = 0;
            for (Vertex n = start; n != null; n = n.next_adjcent)
                num++;
            return num;
        }
        public Vertex search(int x, int y, int len)
        {
            Vertex n = start;
            Vertex cur = null;
            if (start != null)
            {
                for (int i = 0; i < len; i++)
                {
                    if ((n.cx - x) * (n.cx - x) + (n.cy - y) * (n.cy - y) <= n.radius * n.radius)
                    {
                        cur = n;
                    }
                    n = n.next_adjcent;
                }
            }
            return cur;
        }
        public void clear()
        {
            start = null;
        }
    }

    class Statistic
    {
        public static Arcs[] arcnode = new Arcs[100];
        public static LinkVertex list = new LinkVertex();
        public static Graph graph;
        public static int[,] AdjMatrix = new int[100, 100];
        public static double[,] Sim = new double[100, 100];
    }

}