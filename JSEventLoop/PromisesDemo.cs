using System;

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

                myFirstPromise
                    .then((successMessage) => {
                        Console.WriteLine("Yay! " + successMessage);
                    })
                    .then((successMessage) => {
                        Console.WriteLine("More!");
                    })
                    ;

                Console.WriteLine("End of block");
            });
        }
    }
}
