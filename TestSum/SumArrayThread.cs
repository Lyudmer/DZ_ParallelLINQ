using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_ParallelLINQ.TestSum
{
   public class SumArrayThread
   {
        public static int RunSum(int[] array,int threadCount)
        {
            int sum = 0;
            int chunkSize = array.Length / threadCount;

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < threadCount; i++)
            {
                int startIndex = i * chunkSize;
                int endIndex = Math.Min((i + 1) * chunkSize, array.Length);

                Thread thread = new(() =>
                {
                    int localSum = 0;
                    for (int j = startIndex; j < endIndex; j++)
                    {
                        localSum += array[j];
                    }

                    Interlocked.Add(ref sum, localSum);
                });

                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            return sum;
        }

    }
}
