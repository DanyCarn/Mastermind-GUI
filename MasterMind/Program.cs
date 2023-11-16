using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    internal class Program
    {
        /// ETML
        /// Description : Jeu mastermind où la console génère un code aléatoire que l'utilisateur doit deviner grâce aux indices de la console, couleur bien placée ou pas au bon emplacement
        /// Auteur      : Dany Carneiro
        /// Date        : 01.09.2023
        static void Main(string[] args)
        {
            const int maxLetters = 4;
            const int maxTries = 11;
            char[] goal = new char[4];
            char[] guessArray = new char[4];
            char[] notOk = new char[4] {'_','_','_','_'};
            int tries;
            string guess = "";
            int ok = 0;
            int badPosition = 0;
            bool quit = false;
            bool goodLenght = false;
            string choice;
            int[] numberRandom = new int[4];
            string[] userInput = new string[10];
            bool easyMode = false;
            char [] easyDisplay = new char[4];
            do {
                //message de bienvenue + choix du mode
                easyMode = false;
                Console.Clear();
                Console.WriteLine("Bienvenue sur Mastermind!");
                Console.WriteLine("Choisissez votre mode de jeu");
                Console.WriteLine("1. Mode normal");
                Console.WriteLine("2. mode facile");
                Console.WriteLine("3. Quitter");
                choice = Console.ReadLine();
                //selon le choix de l'utilisateur, lance la fonction du mode correspondant
                switch(choice)
                {
                    case "1":
                        //si l'utilisateur choisi 1, le mode normal se lance
                        Play();
                        break;
                    case "2":
                        //si l'utilisateur choisi 2, le mode facile se met en true et les options du mode facile seront activées pour la partie
                        easyMode = true;
                        Play();
                        break;
                    case "3":
                        //si l'utilisateur choisi 3, le jeu s'arrête
                        quit = StopGame();
                        break;
                }
                Console.ReadLine();
            } while (quit == false);
            //mode facile
            void Play()
            {
                GenerateGoal();
                for(tries = 1; tries < maxTries; ++tries)
                {
                    AskGuess();
                    CompareGuessGoal();

                    //si les 4 lettres sont bonnes, le programme félicite le joueur et le rammène au menu
                    if (ok == maxLetters)
                    {
                        Console.WriteLine("Bravo !");
                        Console.WriteLine("Vous allez être rammené(e) sur le menu");
                        break;
                    }
                    //si tous les essais sont épuisée, la console révèle le code caché
                    else if (tries == maxTries)
                    {
                        Console.Write("Vous avez perdu, le code était ");
                        foreach (char item in goal)
                        {
                            Console.Write(item.ToString());
                            Console.WriteLine();

                            //La console informe le joeuur qu'il sera rammené au menu
                            Console.WriteLine("Vous allez être rammené(e) sur le menu");
                            Console.ReadLine();
                        }
                    }
                }
            }

            //Génère le code à trouver
            void GenerateGoal()
            {
                Console.Clear();
                Console.WriteLine("Couleurs possibles: GYWRBMC");
                Console.WriteLine("Devine le code en 4 couleurs. \n");

                //génère la suite à deviner aléatoirement
                Random random = new Random();
                for (int i = 0; i < maxLetters; i++)
                {
                    numberRandom[i] = random.Next(6);
                }

                //traduit le chiffre obtenu aléatoirement en lettre afin d'avoir la première, deuxième, troisième et quatrième position du code à deviner
                for (int i = 0; i < maxLetters; i++)
                {
                    SwitchGoalColors(numberRandom[i], i);
                }

            }

            //Demander l'essai au joueur
            void AskGuess()
            {
                //réinitialise les essais que le joueur a rentré aux parties précédentes
                for (int i = 0; i < maxTries - 1; i++)
                {
                    userInput[i] = " ";
                }

                //si le mode facile est activé, met à zero l'affichage d'aide
                if (easyMode == true)
                {
                    for (int i = 0; i < maxLetters; ++i)
                        easyDisplay[i] = '_';
                }
                do
                {

                    //vérifie que ce que l'utilisateur rentre fasse la bonne longueur. Si non, demande à l'utilisateur de re-rentrer un essai
                    goodLenght = false;

                    //empêche le joueur de rentrer deux fois le même essai si le mode facile est activé. Sinon, enregistre simplement ce que le joueur a rentré.
                    do
                    {
                        Console.Write("Essai " + tries + ": ");
                        guess = Console.ReadLine();

                        if (easyMode == true)
                        {
                            if (userInput.Contains(guess))
                            {
                                Console.WriteLine("Vous déja essayé cette combinaison. Rentrez-en une autre.");
                            }
                        }
                    } while (userInput.Contains(guess));

                    if (easyMode == true)
                    {
                        userInput[tries - 1] = guess;
                    }

                    if (guess.Length == guessArray.Length)
                        goodLenght = true;
                    else
                    {
                        Console.WriteLine("Votre essai doit faire 4 charactères");
                    }

                } while (goodLenght == false);

                guessArray = guess.ToCharArray();
                ok = 0;
                badPosition = 0;
            }

            //Comparer l'essai au code à trouver et afficher le résultat
            void CompareGuessGoal()
            {
                //La console compare l'essai de l'utilisateur et le code généré aléatoirement. Si une lettre est au bon emplacement, il la rajoute dans l'affichage si le mode facile est activé.
                for (int i = 0; i < maxLetters; i++)
                {
                    notOk[i] = '_';
                }
                for (int i = 0; i < maxLetters; i++)
                {
                    if (guessArray[i] == goal[i])
                    {
                        ok++;
                        if (easyMode == true)
                        {
                            easyDisplay[i] = goal[i];
                        }
                    }
                    else
                    {
                        for (int j = 0; j < goal.Length; j++)
                        {
                            if (goal[j] == guessArray[i])
                            {
                                if (goal[j] != guessArray[j])
                                {
                                    notOk[i] = guessArray[i];
                                }
                                else
                                {
                                    notOk[i] = '_';
                                }
                            }
                        }
                    }
                }

                //place un $ si la couleur est mal placée si le mode facile est activé
                if (easyMode == true)
                {
                    for (int i = 0; i < maxLetters; i++)
                    {
                        if (notOk[i] != '_' && goal[i] != '_')
                        {
                            badPosition++;
                            easyDisplay[i] = '$';
                        }
                    }
                }
                else if (easyMode == false)
                {
                    for (int i = 0; i < maxLetters; i++)
                    {
                        if (i != '_')
                        {
                            if (notOk[i] != '_')
                            {
                                badPosition++;
                            }
                        }

                    }
                }

                //si le mode facile est activé, affiche l'aide 
                if (easyMode == true)
                {
                    Console.Write("Réponse [$=bonne couleur]: ");
                    for (int i = 0; i < 4; i++)
                    {
                        switch (easyDisplay[i])
                        {
                            case 'G':
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(easyDisplay[i]);
                                Console.ResetColor();
                                break;
                            case 'Y':
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(easyDisplay[i]);
                                Console.ResetColor();
                                break;
                            case 'W':
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(easyDisplay[i]);
                                Console.ResetColor();
                                break;
                            case 'R':
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(easyDisplay[i]);
                                Console.ResetColor();
                                break;
                            case 'B':
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(easyDisplay[i]);
                                Console.ResetColor();
                                break;
                            case 'M':
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.Write(easyDisplay[i]);
                                Console.ResetColor();
                                break;
                            case 'C':
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(easyDisplay[i]);
                                Console.ResetColor();
                                break;
                            case '$':
                                switch (notOk[i])
                                {
                                    case 'G':
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write(easyDisplay[i]);
                                        Console.ResetColor();
                                        break;
                                    case 'Y':
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write(easyDisplay[i]);
                                        Console.ResetColor();
                                        break;
                                    case 'W':
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(easyDisplay[i]);
                                        Console.ResetColor();
                                        break;
                                    case 'R':
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(easyDisplay[i]);
                                        Console.ResetColor();
                                        break;
                                    case 'B':
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write(easyDisplay[i]);
                                        Console.ResetColor();
                                        break;
                                    case 'M':
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.Write(easyDisplay[i]);
                                        Console.ResetColor();
                                        break;
                                    case 'C':
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write(easyDisplay[i]);
                                        Console.ResetColor();
                                        break;
                                }
                                break;
                            case '_':
                                Console.Write(easyDisplay[i]);
                                break;
                        }
                    }
                    Console.WriteLine("\n");
                }

                else if (easyMode == false)
                {
                    Console.WriteLine("=>Ok: " + ok);
                    Console.WriteLine("=>Mauvaise position: " + badPosition + "\n");
                }
            }

            //arrêter le jeu
            bool StopGame()
            {
                return true;
            }

            //attribuer les lettres pour le code secret
            void SwitchGoalColors(int number, int numberPlace)
            {
                for(int i = 0; i < 4; i++)
                switch (number)
                {
                    case 0:
                        goal[numberPlace] = 'C';
                        break;
                    case 1:
                        goal[numberPlace] = 'G';
                        break;
                    case 2:
                        goal[numberPlace] = 'Y';
                        break;
                    case 3:
                        goal[numberPlace] = 'W';
                        break;
                    case 4:
                        goal[numberPlace] = 'R';
                        break;
                    case 5:
                        goal[numberPlace] = 'B';
                        break;
                    case 6:
                        goal[numberPlace] = 'M';
                        break;
                }

            }
        }
    }
}
