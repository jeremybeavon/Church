using System;
using Church.Common.Collections;

namespace Church.Common.Internal
{
    /// <summary>
    /// Provides methods for retrieving task schedulers.
    /// </summary>
    /// <seealso cref="ITaskScheduler"/>
    public sealed class TaskSchedulerProvider : ITaskSchedulerProvider
    {
        /// <summary>
        /// The task schedulers.
        /// </summary>
        private readonly IExtendedDictionary<string, ITaskScheduler> taskSchedulers;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskSchedulerProvider"/> class.
        /// </summary>
        public TaskSchedulerProvider()
        {
            this.taskSchedulers = new ExtendedDictionary<string, ITaskScheduler>();
        }

        /// <summary>
        /// Retrieves the task scheduler for the specified name.
        /// </summary>
        /// <param name="name">The name of the task scheduler.</param>
        /// <returns>The task scheduler for the specified name.</returns>
        public ITaskScheduler GetTaskScheduler(string name)
        {
            return this.taskSchedulers.GetOrAdd(name, () => new TaskScheduler());
        }

        /// <summary>
        /// Retrieves the task scheduler for the specified name.
        /// </summary>
        /// <param name="name">The name of the task scheduler.</param>
        /// <returns>The task scheduler for the specified name.</returns>
        public ITaskScheduler GetTaskScheduler(Enum name)
        {
            return this.GetTaskScheduler(name.ToString());
        }
    }
}
