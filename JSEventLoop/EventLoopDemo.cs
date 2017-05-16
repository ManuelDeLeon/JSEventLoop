using System;
using System.Threading;

namespace JSEventLoop
{
    static class EventLoopDemo
    {
        public static void Start()
        {
            Engine.run(() =>
            {
                Console.WriteLine("Hello World");

                var start = DateTime.Now;
                Engine.setTimeout(() => {
                    var secs = (DateTime.Now - start).TotalSeconds;
                    Console.WriteLine("Ran after {0} secs.", secs);
                }, 1000);

                for (var num = 1; num <= 5; num++)
                {
                    var count = num;
                    Engine.setTimeout(() => {
                        Console.WriteLine(count);
                    }, 0);
                }

                Engine.setImmediate(() => {
                    Console.WriteLine("Taking some time to work.");
                    Thread.Sleep(2000);
                });

                Console.WriteLine("Hello World AGAIN");
            });
        }
    }
}
