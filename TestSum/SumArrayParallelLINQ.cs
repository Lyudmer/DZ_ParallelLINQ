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
        public static int RunSum(int[] array)
        {
            int res = 0;
            Parallel.ForEach(array, x => Interlocked.Add(ref res, x));
            return res;
        }
    }

}
