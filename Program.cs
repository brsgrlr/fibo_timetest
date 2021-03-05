using System;
using System.Diagnostics;

namespace timeTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var sw_fibA = new Stopwatch();
			var sw_fibV = new Stopwatch();
			int n = 92; // max 92
			int iterations = 20_000_000;
			int p1 = iterations / 100;

			Console.WriteLine("Warmup...");
			for (int i = 0; i < 1_000_000; i++)
			{
				fibA(n);
				fibV(n);
			}
			Console.WriteLine("Warmup Completed");

			for (int i = 0; i < iterations; i++)
			{
				sw_fibA.Start();
				fibA(n);
				sw_fibA.Stop();

				sw_fibV.Start();
				fibV(n);
				sw_fibV.Stop();

				if (i % p1 == 0)
				{
					Console.Clear();
					Console.WriteLine("Testing...");
					Console.WriteLine((i / (double)iterations).ToString("p0"));
				}
			}

			Console.Clear();
			Console.WriteLine("Testing Completed");
			Console.WriteLine("# of iterations: " + iterations.ToString("n0"));
			Console.WriteLine("----------------------------");

			Console.WriteLine("Total");
			Console.WriteLine($"fibA: {sw_fibA.Elapsed.TotalMilliseconds} ms");
			Console.WriteLine($"fibV: {sw_fibV.Elapsed.TotalMilliseconds} ms");

			Console.WriteLine("----------------------------");
			Console.WriteLine("Mean");
			Console.WriteLine($"fibA: {sw_fibA.Elapsed.TotalMilliseconds / iterations * 10e6} ns");
			Console.WriteLine($"fibV: {sw_fibV.Elapsed.TotalMilliseconds / iterations * 10e6} ns");

			Console.ReadKey();
		}

		// fibonacci - using array
		static long fibA(int n)
		{
			long[] f = new long[n + 1];
			f[0] = 0;
			f[1] = 1;
			for (int i = 2; i <= n; i++)
			{
				f[i] = f[i - 1] + f[i - 2];
			}
			return f[n];
		}

		// fibonacci - using variables
		static long fibV(int n)
		{
			long f1 = 0;
			long f2 = 1;
			long f = 1;
			for (int i = 2; i <= n; i++)
			{
				f = f1 + f2;
				f1 = f2;
				f2 = f;
			}
			return f;
		}

	}
}