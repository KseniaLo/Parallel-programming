using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Lab_3_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Graphics gr1;
        Thread ph1, ph2, ph3, ph4, ph5;
        
        // Start dining.
        private void button1_Click(object sender, EventArgs e)
        {
            gr1 = pictureBox1.CreateGraphics();
            CreateTable();

            Philosophers phils = new Philosophers();
            ph1= new Thread(Phil1);
            ph2 = new Thread(Phil2);
            ph3 = new Thread(Phil3);
            ph4 = new Thread(Phil4);
            ph5 = new Thread(Phil5);

            ph1.Start(phils);
            ph2.Start(phils);
            ph3.Start(phils);
            ph4.Start(phils);
            ph5.Start(phils);
        }

        // Creating of the table and markers of philosophers.
        public void CreateTable()
        {
            gr1.FillEllipse(Brushes.White, pictureBox1.Width/2 - 125, pictureBox1.Height/2 - 125, 250, 250);
            gr1.FillEllipse(Brushes.Red, pictureBox1.Width / 2 - 25, pictureBox1.Height / 2 - 110, 50, 50);
            gr1.FillEllipse(Brushes.Red, pictureBox1.Width / 2 - 80, pictureBox1.Height / 2 + 40, 50, 50);
            gr1.FillEllipse(Brushes.Red, pictureBox1.Width / 2 - 100, pictureBox1.Height / 2 - 50, 50, 50);
            gr1.FillEllipse(Brushes.Red, pictureBox1.Width / 2 + 35, pictureBox1.Height / 2 + 40, 50, 50);
            gr1.FillEllipse(Brushes.Red, pictureBox1.Width / 2 + 55, pictureBox1.Height / 2 - 50, 50, 50);
        }

        // The behaviour of the first philosopher.
        public static void Phil1(Object x)
        {
            Philosophers phil = (Philosophers)x;
            Object thisLock = new Object();

            while(true)
            {
                // Wait until the right-hand side fork is available.
                while (phil.Forks[4]) ;

                // Take the fork.
                lock (thisLock)
                {
                    phil.Forks[4] = true;
                }

                // Wait until the left-hand side fork is available.
                while (phil.Forks[0]) ;

                lock (thisLock)
                {
                    phil.Forks[0] = true;
                }

                // Showing the eateng process with assigning a green color to the indicator.
                lock (gr1)
                    gr1.FillEllipse(Brushes.Green, phil.phil1.X, phil.phil1.Y, 50, 50);
                // Duration of eating process.
                Thread.Sleep(2000);

                // Leaving forks.
                lock(thisLock)
                {
                    phil.Forks[4] = false;
                    phil.Forks[0] = false;
                }

                // Showing the thinking process with assigning a yellow color to the indicator.
                lock (gr1)
                    gr1.FillEllipse(Brushes.Yellow, phil.phil1.X, phil.phil1.Y, 50, 50);
                // Duration of thinking process.
                Thread.Sleep(2000);

                // The philosopher is ready to wait for his turn again. Setting a red color to the indicator.
                lock (gr1)
                    gr1.FillEllipse(Brushes.Red, phil.phil1.X, phil.phil1.Y, 50, 50);
            }
        }

        // Behaviour of the rest is similar.

        public static void Phil2(Object x)
        {
            Philosophers phil = (Philosophers)x;
            Object thisLock = new Object();
            while (true)
            {
                while (phil.Forks[1]) ;
                lock (thisLock)
                {
                    phil.Forks[1] = true;
                }

                while (phil.Forks[0]) ;
                lock (thisLock)
                {
                    phil.Forks[0] = true;
                }

                lock (gr1)
                    gr1.FillEllipse(Brushes.Green, phil.phil2.X, phil.phil2.Y, 50, 50);
                Thread.Sleep(2000);

                lock (thisLock)
                {
                    phil.Forks[1] = false;
                }

                lock (thisLock)
                {
                    phil.Forks[0] = false;
                }

                lock (gr1)
                    gr1.FillEllipse(Brushes.Yellow, phil.phil2.X, phil.phil2.Y, 50, 50);
                Thread.Sleep(2000);

                lock (gr1)
                    gr1.FillEllipse(Brushes.Red, phil.phil2.X, phil.phil2.Y, 50, 50);
            }
        }

        public static void Phil3(Object x)
        {
            Philosophers phil = (Philosophers)x;
            Object thisLock = new Object();
            while (true)
            {
                while (phil.Forks[1]) ;
                lock (thisLock)
                {
                    phil.Forks[1] = true;
                }

                while (phil.Forks[2]) ;
                lock (thisLock)
                {
                    phil.Forks[2] = true;
                }

                lock (gr1)
                    gr1.FillEllipse(Brushes.Green, phil.phil3.X, phil.phil3.Y, 50, 50);
                Thread.Sleep(2000);

                lock (thisLock)
                {
                    phil.Forks[1] = false;
                }

                lock (thisLock)
                {
                    phil.Forks[2] = false;
                }

                lock (gr1)
                    gr1.FillEllipse(Brushes.Yellow, phil.phil3.X, phil.phil3.Y, 50, 50);
                Thread.Sleep(2000);

                lock (gr1)
                    gr1.FillEllipse(Brushes.Red, phil.phil3.X, phil.phil3.Y, 50, 50);
            }
        }

        public static void Phil4(Object x)
        {
            Philosophers phil = (Philosophers)x;
            Object thisLock = new Object();
            while (true)
            {
                while (phil.Forks[3]) ;
                lock (thisLock)
                {
                    phil.Forks[3] = true;
                }

                while (phil.Forks[2]) ;
                lock (thisLock)
                {
                    phil.Forks[2] = true;
                }

                lock (gr1)
                    gr1.FillEllipse(Brushes.Green, phil.phil4.X, phil.phil4.Y, 50, 50);
                Thread.Sleep(2000);

                lock (thisLock)
                {
                    phil.Forks[3] = false;
                }

                lock (thisLock)
                {
                    phil.Forks[2] = false;
                }

                lock (gr1)
                    gr1.FillEllipse(Brushes.Yellow, phil.phil4.X, phil.phil4.Y, 50, 50);
                Thread.Sleep(2000);

                lock (gr1)
                    gr1.FillEllipse(Brushes.Red, phil.phil4.X, phil.phil4.Y, 50, 50);
            }
        }

        public static void Phil5(Object x)
        {
            Philosophers phil = (Philosophers)x;
            Object thisLock = new Object();
            while (true)
            {
                while (phil.Forks[3]) ;
                lock (thisLock)
                {
                    phil.Forks[3] = true;
                }

                while (phil.Forks[4]) ;
                lock (thisLock)
                {
                    phil.Forks[4] = true;
                }

                lock (gr1)
                    gr1.FillEllipse(Brushes.Green, phil.phil5.X, phil.phil5.Y, 50, 50);
                Thread.Sleep(2000);

                lock (thisLock)
                {
                    phil.Forks[3] = false;
                }

                lock (thisLock)
                {
                    phil.Forks[4] = false;
                }

                lock (gr1)
                    gr1.FillEllipse(Brushes.Yellow, phil.phil5.X, phil.phil5.Y, 50, 50);
                Thread.Sleep(2000);

                lock (gr1)
                    gr1.FillEllipse(Brushes.Red, phil.phil5.X, phil.phil5.Y, 50, 50);
            }
        }

        // Stop dining.
        private void button2_Click(object sender, EventArgs e)
        {
            ph1.Abort();
            ph2.Abort();
            ph3.Abort();
            ph4.Abort();
            ph5.Abort();
        }
    }

    class Philosophers
    {
        public Point phil1 = new Point(406 / 2 - 25, 274 / 2 - 110);
        public Point phil2 = new Point(406 / 2 + 55, 274 / 2 - 50);
        public Point phil3 = new Point(406 / 2 + 35, 274 / 2 + 40);
        public Point phil4 = new Point(406 / 2 - 80, 274 / 2 + 40);
        public Point phil5 = new Point(406 / 2 - 100, 274 / 2 - 50);

        public bool[] Forks = new bool[5];
    }
}