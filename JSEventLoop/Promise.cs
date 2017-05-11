using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSEventLoop
{
    class Promise<T>
    {
        private List<Action<T>> thenList = new List<Action<T>>();
        public Promise(Action<Action<T>> action)
        {
            Engine.setImmediate(() =>
            {
                action((result) => {
                    this.resolve(result);
                });
            });
        }

        public Promise<T> then(Action<T> action)
        {
            thenList.Add(action);
            return this;
        }

        public void resolve(T result)
        {
            foreach(var then in thenList)
            {
                then(result);
            }
        }
    }
}
