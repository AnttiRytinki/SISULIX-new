using System.Reflection;

namespace SISULIX
{
    public class Human
    {
        public void ThrowUp()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);
        }
    }
}
