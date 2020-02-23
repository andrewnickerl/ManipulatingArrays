using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulatingArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayA = { 0, 2, 4, 6, 8, 10 };
            int[] arrayB = { 1, 3, 5, 7, 9 };
            int[] arrayC = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };

            Console.WriteLine("Which array manipulation would you like to perform?");
            Console.WriteLine("1.) Find the means of the elements in the arrays");
            Console.WriteLine("2.) Reverse the arrays");
            Console.WriteLine("3.) Rotate the arrays");
            Console.WriteLine("4.) Sort ArrayC");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            switch(choice)
            {
                case 1:
                    PrintMean();
                    break;
                case 2:
                    PrintReverse();
                    break;
                case 3:
                    PrintRotate();
                    break;
                case 4:
                    PrintSort();
                    break;
            }

            void PrintMean()
            {
                Console.WriteLine($"The mean of ArrayA is {Mean(arrayA)}.");
                Console.WriteLine($"The mean of ArrayB is {Mean(arrayB)}.");
                Console.WriteLine($"The mean of ArrayC is {Mean(arrayC)}.");
            }
            void PrintReverse()
            {
                Console.Write("The reverse of ArrayA is: ");
                foreach (int num in Reverse(arrayA))
                {
                    Console.Write($"{num}, ");
                }
                Console.Write("\nThe reverse of ArrayB is: ");
                foreach (int num in Reverse(arrayB))
                {
                    Console.Write($"{num}, ");
                }
                Console.Write("\nThe reverse of ArrayC is: ");
                foreach (int num in Reverse(arrayC))
                {
                    Console.Write($"{num}, ");
                }
            }
            void PrintRotate()
            {
                Console.Write("\nThe rotation of ArrayA two places to the right is: ");
                foreach (int num in Rotate("left", 2, arrayA))
                {
                    Console.Write($"{num}, ");
                }
                Console.Write("\nThe rotation of ArrayB two places to the left is: ");
                foreach (int num in Rotate("right", 2, arrayB))
                {
                    Console.Write($"{num}, ");
                }
                Console.Write("\nThe rotation of ArrayC four places to the left is: ");
                foreach (int num in Rotate("left", 4, arrayC))
                {
                    Console.Write($"{num}, ");
                }
            }
            void PrintSort()
            {
                Console.Write("\nArrayC sorted by ascending order: ");
                foreach (int num in Sort(arrayC))
                {
                    Console.Write($"{num}, ");
                }
            }
            Console.ReadKey();
        }

        static double Mean(int[] numbers)
        {
            int count = numbers.Length;
            double sum = 0;
            double mean;

            foreach (int num in numbers)
            {
                sum += num;
            }

            mean = sum / count;

            return mean;
        }

        static int[] Reverse(int[] numbers)
        {
            for (int i = 0; i < numbers.Length / 2; i++)
            {
                int save = numbers[i];
                numbers[i] = numbers[numbers.Length - 1 - i];
                numbers[numbers.Length - 1 - i] = save;
            }
            return numbers;
        }

        static int[] Rotate(string direction, int numPlaces, int[] numbers)
        {
            int[] rotatedArray = new int[numbers.Length];
            
            if (direction.ToLower() == "right")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    int save = numbers[i];
                    if(i + numPlaces < rotatedArray.Length)
                    {
                        rotatedArray[i + numPlaces] = save;
                    }
                    else
                    {
                        rotatedArray[(i + numPlaces) - rotatedArray.Length] = save;
                    }
                  
                }
            }
            else if (direction.ToLower() == "left")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    int save = numbers[i];
                    if (i - numPlaces > rotatedArray.Length)
                    {
                        numbers[i - numPlaces] = save;
                    }
                    else
                    {
                        rotatedArray[rotatedArray.Length - i - 1] = save;
                    }
                }
            }
            else
            {
                Console.WriteLine("Please input right or left for direction.");
                return null;
            }

            return rotatedArray;
        }

        static int[] Sort(int[] numbers)
        {
            for(int i = 0; i < numbers.Length - 1; i++)
            {
                for(int j = i + 1; j < numbers.Length; j++)
                {
                    if(numbers[i]> numbers[j])
                    {
                        int save = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = save;
                    }
                }
            }
            return numbers;
        }
    }
}
