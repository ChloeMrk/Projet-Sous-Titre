using System;
using System.IO;
using System.Threading.Tasks;

namespace ProjetST
{
    public class ST
    {
        public void LireST()
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            StreamReader file =
                new StreamReader(@"/Users/chloemerck/Desktop/Glee - S02E02 - Britney-Brittany copie.txt");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
            }

            file.Close();
            Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  

            
        }

       public async Task PrintWithDelay(String s)
        {
            for(int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
                await Task.Delay(5);

            }
        }

        public async Task PrintTextWithDelay()
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            using(StreamReader outputFile= new StreamReader(mydocpath + @"/Glee - S02E02 - Britney-Brittany copie.txt"))
            {
                string s;
                while ((s = outputFile.ReadLine()) != null)
                {
                    Task t = PrintWithDelay(s);
                    await t;
                }
            }
           
        }

            public ST()
        {
        }
    }
}
