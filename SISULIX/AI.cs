using System.Reflection;

namespace SISULIX
{
    public class AI
    {
        public string Name { get; set; } = "";

        public void PickOne(List<AI> aIs)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);

            var randomAI = aIs[new Random().Next(aIs.Count)];
            Console.WriteLine(randomAI);
        }
    }
}
