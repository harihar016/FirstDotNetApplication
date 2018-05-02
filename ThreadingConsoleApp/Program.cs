using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Cell cell = new Cell();
            ProductionClass prd = new ProductionClass(cell, 20);
            ConsumerClass cons = new ConsumerClass(cell, 20);

           
            Join2Threads thread = new Join2Threads();
            try
            {
                Thread prodThread = new Thread(new ThreadStart(prd.ThreadRun));
                Thread consThread = new Thread(new ThreadStart(cons.ThreadRun));

                prodThread.Start();
                consThread.Start();

                prodThread.Join();
                consThread.Join();
                Console.WriteLine("Thread 123 123 sdfsdfsdf");
                //Thread prodThread = new Thread(new ThreadStart(thread.getOddNumbers));
                //Thread consThread = new Thread(new ThreadStart(thread.getEvenNumbers));

                //prodThread.Start();
                //consThread.Start();

                //prodThread.Join();
                //consThread.Join();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.Read();
        }
    }

    public class Cell
    {
        public int cellContents;
        bool flag = false;
        public int ReadFromCell()
        {
            lock (this)
            {
                if (!flag)
                {
                    try
                    {
                        Monitor.Wait(this);
                    }
                    catch(ThreadStateException ex)
                    {
                    }
                }
                Console.WriteLine("Consume : {0}", cellContents);
                flag = false;
                Monitor.Pulse(this);
            }
            return cellContents;
        }

        public void WriteToCell(int cellContents)
        {
            lock (this)
            {
                if (flag)
                {
                    try
                    {
                        Monitor.Wait(this);
                    }
                    catch (ThreadStateException ex)
                    {
                    }
                }
                Console.WriteLine("Production : {0}", cellContents);
                flag = true;
                Monitor.Pulse(this);
            }
        }
    }

    public class ProductionClass
    {
        int loopContents;
        Cell cell;
        public ProductionClass(Cell cell, int loopContents)
        {
            this.cell = cell;
            this.loopContents = loopContents;
        }
        public void ThreadRun()
        {
            for (int i = 0; i < loopContents; i++)
            {
                cell.WriteToCell(i);
            }
        }
    }

    public class ConsumerClass
    {
        Cell cell;
        int loopContents;
        public ConsumerClass(Cell cell, int loopContents)
        {
            this.cell = cell;
            this.loopContents = loopContents;
        }

        public void ThreadRun()
        {
            int valueReturned;
            for (int i = 0; i < loopContents; i++)
            {
                cell.cellContents = i;
                valueReturned = cell.ReadFromCell();
            }
        }
    }

    public class Join2Threads
    {
        public int[] OddArray = new int[] { 1, 3, 5, 7, 9 };
        public int[] EvenArray = new int[] { 2, 4, 6, 8, 10 };
        public List<int> JoinedArray = new List<int>();
        bool flag = false;
        public Join2Threads()
        {
        }
        public void getOddNumbers()
        {
            for (int i = 0; i < OddArray.Length; i++)
            {
                this.JoinNumbers(OddArray[i]);
            }
        }

        public void getEvenNumbers()
        {
            for (int i = 0; i < EvenArray.Length; i++)
            {
                this.JoinEvenNumbers(EvenArray[i]);
            }
        }

        public void JoinNumbers(int i)
        {
            lock (this)
            {
                if (flag)
                {
                    Monitor.Wait(this);
                }
                JoinedArray.Add(i);
                Console.WriteLine(i);
                flag = true;
                Monitor.Pulse(this);
            }
        }

        public void JoinEvenNumbers(int j)
        {
            lock (this)
            {
                if (!flag)
                {
                    Monitor.Wait(this);
                }
                JoinedArray.Add(j);
                Console.WriteLine(j);
                flag = false;
                Monitor.Pulse(this);
            }
        }
    }

    public class GenericClass
    {
        public T Add<T>(T x, T y)
        {
            var s = x + y;
            return x + y;
        }
    }
}
