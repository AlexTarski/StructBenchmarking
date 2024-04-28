using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace StructBenchmarking;
public class Benchmark : IBenchmark
{
    public double MeasureDurationInMs(ITask task, int repetitionCount)
    {
        GC.Collect();                   // Эти две строчки нужны, чтобы уменьшить вероятность того,
        GC.WaitForPendingFinalizers();  // что Garbadge Collector вызовется в середине измерений
                                        // и как-то повлияет на них.
        Stopwatch sw = new();
        task.Run();
        int counts = repetitionCount;
        sw.Reset();
        sw.Start();
        do
        {
            task.Run();
            counts--;
        } while (counts > 0);
        sw.Stop();
        return (double)sw.ElapsedMilliseconds / repetitionCount;
	}
}

public class SBuilder : ITask
{
    public void Run()
    {
        StringBuilder sb = new ();
        int counter = 10000;
        do
        {
            sb.Append('a');
            counter--;
        } while (counter > 0);

        sb.ToString();
    }
}

public class Sstring : ITask
{
    public void Run()
    {
        new string('a', 10000);
    }
}

[TestFixture]
public class RealBenchmarkUsageSample
{
    [Test]
    public void StringConstructorFasterThanStringBuilder()
    {
        var sb = new SBuilder();
        var s = new Sstring();
        var bench = new Benchmark();

        var testStringBuilder = bench.MeasureDurationInMs(sb, 10000);
        var testString = bench.MeasureDurationInMs(s, 10000);

        Assert.Less(testString, testStringBuilder);
    }
}