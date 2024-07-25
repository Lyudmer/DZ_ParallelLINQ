using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DZ_ParallelLINQ.TestSum
{
    public class SumArrayParallelLINQ
    {
        public static long RunSum(int[] array)
        {
            long res = 0;
           
            try
            {
                int chunkSize = array.Length /10;
                for (int i = 0; i <9; i++)
                {
                    long sum1 = 0;
                    int startIndex = i * chunkSize;
                    sum1 = array.AsParallel().Skip(startIndex).Take(chunkSize).Sum();
                    res += sum1;
                }
                //res = array.AsParallel().Sum();
                // Parallel.ForEach(array, x => Interlocked.Add(ref res, x));
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return res;
        }
    }

}
