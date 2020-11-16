using System;
using System.IO;
using System.Threading.Tasks;

namespace ProjetST
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Synchro syncst = new Synchro();
            syncst.Afficher();
            Task.WaitAll(syncst.ShowSubtitles());
            Console.ReadKey();
        }


    }
}
