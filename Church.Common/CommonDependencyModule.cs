using Church.Common.Internal;

namespace Church.Common
{
    /// <summary>
    /// Provides a dependency module that registers all common dependencies.
    /// </summary>
    public sealed class CommonDependencyModule : IDependencyModule
    {
        /// <summary>
        /// Registers all common dependencies.
        /// </summary>
        /// <param name="dependencyManager">The dependency manager.</param>
        public void Load(IDependencyManager dependencyManager)
        {
            dependencyManager.Bind<IFileHelper>().To<FileHelper>().InSingletonScope();
            dependencyManager.Bind<IObjectSerializer>().To<NewtonsoftObjectSerializer>().InSingletonScope();
            dependencyManager.Bind<ITaskSchedulerProvider>().To<TaskSchedulerProvider>().InSingletonScope();
        }
    }
}
