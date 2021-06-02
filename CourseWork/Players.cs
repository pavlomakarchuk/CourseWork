using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
   
    class Players
    {
        static private List<Player> players = new();

        internal static List<Player> PlayersList { get => players; set => players = value; }

        public static void AddPlayer(string name, int age, string team)
        {
            PlayersList.Add(new Player() { Name = name, Age = age, Team = team });
        }
        public static void ShowTeam(string team)
        {
            bool areplayers = false;
            Console.WriteLine($"line-up of {team}: ");
            foreach(Player p in PlayersList)
            {
                if(p.Team == team)
                {
                    areplayers = true;
                    Console.WriteLine($"{p.Name}, {p.Age}");
                }
            }
            if (areplayers==false)
            {
                Console.WriteLine("There aren't any players in this team.");
            }
        }
        public static Player GetPlayerByName(string name)
        {
            foreach (Player p in PlayersList)
            {
                if (p.Name == name)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
