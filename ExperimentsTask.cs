using System.Collections.Generic;
using System.Diagnostics;

namespace StructBenchmarking;

public class Experiments
{
	public static ChartData BuildChartDataForArrayCreation(
		IBenchmark benchmark, int repetitionsCount)
	{
		var classesTimes = new List<ExperimentResult>();
		var structuresTimes = new List<ExperimentResult>();
		var bench = benchmark;

        foreach(var size in Constants.FieldCounts)
		{
			StructArrayCreationTask structTask = new(size);
			ClassArrayCreationTask classTask = new(size);
			classesTimes.Add(new ExperimentResult(size, bench.MeasureDurationInMs(classTask, repetitionsCount)));
			structuresTimes.Add(new ExperimentResult(size, bench.MeasureDurationInMs(structTask, repetitionsCount)));
		}

		return new ChartData
		{
			Title = "Create array",
			ClassPoints = classesTimes,
			StructPoints = structuresTimes,
		};
	}

	public static ChartData BuildChartDataForMethodCall(
		IBenchmark benchmark, int repetitionsCount)
	{
		var classesTimes = new List<ExperimentResult>();
		var structuresTimes = new List<ExperimentResult>();
        var bench = benchmark;

        foreach (var size in Constants.FieldCounts)
        {
            MethodCallWithStructArgumentTask structTask = new(size);
            MethodCallWithStructArgumentTask classTask = new(size);
            classesTimes.Add(new ExperimentResult(size, bench.MeasureDurationInMs(classTask, repetitionsCount)));
            structuresTimes.Add(new ExperimentResult(size, bench.MeasureDurationInMs(structTask, repetitionsCount)));
        }


        return new ChartData
		{
			Title = "Call method with argument",
			ClassPoints = classesTimes,
			StructPoints = structuresTimes,
		};
	}
}