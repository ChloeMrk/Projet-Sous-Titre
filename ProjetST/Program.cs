using System;
using System.IO;
using System.Threading.Tasks;

namespace ProjetST
{
    class MainClass
    {
        public static async Task Main()
        {
            ST s = new ST();

            Task t = s.PrintTextWithDelay();

            await t;

            Console.ReadLine();

        }


    }
}
