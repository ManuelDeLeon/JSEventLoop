using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSEventLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLoopDemo.Start();
            //CallBackDemo.Start();
            //PromisesDemo.Start();

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }
}
