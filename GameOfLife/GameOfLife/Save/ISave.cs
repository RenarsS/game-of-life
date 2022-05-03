
using Newtonsoft.Json;

namespace GameOfLife
{
    /// <summary>
    /// Interface of the class that is responsible for saving and restoring games.
    /// </summary>
    /// <typeparam name="T">Parameter which is being retained or restored.</typeparam>
    public interface ISave<T>
    {
        /// <summary>
        /// Path to the directory where all of the files are saved.
        /// </summary>
        public static string? DirectoryPath { get; }

        /// <summary>
        /// Saves data to file.
        /// </summary>
        /// <param name="data">Data of the game that is being written to file.</param>
        public void Retain(T data);

        /// <summary>
        /// Reads data from file and desrializes it into object.
        /// </summary>
        /// <param name="fileName">Name of the file that has data about object.</param>
        /// <returns>Object that has been deserialized from file.</returns>
        public static T Restore(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);

            T data = JsonConvert.DeserializeObject<T>(jsonString);

            return data;
        }

        /// <summary>
        /// Gets all file names from directory.
        /// </summary>
        /// <param name="dirName">Name of the directory that contains backup files.</param>
        /// <returns>String array of the file names.</returns>
        public static string[] GetRestoreOptions()
        {
            return Directory.GetFiles(DirectoryPath);
        }
    }
}
