namespace SISULIX
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    namespace Algoritmen
    {
        public class Vocabulary
        {
            List<string> _strings = new List<string>();

            public string Process(string stringToBeProcessed)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod()!.Name + " - " + stringToBeProcessed);

                if (stringToBeProcessed == "105")
                {
                    Console.WriteLine("Hei hei");

                    return "";
                }

                if (stringToBeProcessed == "Mikäseonse?")
                    SeOnSe(stringToBeProcessed);

                if (stringToBeProcessed != "")
                    _strings.Add(stringToBeProcessed);

                var randomWord = _strings[new Random().Next(_strings.Count)];
                Console.WriteLine(randomWord);

                return randomWord;
            }

            private void SeOnSe(string stringToBeProcessed)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod()!.Name + " - " + stringToBeProcessed);

                Console.WriteLine(stringToBeProcessed);
            }

            public void SaveToFile(string filePath)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod()!.Name + " - " + filePath);

                if (!File.Exists(filePath)) 
                    return;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string s in _strings)
                    {
                        writer.WriteLine(s);
                    }
                }
            }

            public void ReadFromFile(string filePath) // Make filePath non-nullable
            {
                if (filePath == null)
                {
                    throw new ArgumentNullException(nameof(filePath), "File path cannot be null.");
                }

                Console.WriteLine(MethodBase.GetCurrentMethod()!.Name + " - " + filePath);

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string? str = reader.ReadLine();

                    while (str != null)
                    {
                        _strings.Add(str);
                    }
                }
            }
        }
    }
}
