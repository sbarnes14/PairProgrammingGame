using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_EFA_FightNight
{
    public class ProgramUI
    {
        public CombatAI _combatAI = new CombatAI();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Start Fight\n" +
                    "2. How To Play\n" +
                    "3. View Oppnenets\n" +
                    "4. Reset\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        //StartFight
                        StartFight();
                        break;
                    case "2":
                    case "two":
                        //Controls
                        Controls();
                        break;
                    case "3":
                        ViewOppnents();
                        break;
                    case "4":
                    case "three":
                        //Reset
                        Reset();
                        break;
                    case "5":
                    case "four":
                        //Exit
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("[1]... [2]... [3]... or [4]...");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }

        }

        Player currentPlayer = new Player("Kid", 1, 10);
        Opponent firstOpponent = new Opponent("Nick", 1, 3);

        public void StartFight()
        {
            Console.Clear();


            Console.WriteLine("Welcome To EFA - Fight Night 2021");
            Console.WriteLine();
            Console.WriteLine("Let me show you how to the punches.");
            Console.WriteLine();
            Console.WriteLine("You look green around here.... need some pointers? Y/N");
            Console.WriteLine();

            if (Console.ReadKey().KeyChar == 'y')
            {
                Console.Clear();

                Console.WriteLine("[~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~]");
                Console.WriteLine("[                                                   ]");
                Console.WriteLine("[  (J)ab beats--->(H)ook beats--->(U)ppercut beats  ]");
                Console.WriteLine("[   ^                                      |        ]");
                Console.WriteLine("[   ^--------------------------------------/        ]");
                Console.WriteLine("[                                                   ]");
                Console.WriteLine("[~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~]");

                Console.ReadKey();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Your (J)ab is quick and beats your opponents slow (H)ook.");
                Console.WriteLine("If they go for an (U)ppercut, try throwing a (H)ook, should catch them by suprise.");
                Console.WriteLine("They try to (J)ab you, slip it and hit them with a mean (U)ppercut, that will teach them.");
                Console.WriteLine();
                Console.WriteLine();
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Remember your name Rookie?");
            Console.WriteLine();
            currentPlayer.MyName = Console.ReadLine();
            if (currentPlayer.MyName == "")
            {
                currentPlayer.MyName = "Kid";
            }

            Console.Clear();
            Console.WriteLine($"Alright {currentPlayer.MyName}, throw some punches and take {firstOpponent.OppName} down!");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Announcer - 'Touch gloves and let's get it on'");
            Console.WriteLine();
            Console.WriteLine($"You touched gloves with {firstOpponent.OppName}, now throw a punch");
            Console.WriteLine();
            Console.WriteLine("(J)ab , (H)ook , or (U)ppercut");
            Console.WriteLine();

            Fight();
            Console.WriteLine();
        }

        public void Fight()
        {

            while (firstOpponent.OppHealth > 0 && currentPlayer.MyHealth > 0)
            {
                Punches userPunch = _combatAI.UserPunch();
                Punches compPunch = _combatAI.ComputerPunch();
                int victor = _combatAI.CombatCheck(userPunch, compPunch);
                Console.Clear();
                Console.WriteLine(_combatAI.WhoWon(userPunch, compPunch, firstOpponent.OppName, victor));

                if (victor == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{currentPlayer.MyName} landed a hit on {firstOpponent.OppName}");
                    Console.WriteLine();
                    Console.WriteLine($"{firstOpponent.OppName}'s Health Remaining {firstOpponent.OppHealth -= 1}");
                    Console.WriteLine();
                    Console.WriteLine($"{currentPlayer.MyName}'s Health Remaining {currentPlayer.MyHealth}");
                    Console.WriteLine();
                }

                else if (victor == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{firstOpponent.OppName} landed a hit on {currentPlayer.MyName}");
                    Console.WriteLine();
                    Console.WriteLine($"{firstOpponent.OppName}'s Health Remaining {firstOpponent.OppHealth}");
                    Console.WriteLine();
                    Console.WriteLine($"{currentPlayer.MyName}'s Health Remaining {currentPlayer.MyHealth -= 1}");
                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Lots of moving air");
                    Console.WriteLine();
                }

                if (firstOpponent.OppHealth <= 0)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You knocked {firstOpponent.OppName} clean out!!!");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.ReadLine();
                    Console.WriteLine("Let's get you ready for the next fight!");

                    if (firstOpponent.OppName == "Nick")
                    {
                        firstOpponent = new Opponent("Adam", 1, 3);
                    }
                    else if (firstOpponent.OppName == "Adam")
                    {
                        firstOpponent = new Opponent("Michael", 1, 4);
                    }
                    else if (firstOpponent.OppName == "Michael")
                    {
                        firstOpponent = new Opponent("Jacob", 1, 5);
                    }
                    else if (firstOpponent.OppName == "Jacob")
                    {
                        firstOpponent = new Opponent("Andrew", 1, 6);
                    }
                    else if (firstOpponent.OppName == "Andrew")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Wow {currentPlayer.MyName}, you should consider yourself lucky to have gotten here! You've taken down EFA's toughest instructors! Congratulations on your victory! Go play the lottery or something because seriously, your luck is insane!");
                        Console.ResetColor();
                    }
                    else { }
                }

                else if (currentPlayer.MyHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{firstOpponent.OppName} gave you a run for your money! That was some nap you took {currentPlayer.MyName}. Better LUCK next time.");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine($"Stand up {currentPlayer.MyName}! He knocked you down but you're still in this fight!!");
                    Console.WriteLine();
                    Console.WriteLine("'Choose Start Fight To Continue'");
                    Console.ReadLine();
                }

                else { }
            }

            currentPlayer = new Player("", 1, 10);

        }

        public void Reset()
        {
            firstOpponent = new Opponent("Nick", 1, 3);
            currentPlayer = new Player("Kid", 1, 10);
        }



        public void Controls()
        {
            Console.Clear();
            Console.WriteLine("Alright champ, heres how you play!");
            Console.WriteLine();
            Console.WriteLine("[~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~]");
            Console.WriteLine("[                                                   ]");
            Console.WriteLine("[  (J)ab beats--->(H)ook beats--->(U)ppercut beats  ]");
            Console.WriteLine("[   ^                                      |        ]");
            Console.WriteLine("[   ^--------------------------------------/        ]");
            Console.WriteLine("[                                                   ]");
            Console.WriteLine("[~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~]");

            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Your (J)ab is quick and beats your opponents slow (H)ook.");
            Console.WriteLine("If they go for an (U)ppercut, try throwing a (H)ook, should catch them by suprise.");
            Console.WriteLine("They try to (J)ab you, slip it and hit them with a mean (U)ppercut, that will teach them.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }
        public void ViewOppnents()
        {
            Console.Clear();

            bool keepRunnnig = true;
            while (keepRunnnig)
            {
                Console.WriteLine("Select who you would like to view:\n" +
                    "1. Nick\n" +
                    "2. Adam\n" +
                    "3. Michael\n" +
                    "4. Jacob\n" +
                    "5. Andrew\n" +
                    "6. Back to Menu");

                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Nick -- Dont be underestimated by his silence, he's quick and smart in the ring. So choose your punches wisely! ");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Adam -- The power is in the beard");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Michael -- He may get distracted by the fence people, and his muddy dogs, but he studies his opponents and is good at getting the upper hand in the ring");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Jacob -- Be careful when fighting Jacob, he fights kinda dirty and plays tag team with his cat");
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Andrew -- He is the biggest star wars fan, we're pretty sure he's learned how to use the force and he definitely uses it in the ring");
                        Console.ReadLine();
                        break;
                    case "6":
                        keepRunnnig = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a correct option");
                        break;
                }
            }
        }
    }
}

