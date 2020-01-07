using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsDemo
{
    [Serializable]
    public class Except : ApplicationException
    {
        public Except() { } 
        public Except(string message) : base( message) { }
        public Except(string message, System.Exception inner) : base( message, inner) { }
        protected Except(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base( info, context) { }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Starship Serenity = new Starship("Serenity", "Firefly", "404-E-132-4FE274A", 9);

            try
            {
                Serenity.AddCrew("Captain", "Malcolm Reynolds");
                Serenity.AddCrew("FirstMate", "Zoe Washburne");
                Serenity.AddCrew("Pilot", "Hoban Washburne");
                Serenity.AddCrew("Engineer", "Kaywinnet Lee Frye");
                Serenity.AddCrew("PublicRelations", "Jayne Cobb");
                Serenity.AddCrew("Ambassador", "Inara Serra");
                Serenity.AddCrew("Shepherd", "Derrial Book");
                Serenity.AddCrew("Medic", "Simon Tam");
                Serenity.AddCrew("Crew", "River Tam");
                if (Serenity.CurrentCrewSize() >= Serenity.CrewCapacity)
                {
                    //Console.WriteLine("test test test");
                    throw new Except($"{Serenity.Name} is over crew capacity!");
                }
                Serenity.AddCrew("Janitor", "Javier");

                
            }
            catch (Except e)
            {
                Console.WriteLine(e.Message);
            }

            Serenity.Print();
            Serenity.PrintRoster();


            Console.ReadLine();
        }
    }
}
