using System;
using System.Text;
using System.Windows.Forms;

namespace yftest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region List<T> where 测试
            //string str = "Test";
            //List<string> list = new List<string>();
            //list.Add(str);
            //list = list.Where(t => t.ToString() == "Test").ToList();
            //txt.Text = list.Count.ToString();
            #endregion


            #region 委托

            //A a = new A();//定义首领A
            //B b = new B(a);
            //a.Raise("左");
            //a.Fall();

            #endregion

            #region 字符转码

            //byte[] byt = Encoding.Default.GetBytes(txt.Text);
            //byt = Encoding.Convert(Encoding.Default, Encoding.UTF8, byt);
            //txt.Text = Encoding.UTF8.GetString(byt);
            #endregion

            #region 泛型

            Stack<string> a = new Stack<string>(100);
            a.Push("A");
            string x = a.Pop();

            Stack<int> b = new Stack<int>(10);
            b.Push(10);
            int y = b.Pop();
            Stack2 x2 = new Stack2();
            x2.Push(b, 1, 2, 3, 4, 5);

            //Node<string, int> node = new Node<string, int>();

            //node.Add(2, "11");
            #endregion
        }
    }

    #region 委托
    public delegate void RaiseEventHandler(string hand);
    public delegate void FallEventHandler();
    /// <summary>
    /// 首领A
    /// </summary>
    public class A
    {
        /// <summary>
        /// 举杯
        /// </summary>
        /// <param name="hand"></param>
        public void Raise(string hand)
        {
            Console.WriteLine("首领A{0}手举杯", hand);
            RaiseEvent?.Invoke(hand);
        }
        /// <summary>
        /// 摔杯
        /// </summary>
        public void Fall()
        {
            Console.WriteLine("首领摔杯");
            FallEvent?.Invoke();
        }
        /// <summary>
        /// 首领A举杯事件
        /// </summary>
        public event RaiseEventHandler RaiseEvent;
        /// <summary>
        /// 首领A摔杯事件
        /// </summary>
        public event FallEventHandler FallEvent;
    }
    /// <summary>
    /// 部下B
    /// </summary>
    public class B
    {
        A a;
        /// <summary>
        /// 攻击
        /// </summary>
        public void Attack()
        {
            Console.WriteLine("部下B发起攻击");
        }
        public B(A a)
        {
            this.a = a;
            a.RaiseEvent += new RaiseEventHandler(a_RaiseEvent);
            a.FallEvent += new FallEventHandler(a_FallEvent);
        }
        /// <summary>
        /// 首领举杯时的动作
        /// </summary>
        /// <param name="hand"></param>
        void a_RaiseEvent(string hand)
        {
            if (hand.Equals("左"))
            {
                Attack();
            }
        }
        /// <summary>
        /// 首领摔杯时的动作
        /// </summary>
        void a_FallEvent()
        {
            Attack();
        }
    }

    public class C
    {
        public void Attack()
        {
            Console.WriteLine("部下C发起攻击");
        }
    }
    #endregion

    #region 泛型
    public class Stack<T>
    {
        private T[] item = default(T[]);//默认值

        public T Pop()
        {
            return item[0];
        }

        public void Push(T item)
        {

        }

        public Stack(int i)
        {
            item = new T[i];
        }
    }

    public class Stack2
    {
        public void Push<T>(Stack<T> s, params T[] p)
        {
            foreach (T item in p)
            {
                s.Push(item);
            }
        }
    }

    public class Node<T, V>
    {
        public T Add(T a, V b)
        {
            return a;
        }
        public T Add(V a, T b)
        {
            return b;
        }

        //public int Add(int a, int b)
        //{
        //    return a + b;
        //}
    }

    #endregion


}