using System;

namespace Numbers_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Hello Mr.User :) it appears that you did something wrong, please read the questions carefully and try again");
                Console.WriteLine($"This was the details of the error you caused: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Program is complete.");
            }

            
        }

        static void StartSequence()
        {

            try
            {
                //promt use to enter a number greater than zero
                //use convert.Toint32 to convert the input from string to int

                Console.WriteLine("Please input a number greater than zero,");
                int userInput = Convert.ToInt32(Console.ReadLine());

                //create a new int array with length of the same integer added
                int[] myArrayEmpty = new int[userInput];


                //call this function to populate the empty array
                //Populate(myArrayEmpty);

                //my returned array with filled data
                int[] myArrayFull = Populate(myArrayEmpty);

                //capture the following functions
                int returnedSum = GetSum(myArrayFull);
                //Console.WriteLine($"Your array sum is {returnedSum}");

                int returnedProduct = GetProduct(myArrayFull, returnedSum);
                //Console.WriteLine($"Your returned product is {returnedProduct}");

                //int instructions it says that we pass integer product?
                decimal returnedQuotient = GetQuotient(returnedProduct);

                #region Last step!
                //This is the last step to show the user his data and all the values
                //output array size
                Console.WriteLine($"Your array size is {myArrayEmpty.Length}");

                //Print out the array
                Console.WriteLine("The numbers in the array are: ");
                for (int i = 0; i < myArrayFull.Length; i++)
                {
                    Console.Write(myArrayFull[i]);
                }

                //print the sum of the array
                Console.WriteLine($"The sum of the array is {returnedSum}");

                //
                Console.WriteLine($"{returnedSum} * {myArrayFull[4]} = {returnedProduct}");
                Console.WriteLine($"{returnedProduct} /54 = {returnedQuotient}");

                #endregion
            }
            catch (FormatException formatE)
            {
                Console.WriteLine($"{formatE.Message}");                
            }
            catch (OverflowException overflowE)
            {
                Console.WriteLine($"{overflowE.Message}");
            }



        }

        static int[] Populate(int[] x)
        {
            int[] populatedArray = x;

            for (int i = 0; i < populatedArray.Length; i++)
            {
                Console.WriteLine($"Please input number {i+1} / {populatedArray.Length}");
                string inputtedNumber = Console.ReadLine();
                populatedArray[i] = Convert.ToInt32(inputtedNumber);
            }


            return populatedArray;
        }


        static int GetSum(int[] arr)
        {
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }

            return sum;
        }

        static int GetProduct(int[] arr, int sum)
        {

            try
            {
                int mySum = sum;
                Console.WriteLine($"Please input a number between 1 & {arr.Length}");
                int inputtedRandomNumber = Convert.ToInt32(Console.ReadLine());

                //we used -1 because the index of the fifth item is 4 since array starts from 0
                int product = mySum * arr[(inputtedRandomNumber - 1)];

                return product;
            }
            catch (IndexOutOfRangeException indexE)
            {
                Console.WriteLine(indexE.Message);
                throw;
            }

        }

        //this functions takes the result of GetProduct function, and divide it by a random number inputted by the user
        static decimal GetQuotient(int passedProduct)
        {

            try
            {
                int product = passedProduct;
                Console.WriteLine($"Enter a number to divide the product {product} by");
                decimal numberToDivideBy = Convert.ToDecimal(Console.ReadLine());

                decimal quotient = decimal.Divide(product, numberToDivideBy);

                return quotient;
            }
            catch (DivideByZeroException divideByZeroE)
            {
                Console.WriteLine(divideByZeroE.Message);

                //Our instructor didn't discuss throw with us and said we will be discussing it in the upcoming days

                return 0;
            }

        }

    }
}
