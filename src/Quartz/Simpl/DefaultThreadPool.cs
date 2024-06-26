namespace Quartz.Simpl;

/// <summary>
/// An implementation of the TaskSchedulerThreadPool using the default task scheduler
/// </summary>
public sealed class DefaultThreadPool : TaskSchedulingThreadPool
{
    /// <summary>
    /// Returns TaskScheduler.Default
    /// </summary>
    /// <returns>TaskScheduler.Default</returns>
    protected override TaskScheduler GetDefaultScheduler() => TaskScheduler.Default;
}