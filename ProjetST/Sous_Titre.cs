using System;
namespace ProjetST
{
    public class Sous_Titre
    {
        public TimeSpan start;
        public TimeSpan stop;
        public string ST;
        


        public Sous_Titre(string ST, TimeSpan start, TimeSpan stop)
        {
            this.ST = ST;
            
            this.start = start;
            this.stop = stop;
            

        }

        
    }
}
