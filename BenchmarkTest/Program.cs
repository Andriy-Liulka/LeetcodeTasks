
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace BenchmarkTest;
public class Program
{
	public static void Main(string[] args)
	{
		//BenchmarkRunner.Run<TwoSum>();
		BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
    }


}

