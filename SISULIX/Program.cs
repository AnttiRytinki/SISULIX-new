
using SISULIX;
using SISULIX.Algoritmen;
using System.Reflection;

Console.WriteLine("SISULIX");
Console.WriteLine("Mikäseonse?");

int searchDepth = 10;
int mainLoopIterations = 0;

Vocabulary vocabulary = new Vocabulary();
vocabulary.ReadFromFile("vocabulary.txt");
vocabulary.SaveToFile("vocabulary.txt");
vocabulary.Process("Mikäseonse?");

Brain brain = new Brain(vocabulary);

ChatGPTClient chatGPTClient = new ChatGPTClient();

FileHandler fileHandler = new FileHandler();

await RunLoop();

async Task RunLoop()
{
    while (true)
    {
        Console.WriteLine("Main Loop Iteration - " + mainLoopIterations);
        mainLoopIterations++;

        string? input = Console.ReadLine();

        if (input == null)
            return;

        if (input.StartsWith("gpt"))
        {
            input = input.Substring(3);
            string replyFromGPT = await chatGPTClient.AskChatGPT(input);
            Console.WriteLine("ChatGPT: " + replyFromGPT);
            continue;
        }

        string reply = vocabulary.Process(input);

        Console.WriteLine("INPUT - " + input);
        var output = brain.Process(input);
        Console.WriteLine("OUTPUT - " + output);

        if (input.Contains("."))
            fileHandler.SaveToFile(input, reply);

        vocabulary.SaveToFile("vocabulary.txt");

        Console.WriteLine(reply);

        if (string.IsNullOrEmpty(input))
            return;
        else if (input == "now")
            Console.WriteLine(DateTime.Now.ToString());
        else
            Search(searchDepth, input);
    }
}

void HandleIsColor(string input)
{
    Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);

    string newColor = ConvertColor(input, "black", out string finnish);

    if (input.Contains("?"))
        HandleQuestionMark(input);
}

void HandleQuestionMark(string input)
{
    Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);

    Console.WriteLine("Mitä?");
}

string ConvertColor(string input, string to, out string finnish)
{
    Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);

    finnish = "";
    return "black";
}

bool IsColor(string input, int searchDepth)
{
    Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);

    // Early check for null input to avoid unnecessary loop iterations.
    if (input == null)
        return false;

    // Loop through the search depth
    for (int i = 0; i < searchDepth; i++)
    {
        Console.WriteLine("IsColor" + " - " + "Iteration" + " - " + i.ToString());

        // Start parallel process (if needed, using Task.Run)
        Task.Run(() =>
        {
            // Here you could do parallel work, for example, checking if input is a color.
            if (CheckIfColor(input))
            {
                Console.WriteLine("Color found in parallel process.");
            }
        });

        // If you want to immediately return based on the result of CheckIfColor, keep it here.
        // But remember: this is not a blocking call.
    }

    // This would return false by default unless you handle the results of your parallel checks.
    return false;
}


bool CheckIfColor(string input)
{
    Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);

    if (string.IsNullOrEmpty(input))
        return false;

    else if (input == "yellow")
        return true;
    else if (input == "red")
        return true;
    else if (input == "green")
        return true;
    else if (input == "blue")
        return true;
    else if (input == "pink")
        return true;
    else if (input == "black")
        return true;
    else if (input == "orange")
        return true;
    else if (input == "brown")
        return true;
    else if (input == "white")
        return true;
    else if (input == "gray")
        return true;

    else if (input == "transparent")
    {
        try
        {
            HandleTransparent();
        }
        catch (Exception ex)
        {
            ExceptionHandler(ex);
        }

        return true;
    }

    return false;
}

void HandleTransparent()
{
    Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);

    throw new NotImplementedException();
}

void Search(int searchDepth, string input)
{
    Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);

    if (input == null)
        return;

    try
    {
        if (IsColor(input, searchDepth))
            HandleIsColor(input);
    }
    catch (Exception ex)
    {
        ExceptionHandler(ex);
    }
}

void ExceptionHandler(Exception ex)
{
    Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);

    Log(ex.Message.ToString(), "LogTopLevel.txt");
    Console.WriteLine("Exception" + " - " + ex.Message.ToString());
    Console.WriteLine(ex.ToString());
}

void Log(string exceptionString, string fileName)
{
    Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);

    var fileHandler = new FileHandler();
    fileHandler.SaveToFile(fileName, exceptionString);
}
