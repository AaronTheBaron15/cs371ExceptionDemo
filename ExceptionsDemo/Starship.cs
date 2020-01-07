using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;


namespace ExceptionsDemo
{
    class Starship
    {
        //Data members
        private Dictionary<string, List<string>> roster;

        public List<string> GetCrew(string position)
        {
            return roster[position];
        }



        public int CrewCapacity
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Class
        {
            get;
            set;
        }

        public string RegistrationNumber
        {
            get;
            set;
        }

        //Constructors
        public Starship()
        {
            CrewCapacity = 1;
            RegistrationNumber = "0";
            roster = new Dictionary<string, List<string>>();

        }

        public Starship(string Name, string Class, string RegistrationNumber = "0", int CrewCapacity = 1)
        {
            this.Name = Name;
            this.Class = Class;
            this.RegistrationNumber = RegistrationNumber;
            this.CrewCapacity = CrewCapacity;
            roster = new Dictionary<string, List<string>>();
        }


        // Methods
        public void AddCrew(string position, string name)
        {
            
            // If the position exists in the roster, add the name to its list
            if (roster.ContainsKey(position)) 
            {
            
                roster[position].Add(name);
            }
            // If the position is not yet in the roster, add it
            else
            {
                SetCrew(position, name);
            }
            
        }

        public void SetCrew(string position, string name)
        {
            roster[position] = new List<string>() { name };
        }

        public void Print()
        {
            Console.WriteLine("Vessel {0} of class {1} has a crew capacity of {2}", Name, Class, CrewCapacity);
        }

        public void PrintRoster()
        {
            foreach (KeyValuePair<string, List<string>> kvp in roster)
            {
                Console.Write("{0}: ", kvp.Key);
                foreach (string value in kvp.Value)
                {
                    Console.Write("{0} ", value);
                }
                Console.Write("\n");
            }
            int currentCrewSize = this.CurrentCrewSize();
            Console.WriteLine("{0} has a total of {1} crew members.", Name, currentCrewSize);
        }

        public int CurrentCrewSize()
        {
            int count = 0;
            foreach (KeyValuePair<string, List<string>> kvp in roster)
            {
                count += kvp.Value.Count;
            }
            return count;
        }
    }
}
