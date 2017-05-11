using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSEventLoop
{
    static class CallBackDemo
    {
        public static void Start()
        {
            Engine.run(() =>
            {
                Console.WriteLine("Start of block");

                Action<Action<string>> getAsyncData = (Action<string> callback) => {
                    
                    // Simulate server taking 1 sec to return the data
                    Engine.setTimeout(() => { 
                        callback("It works!");
                    }, 1000);
                };

                Action<string> printResult = (result) =>
                {
                    Console.WriteLine(result);
                };

                getAsyncData(printResult);

                Console.WriteLine("End of block");
            });
        }
    }
}
