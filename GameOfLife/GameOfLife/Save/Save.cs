using Newtonsoft.Json;

namespace GameOfLife.Utils
{
    /// <summary>
    /// Class for generic implementation of retaining and restoring operations.
    /// </summary>
    /// <typeparam name="T">Type of game that is saved in the file.</typeparam>
    public class Save<T> : ISave<T>
    {
        /// <summary>
        /// Creates json file and saves the info about game.
        /// </summary>
        /// <param name="data">Holds object that contains data about the game.</param>
        public void Retain(T data)
        {
            string pathName = @"c:\ConwayGame";

            if(!Directory.Exists(pathName))
            {
                Directory.CreateDirectory(pathName);
            }

            string jsonString = JsonConvert.SerializeObject(data);

            string fileName = $"{pathName}\\{Guid.NewGuid()}.json";

           File.WriteAllText(fileName, jsonString);
        }

        /// <summary>
        /// Restores session games.
        /// </summary>
        /// <param name="fileName">Name of the fil that has data about game.</param>
        /// <returns>Returns object that can be used for further games.</returns>
        public T Restore(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);

            T data = JsonConvert.DeserializeObject<T>(jsonString);

            return data;
        }
    }
}
