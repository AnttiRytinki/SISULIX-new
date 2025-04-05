using System.Reflection;

namespace SISULIX
{
    public class FileHandler
    {
        public void SaveToFile(string filePath, string str)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod()!.Name + " - " + "Path: " + filePath + " - " + "String: " + str);

            if (!File.Exists(filePath))
                return;

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(str);
            }
        }
    }
}
