using System;

namespace lab01a_exceptionhandling
{
    class Program
    {
        // This method starts and ends the program.  
        // Catches any generic exceptions not handled by the rest of the methods.
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

        // This method provides the initial prompt for array size and controls the rest of the methods.  
        // This method also provides the Exception handling for all methods.
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
                Console.WriteLine("The sum of the array is {0}", sum);
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

        // This method gets the array values from the user and puts those values into the array
        static int[] Populate(int[] userArray)
        {
            string userInput;
            string output = "The numbers in the array are ";
            int userInputInt;

            Console.Write("The numbers in the array are ");

            for(int i = 0; i < userArray.Length; i++)
            {
                Console.WriteLine("Please enter number: {0} of {1}", i + 1, userArray.Length);
                userInput = Console.ReadLine();
                userInputInt = Convert.ToInt32(userInput);
                userArray[i] = userInputInt;

                if(i < userArray.Length - 1)
                {
                    output += userArray[i] + ", "; 
                }
                else
                {
                    output += userArray[i];
                }
            }

            Console.WriteLine("Your array is size: {0}", userArray.Length);
            Console.WriteLine(output);

            return userArray;
        }

        // This method sums up all the values of the array.  
        // Will throw exception if the sum is less than 20
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

        // This will get an array index from the user and multiply the sum by the value of the array at the chosen index.
        // This will throw an exception for any index out of range of the array.
        static int GetProduct(int[] userArray, int sum)
        {
            int product;
            string userInput;
            int userInputInt;
            int arrayNum;

            try
            {
                Console.WriteLine("Please select a random number between 1 and {0}", userArray.Length);
                userInput = Console.ReadLine();
                userInputInt = Convert.ToInt32(userInput);
                userInputInt--;
                arrayNum = userArray[userInputInt];
                product = arrayNum * sum;
                Console.WriteLine("{0} * {1} = {2}", sum, arrayNum, product);
                return product;
            }
            catch(IndexOutOfRangeException ioore)
            {
                throw ioore;
            }
        }

        // This method will take the product calculated from the getProduct function and divide it by a user given quotient.
        // This method will throw an Exception if user gives 0 for quotient.
        static decimal GetQuotient(int product)
        {
            decimal quotient;
            string userInput;
            decimal userInputDecimal;

            try
            {
                Console.WriteLine("Please enter a number to divide your product {0} by", product);
                userInput = Console.ReadLine();
                userInputDecimal = Convert.ToDecimal(userInput);
                quotient = decimal.Divide(product, userInputDecimal);
                Console.WriteLine("{0} / {1} = {2}", product, userInputDecimal, quotient);
                return quotient;
            }
            catch(DivideByZeroException dbze)
            {
                Console.WriteLine("Cannot divide by zero: {0}", dbze);
                return 0;
            }
        }
    }
}
