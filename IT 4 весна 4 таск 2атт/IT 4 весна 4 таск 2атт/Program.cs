using System;

namespace IT_4_весна_4_таск_2атт
{

    
    class Athlete
    {
        public string surname;
        public int numCompetitions;
        public int sumPlaces;

        public Athlete(string surname, int numCompetitions, int sumPlaces)
        {
            this.surname = surname;
            this.numCompetitions = numCompetitions;
            this.sumPlaces = sumPlaces;
        }

        public double CalculateQuality()
        {
            return numCompetitions / (double)sumPlaces;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Athlete: {surname}");
            Console.WriteLine($"Number of competitions: {numCompetitions}");
            Console.WriteLine($"Sum of places: {sumPlaces}");
            Console.WriteLine($"Quality: {CalculateQuality()}");
        }
    }

    // 2nd lvl
    class ProfessionalAthlete : Athlete
    {
        public bool P;

        public ProfessionalAthlete(string surname, int numCompetitions, int sumPlaces, bool P)
            : base(surname, numCompetitions, sumPlaces)
        {
            this.P = P;
        }

        public new double CalculateQuality()
        {
            if (P == true)
            {
                return 1.5 * base.CalculateQuality();
            }
            else
            {
                return base.CalculateQuality();
            }
        }

        public new void PrintInfo()
        {
            Console.WriteLine($"Professional athlete: {surname}");
            Console.WriteLine($"Number of competitions: {numCompetitions}");
            Console.WriteLine($"Sum of places: {sumPlaces}");
            Console.WriteLine($"P: {P}");
            Console.WriteLine($"Quality: {CalculateQuality()}");
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
          
            Athlete athlete1 = new Athlete("Smith", 10, 30);
            athlete1.PrintInfo();
            Console.WriteLine();

            // ProfessionalAthlete
            ProfessionalAthlete athlete2 = new ProfessionalAthlete("Johnson", 10, 30, true);
            athlete2.PrintInfo();
        }
    }

}
