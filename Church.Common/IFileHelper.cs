using System.Threading.Tasks;

namespace Church.Common
{
    /// <summary>
    /// Provides methods to manage files.
    /// </summary>
    public interface IFileHelper
    {
        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        /// <param name="fileName">The file to check.</param>
        /// <returns>true if the caller has the required permissions and path contains the name
        /// of an existing file; otherwise, false. This method also returns false if
        /// path is null, an invalid path, or a zero-length string. If the caller does
        /// not have sufficient permissions to read the specified file, no exception
        /// is thrown and the method returns false regardless of the existence of path.</returns>
        bool DoesFileExist(string fileName);

        /// <summary>
        /// Writes the specified contents to the specified file asynchronously.
        /// </summary>
        /// <param name="fileName">The name of the file to write to.</param>
        /// <param name="contents">The text that will be written to the file.</param>
        /// <returns>A task that represents writing to the file.</returns>
        Task WriteAllTextAsync(string fileName, string contents);

        /// <summary>
        /// Reads all text from the specified file asynchronously.
        /// </summary>
        /// <param name="fileName">The name of the file to write to.</param>
        /// <returns>A task that represents reading from the file.</returns>
        Task<string> ReadAllTextAsync(string fileName);
    }
}
