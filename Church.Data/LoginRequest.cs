namespace Church.Data
{
    /// <summary>
    /// The data received for a login request.
    /// </summary>
    public sealed class LoginRequest
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
    }
}
