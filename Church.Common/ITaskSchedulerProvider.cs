using System;

namespace Church.Common
{
    /// <summary>
    /// Provides methods for retrieving task schedulers.
    /// </summary>
    /// <seealso cref="ITaskScheduler"/>
    public interface ITaskSchedulerProvider
    {
        /// <summary>
        /// Retrieves the task scheduler for the specified name.
        /// </summary>
        /// <param name="name">The name of the task scheduler.</param>
        /// <returns>The task scheduler for the specified name.</returns>
        ITaskScheduler GetTaskScheduler(string name);

        /// <summary>
        /// Retrieves the task scheduler for the specified name.
        /// </summary>
        /// <param name="name">The name of the task scheduler.</param>
        /// <returns>The task scheduler for the specified name.</returns>
        ITaskScheduler GetTaskScheduler(Enum name);
    }
}
