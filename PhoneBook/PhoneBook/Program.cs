using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {
        public static string[,] matrix = new string[100, 2];
        public static int LastIndexOf = 0;
        private static void Main()
        {
            int keypress;
            try
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter task number");
                    Console.WriteLine("1 to add new phone number");
                    Console.WriteLine("2 for print list");
                    Console.WriteLine("3 to remove existing name or user by string equal");
                    Console.WriteLine("4 for quit");
                    Console.WriteLine();

                    keypress = int.Parse(Console.ReadLine()); // read keystrokes

                    //                    Console.WriteLine(" Your key is: " + keypress);
                    if (keypress == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter full name");
                        string a = Console.ReadLine();
                        Console.WriteLine("Enter phone number");
                        string b = Console.ReadLine();
                        matrix = AddNewNumber(a, b, matrix);
                        Console.WriteLine("Do you want add user?");
                        Console.WriteLine("1 for Yes 0 for No");

                    }
                    if (keypress == 2)
                    {
                        DrawMatrix(matrix);
                    }
                    if (keypress == 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter phone number or full name to remove");
                        string b = Console.ReadLine();
                        matrix = DelNumber(b, matrix);
                    }

                } while (keypress != 4);
                Console.WriteLine("Phonebook is closed");
            }
            catch (Exception exc)
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка поймана" + exc);
                Console.WriteLine();
            }
        }
        public static string[,] AddNewNumber(string a, string b, string[,] m)
        {
            m[LastIndexOf, 0] = a;
            m[LastIndexOf, 1] = b;
            LastIndexOf++;
            return m;
        }
        public static void DrawMatrix(string[,] matrix)
        {
            for (int i = 0; i < LastIndexOf; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"{(matrix[i, j].ToString().Length < 2 ? matrix[i, j].ToString() + "  |" : matrix[i, j].ToString() + " |")}");
                }
                Console.WriteLine();
            }
        }
        public static string[,] DelNumber(string b, string[,] m)
        {
            for (int i = 0; i < LastIndexOf; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (m[i,j] == b)
                    {
                        Console.WriteLine("Catch");
                        for (int z = i; z < LastIndexOf; z++)
                        {
                            m[z, 0] = m[z + 1,0];
                            m[z, 1] = m[z + 1,1];
                        }
                    }
                }
                Console.WriteLine();
            }

            LastIndexOf--;
            return m;
        }
    }
}



