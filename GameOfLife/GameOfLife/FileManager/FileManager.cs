using Newtonsoft.Json;

namespace GameOfLife
{
    /// <summary>
    /// Class for generic implementation of retaining and restoring operations.
    /// </summary>
    /// <typeparam name="T">Type of game that is saved in the file.</typeparam>
    public class FileManager<T> : IFileManager<T>
    {
        /// <summary>
        /// Name of the directory for the game files.
        /// </summary>
        private static readonly string _dirName = "GameFiles";

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public static string DirectoryPath 
        { 
            get
            {
                string fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _dirName);

                return fullPath;
            }

        }

        /// <summary>
        /// Creates json file and saves the info about game.
        /// </summary>
        /// <param name="data">Holds object that contains data about the game.</param>
        public void Retain(T data)
        {
            if(!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            string jsonString = JsonConvert.SerializeObject(data);
            string fileName = $"{DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss")}.json";

            using (StreamWriter sw = new StreamWriter(Path.Combine(DirectoryPath, fileName)))
            {
                sw.Write(jsonString);
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="fileName"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public static T Restore(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            T data = JsonConvert.DeserializeObject<T>(jsonString);

            return data;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/>/></returns>
        public static string[] GetRestoreOptions()
        {
            return Directory.GetFiles(DirectoryPath);
        }
    }
}
