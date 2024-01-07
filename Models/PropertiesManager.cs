using RandomFactory.ViewModels;
using System.IO;
using Newtonsoft.Json;

namespace RandomFactory.Models
{
    public static class PropertiesManager
    {
        private static string pathRandomGeneratorVM = "RandomGeneratorVM.json";
        public static void SaveRandomGeneratorVM(RandomGeneratorVM randomGeneratorVM)
        {
            string json = JsonConvert.SerializeObject(randomGeneratorVM);

            File.WriteAllText(pathRandomGeneratorVM, json);
        }

        public static RandomGeneratorVM ReadRandomGeneratorVM()
        {
            return File.Exists(pathRandomGeneratorVM) ? JsonConvert.DeserializeObject<RandomGeneratorVM>(File.ReadAllText(pathRandomGeneratorVM)) : new RandomGeneratorVM();
        }

    }
}
