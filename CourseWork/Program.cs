using System;


namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //types: friendly, competitive
            //Tournaments: UCL (UEFA Champions League), UEL (UEFA Europe League), EPL (English Premier League)

            Players.AddPlayer("Tom Hanks", 33, "Manchester United");
            Players.AddPlayer("Fred Banks", 21, "West Ham");
            Matches.AddMatch("Manchester United", "West Ham", DateTime.Parse("21/05/2022"), "competitive", "UCL", "2:0");
            Matches.AddMatch("Manchester United", "West Ham", DateTime.Parse("21/05/2017"), "competitive", "UCL", "2:0");
            Matches.AddMatch("Manchester United", "West Ham", DateTime.Parse("25/05/2021"), "competitive", "UCL", "2:0");

            Matches.AddMatch("Manchester United", "West Ham", DateTime.Parse("21/05/2015"), "competitive", "UCL", "2:0");
            Matches.AddMatch("Liverpool", "Chelsey", DateTime.Parse("21/04/2015"), "friendly", "none", "3:0");
            Console.WriteLine("Choose one of these options: \n1. Add new player. \n2. Add new match.\n3. Show all player's matches." +
                "\n4. Show all team's matches.\n5. Show all matches between two dates.\n6. Show all matches of one tournament.\n" +
                "7. Show all matches of one type (friendly or competitive).\n8. Show today's matches.\n9. Show line-up of a team.\n0. Quit.");


            bool switcher = true;
            while(switcher)
            { 
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "0":
                        switcher = false;
                        Console.WriteLine("Thank you! Have a nice day!");
                        break;
                    case "1": //addplayer
                        try
                        {
                            Console.Write("Enter the name of the player: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter the age of the player: ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter the team of the player: ");
                            string team = Console.ReadLine();
                            Players.AddPlayer(name, age, team);
                            Console.WriteLine("You've succesfully added new player.");
                            Console.WriteLine("Choose one of previous options.");
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("You've entered something wrong.");
                            Console.WriteLine("Choose one of previous options.");
                        }
                        break;

                    case "2": //addmatch
                        try
                        {
                            Console.Write("Enter the first team: ");
                            string team1 = Console.ReadLine();
                            Console.Write("Enter the second team: ");
                            string team2 = Console.ReadLine();
                            Console.Write("Enter the date (eg. 12/05/2008): ");
                            DateTime date = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter the type of the match (friendly or competitive): ");
                            string type = Console.ReadLine();
                            Console.Write("Enter the tournament(UCL, UEL, EPL) , or type \"none\" if it is a friendly match: ");
                            string tournament = Console.ReadLine();
                            Console.Write("Enter the score (e.g. 2:0):, or \"none\" if match is still to be played: " +
                                "");
                            string score = Console.ReadLine();
                            Matches.AddMatch(team1, team2, date, type, tournament, score);
                            Console.WriteLine("You've succesfully added new match.");
                            Console.WriteLine("Choose one of previous options.");
                            
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("You've entered something wrong.");
                            Console.WriteLine("Choose one of previous options.");
                            
                        }
                        break;
                    default:
                        Console.WriteLine("You've pressed wrong key.");
                        Console.WriteLine("Choose one of previous options.");
                        break;
                    case "3": //player matches
                        Console.WriteLine("Which matches you want to see, past or future? ");
                        string selection2 = Console.ReadLine();
                        if (selection2.ToLower() == "past")
                        {
                            Console.Write("Enter the name of the player: ");
                            string pname = Console.ReadLine();
                            Matches.PlayerMatches(pname);
                            Console.WriteLine("Choose one of previous options.");
                            break;
                        }
                        else if (selection2.ToLower() == "future")
                        {
                            Console.Write("Enter the name of the player: ");
                            string pname = Console.ReadLine();
                            Matches.FuturePlayerMatches(pname);
                            Console.WriteLine("Choose one of previous options.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You've entered wrong word.");
                            Console.WriteLine("Choose one of previous options.");
                            break;
                        }
                        

                    case "4": //team matches
                        Console.Write("Which matches you want to see, past or future?");
                        string selection3 = Console.ReadLine();
                        if (selection3.ToLower() == "past")
                        {
                            Console.Write("Enter the name of the team: ");
                            string tname = Console.ReadLine();
                            Matches.TeamMatches(tname);
                            Console.WriteLine("Choose one of previous options.");
                            break;
                        }
                        else if (selection3.ToLower() == "future")
                        {
                            Console.Write("Enter the name of the team: ");
                            string tname = Console.ReadLine();
                            Matches.FutureTeamMatches(tname);
                            Console.WriteLine("Choose one of previous options.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You've entered wrong word.");
                            Console.WriteLine("Choose one of previous options.");
                            break;
                        }
                        
                    case "5": //date matches
                        Console.Write("Enter the first date:");
                        DateTime date1 = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter the second date:");
                        DateTime date2 = DateTime.Parse(Console.ReadLine());
                        Matches.MatchesBetweenDates(date1, date2);
                        Console.WriteLine("Choose one of previous options.");
                        break;
                    case "6": //tournament matches
                        Console.Write("Enter the tournament (e.g. UCL, UEL, EPL): ");
                        string tournament1 = Console.ReadLine();
                        Console.Write("Which matches you want to see, past or future? ");
                        string selection4 = Console.ReadLine();
                        if (selection4.ToLower() == "past")
                        {
                            Matches.TournamentMatches(tournament1);
                            Console.WriteLine("Choose one of previous options.");
                            break;
                        }
                        else if (selection4.ToLower() == "future")
                        {
                            Matches.FutureTournamentMatches(tournament1);
                            Console.WriteLine("Choose one of previous options.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You've entered wrong word.");
                            Console.WriteLine("Choose one of previous options.");
                            break;
                        }
                    case "7": //type matches (friendly, competitive)
                        Console.Write("Enter the type(friendly or competitive): ");
                        string type2 = Console.ReadLine();
                        Console.Write("Which matches you want to see, past or future? ");
                        string selection5 = Console.ReadLine();
                        if (selection5.ToLower() == "past")
                        {
                            Matches.TypeMatches(type2);
                            Console.WriteLine("Choose one of previous options.");
                            break;
                        }
                        else if (selection5.ToLower() == "future")
                        {
                            Matches.FutureTypeMatches(type2);
                            Console.WriteLine("Choose one of previous options.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You've entered wrong word.");
                            Console.WriteLine("Choose one of previous options.");
                            break;
                        }
                    case "8": //show today matches
                        Matches.TodayMatches();
                        Console.WriteLine("Choose one of previous options.");
                        break;
                    case "9": //line-up of a team
                        Console.WriteLine("Enter the name of the team: ");
                        string pname2 = Console.ReadLine();
                        Players.ShowTeam(pname2);
                        Console.WriteLine("Choose one of previous options.");
                        break;
                }
            }           
        }
    }
}
