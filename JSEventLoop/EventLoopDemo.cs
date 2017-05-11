using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSEventLoop
{
    static class EventLoopDemo
    {
        public static void Start()
        {
            Engine.run(() =>
            {
                Console.WriteLine("Hello World");

                Engine.setTimeout(() => {
                    Console.WriteLine("Ran after 2 secs.");
                }, 2000);

                for (var num = 1; num <= 5; num++)
                {
                    Engine.setTimeout(() => {
                        Console.WriteLine(num);
                    }, 0);
                }

                Engine.setImmediate(() => {
                    Console.WriteLine("Run this ASAP");
                });

                Console.WriteLine("Hello World AGAIN");
            });
        }
    }
}
