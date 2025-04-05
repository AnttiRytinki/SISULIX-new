using System.Reflection;

namespace SISULIX
{
    public class It
    {
        public int Size { get; set; } = 0;
        public bool IsJoke { get; set; } = false;

        public void Happens()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod()!.Name);
        }

        public void Be(It it1, It it2)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod()!.Name + " - " + it1.ToString() + " - " + it2.ToString());

            if (IsJoke)
                return;

            else
            {
                if (it1 == it2)
                    Console.WriteLine("EQUAL");
                else
                    Console.WriteLine("NOT EQUAL");

                return;
            }
        }
    }
}
