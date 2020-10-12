using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace Demo
{
    class Program
    {
    	public static int Fib(int i) { 
   			if(i<=2) return 1;
   			return Fib(i-2) + Fib(i-1);
		}

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Stopwatch stopwatch = new Stopwatch();
            IList<Task<int>> tasks = new List<Task<int>>();
            //for (int i = 0; i < args.Length; i++) {
            stopwatch.Start();
            var parallelOptions = new ParallelOptions(); 
            var results = new ConcurrentBag<int>();
            Parallel.ForEach(args, parallelOptions, (arg) =>
            {
                var result = Fib(int.Parse(arg));
                results.Add(result);
            });

            foreach (var res in results)
            {
                Console.WriteLine($"result : {res}");
            }
            
            /*foreach (var str in args)
            {
                var task = Task<int>.Run(() => Fib((System.Int32.Parse(str))));
                tasks.Add(task);
            }*/
            
            Task.WaitAll(tasks.ToArray());
            stopwatch.Stop();
            /*foreach (var t in tasks)
            {
                Console.WriteLine($"result : {t.Result}");
            }*/
            
            TimeSpan stopwatchElapsed = stopwatch.Elapsed; 
            Console.WriteLine(Convert.ToInt32(stopwatchElapsed.TotalSeconds));
        }
    }
}
