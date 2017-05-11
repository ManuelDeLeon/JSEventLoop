using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSEventLoop
{
    static class PromisesDemo
    {
        public static void Start()
        {
            Engine.run(() =>
            {
                Console.WriteLine("Start of block");

                var myFirstPromise = new Promise<string>((resolve) => {
                    Engine.setTimeout(() => {
                        resolve("Success!");
                    }, 1000);
                });

                myFirstPromise.then((successMessage) => {
                    Console.WriteLine("Yay! " + successMessage);
                });

                Console.WriteLine("End of block");
            });
        }
    }
}
