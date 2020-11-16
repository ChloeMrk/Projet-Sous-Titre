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
            Regex StartEnd = new Regex(@"\d\d:\d\d:\d\d,\d\d\d");
            Regex SubtitleTxt = new Regex(@"^(\D).+");
            string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string ST = "";

            TimeSpan start = new TimeSpan(0);
            TimeSpan stop = new TimeSpan(0);
            
            
                using (StreamReader ReadExistingFile = new StreamReader(FilePath + @"/Banshee - 1x01 - Pilot.FR.HUFLIX.TV copie.txt"))
                {
                    string line;

                    while ((line = ReadExistingFile.ReadLine()) != null)
                    {
                        if (line == "")
                        {
                            subt.Add(new Sous_Titre(ST, start, stop));
                        }
                        if (StartEnd.Match(line).Success)
                        {
                            string[] time = line.Split(' ');
                            start = TimeSpan.Parse(time[0]);
                            stop = TimeSpan.Parse(time[2]);

                        }

                        if (SubtitleTxt.Match(line).Success)
                        {
                            ST = line;
                            
                        }
                    }
                }
            

        }

        public async Task ShowSubtitles()
        {
            TimeSpan previous = new TimeSpan();

            await Task.Delay(subt[0].start);
            Console.WriteLine(subt[0].ST);
            Console.Clear();

            for (int showsub = 1; showsub < subt.Count(); showsub++)
            {
                previous = subt[showsub - 1].stop;

                await Task.Delay(subt[showsub].start - previous);
                Console.WriteLine(subt[showsub].ST);


            }



        }


    }
}
