using SISULIX.Algoritmen;
using System.Reflection;

public class Brain
{
    public Vocabulary Vocabulary { get; }
    public bool IsInSane { get; set; } = false;
    public string Gibberish { get; private set; } = "dafjneibeuBOFOD";

    public Brain(Vocabulary vocabulary)
    {
        Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);

        Vocabulary = vocabulary;
    }

    public string Process(string input)
    {
        Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);

        if (IsInSane)  // Assuming IsInSane is a boolean property or method
        {
            // You can log or handle specific behaviors if IsInSane is true.
            return Gibberish;
        }
        else
        {
            // If input is null, empty, or invalid, consider returning a default or error message
            return string.IsNullOrEmpty(input) ? "Invalid input" : input;
        }
    }
}