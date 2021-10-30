namespace Suwahasa.Common.Utilities
{
    public static class SecurityUtils
    {
        /// <summary>
        /// Gets the hashed password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static string GetHashedPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Verifies the password.
        /// </summary>
        /// <param name="passwordText">The password text.</param>
        /// <param name="passwordHashed">The password hashed.</param>
        /// <returns></returns>
        public static bool VerifyPassword(string passwordText, string passwordHashed)
        {
            return BCrypt.Net.BCrypt.Verify(passwordText, passwordHashed);
        }
    }
}
