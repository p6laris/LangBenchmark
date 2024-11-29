using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace LangBenchmarks
{
    public class CsharpBenchmarks
    {
        private static readonly Random Random = new Random();

        [Benchmark]
        public int Loop()
        {
            int u = int.Parse("40");
            int r = Random.Next(0,10_000);

            Span<int> a = stackalloc int[10_000];

            for (int i = 0; i < 10_000; i++)
            {
                for (int j = 0; j < 100_000; j++)
                {
                    a[i] += j % u;
                }
                a[i] += r;
            }

            return a[r];
        }
    }
}
