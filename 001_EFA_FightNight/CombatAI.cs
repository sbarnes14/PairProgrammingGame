using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_EFA_FightNight
{
    public enum Punches { Jab, Hook, Uppercut };
    public class CombatAI
    {
        public int CombatCheck(Punches userPunches, Punches comPunches)
        {
            if (userPunches == Punches.Jab && comPunches == Punches.Hook)
            {
                return 1;
            }
            else if (userPunches == Punches.Hook && comPunches == Punches.Uppercut)
            {
                return 1;
            }
            else if (userPunches == Punches.Uppercut && comPunches == Punches.Jab)
            {
                return 1;
            }
            else if (userPunches == Punches.Hook && comPunches == Punches.Jab)
            {
                return 2;
            }
            else if (userPunches == Punches.Jab && comPunches == Punches.Uppercut)
            {
                return 2;
            }
            else if (userPunches == Punches.Uppercut && comPunches == Punches.Hook)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }


        public Punches ComputerPunch()
        {
            var rand = new Random();
            int computerPunches = rand.Next(0, 3);
            return (Punches)computerPunches;
        }

        public Punches UserPunch()
        {
            bool truePunch = true;
            while (truePunch)
            {
                string swing = Console.ReadLine();
                switch (swing.ToLower())
                {
                    case "j":
                    case "jab":
                        return Punches.Jab;
                    case "h":
                    case "hook":
                        return Punches.Hook;
                    case "u":
                    case "uppercut":
                        return Punches.Uppercut;
                    default:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Remember your punches! (j)ab, (h)ook, (u)ppercut");
                        Console.ResetColor();
                        break;
                }
            }
            return Punches.Jab;
        }

        public string WhoWon(Punches player, Punches comp, string enemy, int victor)
        {
            string winner;
            switch(victor){
                case 0:
                    winner = "No one";
                    break;
                case 1:
                    winner = "You";
                    break;
                case 2:
                    winner = enemy;
                    break;
                default:
                    winner = "everyone";
                        break;
            }
            return $"You threw a {player}, {enemy} threw a {comp}, {winner} wins this round";
        }
    }
}
