using System;

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
