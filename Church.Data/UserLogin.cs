namespace Church.Data
{
    /// <summary>
    /// Represents a current login for a user.
    /// </summary>
    public sealed class UserLogin
    {
        /// <summary>
        /// Gets or sets the login provider.
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// Gets or sets the provider key.
        /// </summary>
        public string ProviderKey { get; set; }
    }
}
