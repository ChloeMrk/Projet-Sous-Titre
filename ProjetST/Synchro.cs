using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetST
{
    public class Synchro
    {
        List<Sous_Titre> subt = new List<Sous_Titre>();

        public Synchro()
        {
        }

        public void Afficher()
        {
            Regex time = new Regex(@"^\d\d:\d\d:\d\d,\d\d\d");
            Regex text = new Regex(@"^(.).+(\r\n|$)");
            string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            string ST = null;
            TimeSpan start = TimeSpan.Parse("00:00");
            TimeSpan stop = TimeSpan.Parse("00:00");
            string[] split = null;

            using (StreamReader ReadExistingFile = new StreamReader(FilePath + @"/KaamelottS01E01french.txt"))
            {


                string line;

                while ((line = ReadExistingFile.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        subt.Add(new Sous_Titre(ST, start, stop));
                        ST = "";
                    }

                    
                        if (time.Match(line).Success)
                        {
                            split = line.Split(' ');
                            start = TimeSpan.Parse(split[0]);
                            stop = TimeSpan.Parse(split[2]);

                        }

                        else if (text.Match(line).Success)
                        {
                            if (ST == null)
                            {
                                ST +=  line + "\n";
                            }

                            else
                            {
                                ST +=  line + "\n";
                            }

                        }
  
                }

            }
        }


        public async Task ShowSubtitles()
        {
            await Task.Delay(subt[0].start);
            Console.WriteLine(subt[0].ST);
            await Task.Delay(subt[0].stop - subt[0].start);
            Console.Clear();

            for (int i = 1; i < subt.Count;i++)
            {
                await Task.Delay(subt[i].start - subt[i - 1].stop);
                Console.WriteLine(subt[i].ST);
                await Task.Delay(subt[i].stop - subt[i].start);
                Console.Clear();
            }
        }

    }
}