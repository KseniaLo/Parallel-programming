using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace Lab_3_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread t1, t2;
        public static bool fin = false;
        public static Queue<int> list = new Queue<int>();
        public static int full = 0;

        // Find all palindrom primes.
        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text); // The right-hand end of the search term.

            // We will simplify the problem starting with searching of primes.
            // Then we will check the found prime numbers on the palindrome.
            t1 = new Thread(SearchOfPrimes);
            t2 = new Thread(SearchOfPalindrome);

            t1.Start(n);
            t2.Start(richTextBox1);
        }

        static void SearchOfPrimes(Object x)
        {
            int n = (int)x;
            fin = false;
            bool[] flags = new bool[n];

            for (int i = 0; i < flags.Length; i++)
                flags[i] = true;

            for (int i = 2; i < flags.Length; i++)
            {
                // According to the task we limit
                // the ammount of places in queue with 3.
                if (flags[i] == true)
                {
                    // Wait until there is a space in the queue.
                    while (full == 3) { };
                    lock (list)
                    {
                        // Put the found element to the queue.
                        list.Enqueue(i);
                        full++;
                    }
                    for (int j = 2 * i; j < flags.Length; j += i)// For all values ​​that are a multiple of i.
                        flags[j] = false;
                }
            }
            // The flag showing the end of the ammount of elements.
            fin = true;
        }
        
        static void SearchOfPalindrome(Object x)
        {
            string tmp;
            RichTextBox richTextBox = (RichTextBox)x;
            richTextBox.Clear();

            // Wait until there is smth in the queue.
            while (full==0) { };
            while (list.Count != 0)
            {
                lock (list)
                {
                    tmp = list.Dequeue().ToString();
                    full--;
                }

                // Check on being a palindrome.
                bool flag = true;
                for (int i = 0; i < tmp.Length / 2; i++)
                    if (tmp[i] != tmp[tmp.Length - i - 1])
                    {
                        flag = false;
                        break;
                    }

                if (flag)
                    richTextBox.AppendText(tmp + "\n");

                // If there are items to check but they are not in the queue. 
                while (full == 0&&!fin) { };
            }
        }
    }
}