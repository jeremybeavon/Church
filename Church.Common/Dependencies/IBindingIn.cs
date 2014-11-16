namespace Church.Common.Dependencies
{
    /// <summary>
    /// Provides methods to specify the scope of a binding.
    /// </summary>
    public interface IBindingIn
    {
        /// <summary>
        /// Specifies that a binding type is only created once.
        /// </summary>
        void InSingletonScope();

        /// <summary>
        /// Specifies that a binding type is created every time it is requested.
        /// </summary>
        void InTransientScope();
    }
}
