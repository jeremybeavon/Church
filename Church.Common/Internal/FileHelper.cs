using System.IO;
using System.Threading.Tasks;

namespace Church.Common.Internal
{
    /// <summary>
    /// Provides methods to manage files.
    /// </summary>
    public sealed class FileHelper : IFileHelper
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
        public bool DoesFileExist(string fileName)
        {
            return File.Exists(fileName);
        }

        /// <summary>
        /// Writes the specified contents to the specified file asynchronously.
        /// </summary>
        /// <param name="fileName">The name of the file to write to.</param>
        /// <param name="contents">The text that will be written to the file.</param>
        /// <returns>A task that represents writing to the file.</returns>
        public async Task WriteAllTextAsync(string fileName, string contents)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            using (Stream stream = this.CreateAsyncStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (TextWriter writer = new StreamWriter(stream))
                {
                    await writer.WriteAsync(contents);
                }
            }
        }

        /// <summary>
        /// Reads all text from the specified file asynchronously.
        /// </summary>
        /// <param name="fileName">The name of the file to write to.</param>
        /// <returns>A task that represents reading from the file.</returns>
        public async Task<string> ReadAllTextAsync(string fileName)
        {
            using (Stream stream = this.CreateAsyncStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (TextReader reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        /// <summary>
        /// Creates a stream that supports asynchronous usage.
        /// </summary>
        /// <param name="fileName">The name of the file to create the stream for.</param>
        /// <param name="mode">A constant that determines how to open or create the file.</param>
        /// <param name="access">A constant that determines how the file can be accessed by the FileStream
        /// object.</param>
        /// <param name="share">A constant that determines how the file will be shared by processes.</param>
        /// <returns>A stream that can be used asynchronously.</returns>
        private Stream CreateAsyncStream(string fileName, FileMode mode, FileAccess access, FileShare share)
        {
            return new FileStream(fileName, mode, access, share, 4096, true);
        }
    }
}
