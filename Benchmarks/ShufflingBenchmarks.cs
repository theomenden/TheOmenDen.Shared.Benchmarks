using BenchmarkDotNet.Attributes;
using TheOmenDen.Shared.Extensions;
namespace TheOmenDen.Shared.Benchmarks.Benchmarks;
[MemoryDiagnoser]
[ThreadingDiagnoser]
public class ShufflingBenchmarks
{
    private readonly List<int> _smallestData = new (10);
    private readonly List<int> _smallData = new (100);
    private readonly List<int> _mediumData = new (1000);
    private readonly List<int> _largeData = new (1000000);
    
    [GlobalSetup]
    public void GlobalSetup()
    {
        for (var i = 0; i < 10; i++)
        {
            var words = new Bogus.Randomizer().Int();

            _smallestData.Add(words);
        }

        for (var i = 0; i < 100; i++)
        {
            var words = new Bogus.Randomizer().Int();

            _smallData.Add(words);
        }

        for (var i = 0; i < 1000; i++)
        {
            var words = new Bogus.Randomizer().Int();

            _mediumData.Add(words);
        }
        for (var i = 0; i < 1000000; i++)
        {
            var words = new Bogus.Randomizer().Int();

            _largeData.Add(words);
        }
    }

    [Benchmark]
    public Int32 GetRandomElementFromSmallestDataSet() => _smallestData.GetRandomElement();

    [Benchmark]
    public Int32 GetRandomElementFromSmallDataSet() => _smallData.GetRandomElement();

    [Benchmark]
    public Int32 GetRandomElementFromMediumDataSet() => _mediumData.GetRandomElement();

    [Benchmark]
    public Int32 GetRandomElementFromLargeDataSet() => _largeData.GetRandomElement();
    
    [Benchmark]
    public List<Int32> GetRandomElementsFromSmallestDataSet() => _smallestData.GetRandomElements(5).ToList();

    [Benchmark]
    public List<Int32> GetRandomElementsFromSmallDataSet() => _smallData.GetRandomElements(5).ToList();

    [Benchmark]
    public List<Int32> GetRandomElementsFromMediumDataSet() => _mediumData.GetRandomElements(5).ToList();

    [Benchmark]
    public List<Int32> GetRandomElementsFromLargeDataSet() => _largeData.GetRandomElements(5).ToList();

    [GlobalCleanup]
    public void Cleanup()
    {
        _smallestData.Clear();
        _smallData.Clear();
        _mediumData.Clear();
        _largeData.Clear();
    }
}
