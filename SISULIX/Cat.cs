using System.Reflection;

namespace SISULIX
{
    public class Cat
    {
        public int NumberOfWhiskers { get; set; } = 10;

        public void ThrowUp()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);
        }
    }
}
