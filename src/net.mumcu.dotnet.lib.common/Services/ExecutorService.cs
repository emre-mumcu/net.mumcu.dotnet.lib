namespace net.mumcu.dotnet.lib.common.Services;

public class ExecuterService
{
    /// <summary>
    /// Executes the give action and returns the time passed in milliseconds
    /// </summary>
    public long Executer(Action action)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        action.Invoke();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    /// <summary>
    /// Executes the give function and returns the data from function and the time passed in milliseconds
    /// </summary>
    public (T? Data, long Elapsed) Executer<T>(Func<T?> func)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        try
        {
            var result = func.Invoke();
            return (result, stopwatch.ElapsedMilliseconds);
        }
        finally
        {
            stopwatch.Stop();
        }
    }

    /// <summary>
    /// Executes the give function asyncronously and returns the data from function and the time passed in milliseconds
    /// </summary>
    public async Task<(T? Data, long Elapsed)> ExecuterAsync<T>(Func<Task<T?>> func)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        try
        {
            var result = await func();
            return (result, stopwatch.ElapsedMilliseconds);
        }
        finally
        {
            stopwatch.Stop();
        }
    }
}
