using System;
using System.Threading.Tasks;

namespace Church.Common
{
    /// <summary>
    /// Provides a task scheduler for exclusively scheduling tasks.
    /// </summary>
    public interface ITaskScheduler
    {
        /// <summary>
        /// Runs the specified task that must run exclusively with regards to other tasks
        /// on this scheduler.
        /// </summary>
        /// <param name="task">The task to run.</param>
        /// <returns>A task that represents running the specified task.</returns>
        Task RunExclusiveTask(Func<Task> task);

        /// <summary>
        /// Runs the specified task that must run exclusively with regards to other tasks
        /// on this scheduler.
        /// </summary>
        /// <typeparam name="TResult">The result type of the task.</typeparam>
        /// <param name="task">The task to run.</param>
        /// <returns>A task that represents running the specified task.</returns>
        Task<TResult> RunExclusiveTask<TResult>(Func<Task<TResult>> task);
    }
}
