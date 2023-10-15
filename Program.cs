namespace Dice_Roller_Lab
{
    internal class Program
    {
        static void Main(string[] args) // this is the default function/method
        {
            Console.WriteLine("Welcome to the Grand Circus Casino!");
            Console.WriteLine("How many sides should each die have?");
            int diceSides = int.Parse(Console.ReadLine());

                        
            if(diceSides == 6)
            {
                string rollAgain;
                int numRolls = 1;

                do
                {
                    Console.WriteLine($"Roll {numRolls}: ");

                    int diceRoll1 = DiceRoll(diceSides);
                    int diceRoll2 = DiceRoll(diceSides);
                    int totalRoll = diceRoll1 + diceRoll2;

                    Console.WriteLine($"You rolled a {diceRoll1} and a {diceRoll2} ({totalRoll} total).");


                    string comboMsg = DiceRollComboCheck(diceRoll1, diceRoll2);

                    if( comboMsg != "")
                    {
                        Console.WriteLine(comboMsg);
                    }
                    
                    string winMsg = DiceRollWinCheck(diceRoll1, diceRoll2);

                    if (winMsg != "")
                    {
                        Console.WriteLine(winMsg);
                    }


                    Console.WriteLine("Would you like to roll again? (yes/no)");
                    rollAgain = Console.ReadLine();

                    if (rollAgain.ToLower() == "no")
                    {
                        Console.WriteLine("Goodbye!");
                    }
                    numRolls++;
                }
                while (rollAgain.ToLower() == "yes");
            }         
            
        }

        static string DiceRollComboCheck(int diceRoll1, int diceRoll2) // this method checks the dice rolls for 3 variations
        {
            if (diceRoll1 == 1 && diceRoll2 == 1)
            {
                return "Snake Eyes: Two 1s";
            }
            else if ((diceRoll1 == 2 && diceRoll2 == 1) || (diceRoll1 == 1 && diceRoll2 == 2))
            {
                return "Ace Duece: A 1 and 2";
            }
            else if (diceRoll1 == 6 && diceRoll2 == 6)
            {
                return "Box Cars: two 6s";
            }
            return "";
        }

        static string DiceRollWinCheck(int diceRoll1, int diceRoll2) // this method checks for a win or craps dice variations
        {
            int totalRoll = diceRoll1 + diceRoll2;

            if (totalRoll == 7 || totalRoll == 11)
            {
                return "Win! A total of 7 or 11";
            }
            else if (totalRoll == 2 || totalRoll == 3 || totalRoll == 12)
            {
                return "Craps: A total of 2,3, or 12";
            }
            return "";
        }

        static int DiceRoll(int numSides) // this method is checking how many sides the user enters 
        {
            Random rollDice = new Random(); // creates a new random
            return rollDice.Next(1, numSides);   
        }
        

    }
}