
using DZ_ParallelLINQ.TestSum;
using System.Diagnostics;
Console.WriteLine("Результат");
for (int i = 100000; i <= 10000000; i*=10)
{
    int threadCount = Environment.ProcessorCount;
    Console.WriteLine($"Процессор {threadCount} ");
    int[] array = Enumerable.Range(1, i).ToArray();
    Console.WriteLine($"Размер массива {array.Length}");
    RunTest(array);
}
static void RunTest(int[] array)
{
    Stopwatch stopwatch = new();
    stopwatch.Start();
    long sum1 = SumArray.RunSum(array);

    stopwatch.Stop();
    long time1 = stopwatch.ElapsedTicks;
    long time11 = stopwatch.ElapsedMilliseconds;
    Console.WriteLine($"Обычный: {time1} ticks, {time11} mc");

    for (int i = 2; i < 9; i += 2)
    {
        if (i == 6) continue;
        stopwatch.Restart();
        long sum2 = SumArrayThread.RunSum(array, i);
        stopwatch.Stop();
        long time2 = stopwatch.ElapsedTicks;
        long time21 = stopwatch.ElapsedMilliseconds;
        Console.WriteLine($"Параллельный Thread потоков {i}:{time2} ticks, {time21} mc");
    }

    stopwatch.Restart();
    long sum3 = SumArrayParallelLINQ.RunSum(array);
    stopwatch.Stop();
    long time3 = stopwatch.ElapsedTicks;
    long time31 = stopwatch.ElapsedMilliseconds;
    Console.WriteLine($"Параллельный LINQ : {time3} ticks, {time31} mc");

}