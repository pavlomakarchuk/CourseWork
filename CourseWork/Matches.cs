using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class Matches
    {
        static private List<Match> matches = new();
        internal static List<Match> MatchesList { get => matches; set => matches = value; }
        public static void AddMatch(string team1, string team2, DateTime date,
            string type, string tournament, string score)
        {
            MatchesList.Add(new Match()
            {
                Team1 = team1,
                Team2 = team2,
                Date = date,
                Type = type,
                Tournament = tournament,
                Score = score
            });
            MatchesList.Sort(delegate (Match x, Match y)
            {
                return x.Date.CompareTo(y.Date);
            });

        }

        public static void TodayMatches()
        {
            bool played = false;
            foreach (Match m in MatchesList)
            {

                if (m.Date == DateTime.Today)
                {
                    if (m.Type == "friendly")
                    {
                        played = true;
                        Console.WriteLine($"There will be {m.Type} match \"{m.Team1} - {m.Team2}\" today.");
                    }
                    else
                    {
                        played = true;
                        Console.WriteLine($"There will be {m.Type} match \"{m.Team1} - {m.Team2}\", in {m.Tournament} today.");
                    }
                }

            }
            if (played == false)
            {
                Console.WriteLine($"There aren't any matches today.");
            }
        }



        public static void TeamMatches(string team)
        {
            bool played = false;
            foreach (Match m in MatchesList)
            {
                try
                {
                    if ((m.Team1 == team || m.Team2 == team) && m.Date < DateTime.Today)
                    {
                        if (m.Type == "friendly")
                        {
                            played = true;
                            Console.WriteLine($"{team} played in {m.Type} match \"{m.Team1} - {m.Team2}\", score: {m.Score}, on {m.Date.ToShortDateString()}.");
                        }
                        else
                        {
                            played = true;
                            Console.WriteLine($"{team} played in {m.Type} match \"{m.Team1} - {m.Team2}\", score: {m.Score}, on {m.Date.ToShortDateString()} in {m.Tournament}.");
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("There isn't such team.");
                    return;
                }
            }
            if (played == false)
            {
                Console.WriteLine($"{team} hasn't played any matches yet.");
            }
        }
        public static void PlayerMatches(string name)
        {
            bool played = false;
            Player p = Players.GetPlayerByName(name);
            foreach (Match m in MatchesList)
            {
                try
                {
                    if ((m.Team1 == p.Team || m.Team2 == p.Team) && m.Date < DateTime.Today)
                    {
                        if (m.Type == "friendly")
                        {
                            played = true;
                            Console.WriteLine($"{name} played in {m.Type} match \"{m.Team1} - {m.Team2}\", score: {m.Score}, on {m.Date.ToShortDateString()}.");
                        }
                        else
                        {
                            played = true;
                            Console.WriteLine($"{name} played in {m.Type} match \"{m.Team1} - {m.Team2}\", score: {m.Score}, on {m.Date.ToShortDateString()} in {m.Tournament}.");
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("There isn't such player.");

                    return;
                }

            }
            if (played == false)
            {
                Console.WriteLine($"{name} hasn't played any matches yet.");
            }
        }
        public static void FutureTeamMatches(string team)
        {
            bool played = false;
            foreach (Match m in MatchesList)
            {

                if ((m.Team1 == team && m.Team2 == team) || m.Date >= DateTime.Today)
                {
                    if (m.Type == "friendly")
                    {
                        played = true;
                        Console.WriteLine($"{team} will play in {m.Type} match \"{m.Team1} - {m.Team2}\", on {m.Date.ToShortDateString()}.");
                    }
                    else
                    {
                        played = true;
                        Console.WriteLine($"{team} will play in {m.Type} match \"{m.Team1} - {m.Team2}\", on {m.Date.ToShortDateString()} in {m.Tournament}.");
                    }
                }

            }
            if (played == false)
            {
                Console.WriteLine($"{team} don't have any future matches.");
            }
        }
        public static void FuturePlayerMatches(string name)
        {
            bool played = false;
            Player p = Players.GetPlayerByName(name);
            foreach (Match m in MatchesList)
            {

                if ((m.Team1 == p.Team && m.Team2 == p.Team) || m.Date >= DateTime.Today)
                {
                    if (m.Type == "friendly")
                    {
                        played = true;
                        Console.WriteLine($"{name} will play in {m.Type} match \"{m.Team1} - {m.Team2}\", on {m.Date.ToShortDateString()}.");
                    }
                    else
                    {
                        played = true;
                        Console.WriteLine($"{name} will play in {m.Type} match \"{m.Team1} - {m.Team2}\", on {m.Date.ToShortDateString()} in {m.Tournament}.");
                    }
                }

            }
            if (played == false)
            {
                Console.WriteLine($"{name} don't have any future matches.");
            }
        }
        public static void TournamentMatches(string tournament)
        {
            bool played = false;
            Console.WriteLine($"History of {tournament} tournament:");
            foreach (Match m in MatchesList)
            {
                if ((m.Tournament == tournament) && m.Date < DateTime.Today)
                {
                    {
                        played = true;
                        Console.WriteLine($"{m.Team1} - {m.Team2}\", score: {m.Score}, played on {m.Date.ToShortDateString()} in {m.Tournament}.");
                    }
                }

            }
            if (played == false)
            {
                Console.WriteLine($"There hasn't been any {tournament} matches yet.");
            }
        }
        public static void FutureTournamentMatches(string tournament)
        {
            bool played = false;
            Console.WriteLine($"Next {tournament} matches:");
            foreach (Match m in MatchesList)
            {
                if ((m.Tournament == tournament) && m.Date >= DateTime.Today)
                {
                    {
                        played = true;
                        Console.WriteLine($"There will be match \"{m.Team1} - {m.Team2}\", played on {m.Date.ToShortDateString()} in {m.Tournament}.");
                    }
                }

            }
            if (played == false)
            {
                Console.WriteLine($"There won't be any {tournament} matches.");
            }
        }
        public static void TypeMatches(string type)
        {
            bool played = false;
            Console.WriteLine($"History of {type} matches:");
            foreach (Match m in MatchesList)
            {
                if ((m.Type == type) && m.Date < DateTime.Today && type == "friendly")
                {
                    {
                        played = true;
                        Console.WriteLine($"There was {m.Type} match \"{m.Team1} - {m.Team2}\", score {m.Score} on {m.Date.ToShortDateString()}");
                    }
                }
                else if ((m.Type == type) && m.Date < DateTime.Today && type == "competitive")
                {
                    {
                        played = true;
                        Console.WriteLine($"There was {m.Type} match \"{m.Team1} - {m.Team2}\", score {m.Score}, on {m.Date.ToShortDateString()} in {m.Tournament}.");
                    }
                }
            }
            if (played == false)
            {
                Console.WriteLine($"There weren't any {type} matches.");
            }
        }
        public static void FutureTypeMatches(string type)
        {
            bool played = false;
            Console.WriteLine($"Next {type} matches:");
            foreach (Match m in MatchesList)
            {
                if ((m.Type == type) && m.Date >= DateTime.Today && type == "friendly")
                {
                    {
                        played = true;
                        Console.WriteLine($"There will be {m.Type} match \"{m.Team1} - {m.Team2}\", on {m.Date.ToShortDateString()}");
                    }
                }
                else if ((m.Type == type) && m.Date < DateTime.Today && type == "competitive")
                {
                    {
                        played = true;
                        Console.WriteLine($"There will be {m.Type} match \"{m.Team1} - {m.Team2}\", on {m.Date.ToShortDateString()} in {m.Tournament}.");
                    }
                }
            }
            if (played == false)
            {
                Console.WriteLine($"There won't any {type} matches.");
            }
        }

        public static void MatchesBetweenDates(DateTime date1, DateTime date2)
        {
            bool played = false;
            foreach (Match m in MatchesList)
            {
                if ((m.Date > date1 && m.Date < date2) && m.Date < DateTime.Today)
                {
                    if (m.Type == "friendly")
                    {
                        played = true;
                        Console.WriteLine($"There was {m.Type} match \"{m.Team1} - {m.Team2}\", score: {m.Score}, on {m.Date.ToShortDateString()}.");
                    }
                    else
                    {
                        played = true;
                        Console.WriteLine($"There was {m.Type} match \"{m.Team1} - {m.Team2}\", score: {m.Score}, on {m.Date.ToShortDateString()} in {m.Tournament}.");
                    }
                }
                if ((m.Date > date1 && m.Date < date2) && m.Date >= DateTime.Today)
                {
                    if (m.Type == "friendly")
                    {
                        played = true;
                        Console.WriteLine($"There will be friendly match\"{m.Team1} - {m.Team2}\", on {m.Date.ToShortDateString()}.");
                    }
                    else
                    {
                        played = true;
                        Console.WriteLine($"There will be {m.Type} match \"{m.Team1} - {m.Team2}\", on {m.Date.ToShortDateString()} in {m.Tournament}.");
                    }
                }

            }
            if (played == false)
            {
                Console.WriteLine($"There hasn't been any or won't be any matches between these two dates.");
            }
        }


    }
}
