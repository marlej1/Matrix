using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Start();
            Console.ReadKey();
			Console.ReadKey();
Console.ReadKey();
			
        }

        public static List<char> CreateRandomList()
        {

            Random rand = new Random();
            List<char> list = new List<char>();
            int length = rand.Next(10);
            for (int i = 0; i < length; i++)
            {
                list.Add((char)rand.Next(33, 127));
            }
            return list;
        }
        public static void Start()
        {

            Random rand = new Random();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Task.Factory.StartNew(() => WriteAtColumn(rand.Next(Console.WindowWidth)));
                Thread.Sleep(500);
            }
        }

        private static void WriteAtColumn(int col)
        {
            List<char> list = CreateRandomList();

            int row = 0;
            for (int i = 0; i < list.Count; i++)
            {
                Console.SetCursorPosition(col, row);
                Console.Write(list[i]);
                row++;
                Thread.Sleep(800);
            }
            while (row<Console.WindowHeight-(list.Count+1))
            {
                
                for (int i = 0; i < list.Count; i++)
                {
                    row = row - list.Count;
                    Console.SetCursorPosition(col, row);
                    Console.Write(" ");
                    row = row + list.Count+1;
                    Console.SetCursorPosition(col, row);
                    Console.Write(list[i]);
                    Thread.Sleep(300);

                }
                                             
            }

            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.SetCursorPosition(col, Console.WindowHeight + list.Count);
            //    Console.Write(" ");
            //}
        }
    }
}
