using System;
using System.Threading.Tasks;

namespace Church.Common.Internal
{
    /// <summary>
    /// Provides a task scheduler for exclusively scheduling tasks.
    /// </summary>
    public sealed class TaskScheduler : ITaskScheduler
    {
        /// <summary>
        /// A <see cref="System.Threading.Tasks.TaskScheduler"/> that can be used to schedule
        /// tasks to this scheduler that must run exclusively with regards to other tasks
        /// on this scheduler.
        /// </summary>
        private readonly TaskFactory exclusiveTaskFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskScheduler"/> class.
        /// </summary>
        public TaskScheduler()
        {
            this.exclusiveTaskFactory = new TaskFactory(new ConcurrentExclusiveSchedulerPair().ExclusiveScheduler);
        }

        /// <summary>
        /// Runs the specified task that must run exclusively with regards to other tasks
        /// on this scheduler.
        /// </summary>
        /// <param name="task">The task to run.</param>
        /// <returns>A task that represents running the specified task.</returns>
        public async Task RunExclusiveTask(Func<Task> task)
        {
            Task<Task> newTask = this.exclusiveTaskFactory.StartNew(task);
            await await newTask;
        }

        /// <summary>
        /// Runs the specified task that must run exclusively with regards to other tasks
        /// on this scheduler.
        /// </summary>
        /// <typeparam name="TResult">The result type of the task.</typeparam>
        /// <param name="task">The task to run.</param>
        /// <returns>A task that represents running the specified task.</returns>
        public async Task<TResult> RunExclusiveTask<TResult>(Func<Task<TResult>> task)
        {
            Task<Task<TResult>> newTask = this.exclusiveTaskFactory.StartNew(task);
            return await await newTask;
        }
    }
}
