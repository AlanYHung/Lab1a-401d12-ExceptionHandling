using System;

namespace lab01a_exceptionhandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong...{0}", e);
            }
            finally
            {
                Console.WriteLine("Program is complete.");
            }
        }

        static void StartSequence()
        {
            string userInput;
            int userInputInt;
            int sum;
            int product;
            decimal quotient;

            try
            {
                Console.WriteLine("Welcome to my game! Let's do some math!");
                Console.WriteLine("Please enter a number greater than zero");
                userInput = Console.ReadLine();
                userInputInt = Convert.ToInt32(userInput);
                int[] userArray = new int[userInputInt];
                userArray = Populate(userArray);
                sum = GetSum(userArray);
                product = GetProduct(userArray, sum);
                quotient = GetQuotient(product);
            }
            catch(FormatException fe)
            {
                Console.WriteLine("You entered an incorrect format: {0}", fe);
            }
            catch(OverflowException oe)
            {
                Console.WriteLine("There was an Overflow Error: {0}", oe);
            }
        }

        static int[] Populate(int[] userArray)
        {
            string userInput;
            int userInputInt;

            for(int i = 0; i < userArray.Length; i++)
            {
                Console.WriteLine("Please enter number: {0} of {1}", i + 1, userArray.Length);
                userInput = Console.ReadLine();
                userInputInt = Convert.ToInt32(userInput);
                userArray[i] = userInputInt;
            }

            return userArray;
        }

        static int GetSum(int[] userArray)
        {
            int sum = 0;

            for(int i = 0; i < userArray.Length; i++)
            {
                sum += userArray[i];
            }

            if(sum < 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }

            return sum;
        }

        static int GetProduct(int[] userArray, int sum)
        {
            int product;
            string userInput;
            int userInputInt;

            try
            {
                Console.WriteLine("Please select a random number between 1 and {}", userArray.Length);
                userInput = Console.ReadLine();
                userInputInt = Convert.ToInt32(userInput);
                product = userArray[userInputInt - 1] * sum;
                return product;
            }
            catch(IndexOutOfRangeException ioore)
            {
                throw ioore;
            }
        }

        static decimal GetQuotient(int product)
        {
            return 0;
        }
    }
}
