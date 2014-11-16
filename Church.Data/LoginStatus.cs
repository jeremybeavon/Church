namespace Church.Data
{
    /// <summary>
    /// The available login status values.
    /// </summary>
    public enum LoginStatus
    {
        /// <summary>
        /// Indicates there was an unspecified failure.
        /// </summary>
        UnknownFailure,

        /// <summary>
        /// Indicates the login was successful.
        /// </summary>
        Success,

        /// <summary>
        /// Indicates the user name or password was incorrect.
        /// </summary>
        IncorrectUserNameOrPassword
    }
}
