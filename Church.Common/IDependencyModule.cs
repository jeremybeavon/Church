namespace Church.Common
{
    /// <summary>
    /// Represents a dependency module that can register dependencies.
    /// </summary>
    public interface IDependencyModule
    {
        /// <summary>
        /// Registers dependencies.
        /// </summary>
        /// <param name="dependencyManager">The dependency manager.</param>
        void Load(IDependencyManager dependencyManager);
    }
}
