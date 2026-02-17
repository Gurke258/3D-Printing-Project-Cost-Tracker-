using PrintTracker.Core;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization.Metadata;

namespace PrintTracker.Infrastructure
{
    public class FileStorageService : IStorageService
    {

        public IStorageService StorageService => throw new NotImplementedException();

        private static string _folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static string _directoryPath = Path.Combine(_folder, "PrintTracker");
        private static string _filePath = Path.Combine(_folder, "PrintTracker", "projects.json");

        //string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Local\\3DPrint\\Test.json");

        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
        {
            WriteIndented = true,
            TypeInfoResolver = new DefaultJsonTypeInfoResolver()
        };

        public void SaveData<T>(T data)
        {

            string jsonData = JsonSerializer.Serialize(data, jsonSerializerOptions);
            Directory.CreateDirectory(_directoryPath);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
