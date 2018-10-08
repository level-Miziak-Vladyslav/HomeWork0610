using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkATM3009
{
    //this program is not optimized

    class Program
    {
        #region Main
        private static void Main(string[] args)
        {
            int keypress;
            int[,] matrix;
            int[,] matrix0;
            try
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter task number");
                    Console.WriteLine("1 for column summary");
                    Console.WriteLine("2 for 10x10 matrix");
                    Console.WriteLine("3 for even odd");
                    Console.WriteLine("4 for quad");
                    Console.WriteLine("5 for ATM"); //automated teller machine
                    Console.WriteLine("or 0 for exit");
                    Console.WriteLine();

                    keypress = int.Parse(Console.ReadLine()); // read keystrokes

                    //                    Console.WriteLine(" Your key is: " + keypress);
                    if (keypress == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter a (по условию 5)");
                        int a = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter b (по условию 5)");
                        int b = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter MaxRand (по условию 9)");
                        int c = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        matrix = GenerateMatrix(a, b, ref c);
                        DrawMatrix(matrix);
                        DrawSummary(matrix);
                    }
                    if (keypress == 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter a (по условию 10)");
                        int a = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter b (по условию 10)");
                        int b = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter MaxRand (по условию 9)");
                        int c = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        matrix = GenerateMatrix(a, b, ref c);
                        DrawMatrix(matrix);
                        DrawMin(matrix, c);
                    }
                    if (keypress == 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Arr 2 x = (по условию 2)");
                        int b = int.Parse(Console.ReadLine());
                        Console.WriteLine("Arr 2 y = (по условию 3)");
                        int c = int.Parse(Console.ReadLine());
                        Console.WriteLine("Arr 1 x = (по условию 5)");
                        int a = int.Parse(Console.ReadLine());
                        Console.WriteLine("MaxRan = (по условию 9)");
                        int d = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        matrix = GenerateMatrix(b, c, ref d);
                        matrix0 = GenerateMatrix(a, 1, ref d);
                        DrawMatrix(matrix);
                        EvenOdd(matrix);
                        DrawMatrix(matrix0);
                        EvenOdd(matrix0);
                    }
                    if (keypress == 4)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter a");
                        int a = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter b");
                        int b = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter c");
                        Console.WriteLine();
                        int c = int.Parse(Console.ReadLine());
                        Equation E = new Equation(a, b, c);
                        E.Quad();
                    }
                    if (keypress == 5)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Automated teller machine");
                        Console.WriteLine();
                        ATM A = new ATM();
                        A.MainRun();
                    }


                    //                    throw new Exception("new try");
                    //                    Console.WriteLine();
                    //                    Console.WriteLine("Press 0 to exit or 1,2,3,4,5 for new task");

                } while (keypress != 0);


            }
            catch (Exception exc)
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка поймана" + exc);
                Console.WriteLine();
            }
        }
        #endregion
        #region GenerateMatrix
        public static int[,] GenerateMatrix(int x, int y, ref int maxRandom)
        {
            int[,] matrix = new int[x, y];
            Random rnd = new Random();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = rnd.Next(0, maxRandom);
                }
            }
            return matrix;
        }
        #endregion
        #region DrawMatrix
        public static void DrawMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{(matrix[i, j].ToString().Length < 2 ? matrix[i, j].ToString() + "  |" : matrix[i, j].ToString() + " |")}");
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region EvenOdd
        public static void EvenOdd(int[,] matrix)
        {
            int ctev = 0;
            int ctod = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] % 2 == 0) ctev = ctev + matrix[i, j];
                    else ctod = ctod + matrix[i, j];
                }
            }
            Console.WriteLine();
            Console.WriteLine("Even count = " + ctev + "     Odd count = " + ctod);
            Console.WriteLine();
        }
        #endregion
        #region DrawSummary
        public static void DrawSummary(int[,] matrix)
        {
            int Max = 0;
            int Num = 0;
            int Num1 = 10;
            int[,] Bot = new int[2, matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int Sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Sum = Sum + matrix[j, i];
                }
                Bot[0, i] = Sum;
                Bot[1, i] = i;
                Console.WriteLine();
                Console.WriteLine("sum in column # " + Bot[1, i] + "  " + Bot[0, i]);
                Console.WriteLine();
            }
            for (int i = 0; i < Bot.GetLength(1); i++)
            {
                if (Bot[0, i] > Max)
                {

                    Num = Bot[1, i];
                    Max = Bot[0, i];
                }
                if (Bot[0, i] == Max)
                {
                    Num1 = Bot[1, i];
                }

            }
            if (Bot[1, Num] == Bot[1, Num1]) Console.WriteLine("Max sum in column # " + (Num + 1));
            else Console.WriteLine("Max sum in two columns # " + (Num + 1) + " and " + (Num1 + 1));

            Console.WriteLine();
        }
        #endregion
        #region DrawMin
        public static void DrawMin(int[,] matrix, int z)
        {
            int[,] Sum; //0 znach 1 x 2 y
            Sum = new int[10, 3];
            int ct = 0;
            for (int q = 0; q < z; q++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == q)
                        {
                            if (ct > 9) break;
                            //                                Console.WriteLine("i" + i + "j" + j + "q" + q + "ct" + ct);
                            Sum[ct, 0] = q;
                            Sum[ct, 1] = i + 1;
                            Sum[ct, 2] = j + 1;
                            ct++;
                        }
                    }
                }

            }
            DrawMatrix(Sum);
        }
        #endregion
    }
    #region Equation
    public class Equation
    {
        int d, a, b, c;

        public Equation(int a1, int b1, int c1)
        {
            a = a1;
            b = b1;
            c = c1;
            d = b * b - 4 * a * c;
            Console.WriteLine();
            Console.WriteLine("данные загружены, дискриминант =" + d);
        }
        public void Quad()
        {
            while (true)
            {
                if (d < 0)
                {
                    Console.WriteLine("не имеет корней");
                    Console.WriteLine();
                    break;
                }
                if (d == 0)
                {
                    Console.WriteLine("имеет один корень =" + (-b) / (2 * a));
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("первый корень =" + (-b + Math.Sqrt(d)) / (2 * a));
                    Console.WriteLine("второй корень =" + (-b - Math.Sqrt(d)) / (2 * a));
                    Console.WriteLine();
                    break;
                }
            }
        }

    }
    #endregion
    #region FailSoftArray
    class FailSoftArray
    {
        User[] a;
        public int Length;
        public bool ErrFlag;
        public FailSoftArray(int size)
        {
            a = new User[size];
            Length = size;
        }
        public User this[int index]
        {
            get
            {
                //                if (ok(index))
                {
                    ErrFlag = false;
                    return a[index];
                }
                //                else
                {
                    //                    ErrFlag = true;
                    //return ;
                }
            }
            set
            {
                if (ok(index))
                {
                    a[index] = value;
                    ErrFlag = false;
                }
                else ErrFlag = true;
            }
        }
        private bool ok(int index)
        {
            if (index >= 0 & index < Length) return true;
            return false;
        }
    }
    #endregion
    #region User

    public struct User
    {
        public string Login
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public bool Isadmin
        {
            get;
            set;
        }
        public double Account
        {
            get;
            set;
        }
        public bool Isblocked
        {
            get;
            set;
        }
        public int CountBadTry
        {
            get;
            set;
        }
        public bool IsFirst
        {
            get;
            set;
        }

    }
    #endregion
    #region ATM main
    public class ATM
    {
        int keypress;
        string NameCurrentUser;
        FailSoftArray F = new FailSoftArray(100);
        int NumberOfUsers = 0;
        public void MainRun()
        {
            Console.WriteLine();
            Console.WriteLine("Please input User Name or 0 to exit");
            NameCurrentUser = (Console.ReadLine().ToString());
            if (NameCurrentUser == "Admin")
            {
                Console.WriteLine();
                Console.WriteLine("Please input Password");
                string a = (Console.ReadLine().ToString());
                if (a == "Admin")
                {
                    Console.WriteLine();
                    Console.WriteLine("login {0} successful", a);
                    User User = new User();
                    User.Login = "Admin";
                    User.Password = "Admin";
                    User.Account = 0;
                    User.Isadmin = true;
                    User.Isblocked = false;
                    User.IsFirst = false;
                    F[0] = User;
                    NumberOfUsers = 1;
                    WorkAdmin();
                    Console.WriteLine("User {0} logged out", NameCurrentUser);
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please input Login or 0 to exit");
                        keypress = 1;
                        string l = (Console.ReadLine().ToString());
                        if (l == 0.ToString())
                        {
                            keypress = 0;
                        }
                        User UU = new User();
                        for (int i = 0; i < NumberOfUsers; i++)
                        {
                            UU = (F[i]);
                            if (UU.Login == l)
                            {
                                if (UU.Isblocked != true)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Please input Password");
                                    string p = (Console.ReadLine().ToString());
                                    if (p == UU.Password)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("login {0} successful", l);
                                        if (p == "Admin")
                                        {
                                            NameCurrentUser = "Admin";
                                            WorkAdmin();
                                            Console.WriteLine("User {0} logged out. 0 - to exit / 1 to Login", NameCurrentUser);
                                            Console.WriteLine();
                                            keypress = int.Parse(Console.ReadLine());
                                        }
                                        else
                                        {
                                            if (UU.IsFirst == true)
                                            {
                                                Console.WriteLine("You need to change your password, please enter new password:");
                                                string aa = (Console.ReadLine().ToString());
                                                UU.Password = aa;
                                                UU.IsFirst = false;
                                                (F[i]) = UU;

                                            }
                                            NameCurrentUser = l;
                                            WorkUser();
                                            Console.WriteLine("User {0} logged out. 0 - to exit / 1 to Login", NameCurrentUser);
                                            Console.WriteLine();
                                            keypress = int.Parse(Console.ReadLine());
                                        }
                                    }
                                    else
                                    {
                                        if (p != "Admin")
                                        {
                                            Console.WriteLine("login unsuccessful, please try again");
                                            UU.CountBadTry++;
                                            if ((UU.CountBadTry > 2) && (UU.Isadmin != true))
                                            {
                                                Console.WriteLine("user {0} is blocked, please contact the administrator", UU.Login);
                                                UU.Isblocked = true;
                                            }
                                            F[i] = UU;
                                        }
                                        Console.WriteLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("user {0} is blocked, please contact the administrator", UU.Login);
                                }
                            }
                            else if ((i == NumberOfUsers - 1) && (l != "Admin"))
                            {
                                Console.WriteLine("login {0} does not exist in the database", l);
                            }
                        }
                    } while (keypress != 0);
                    Console.WriteLine("return to main menu");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("login unsuccessful return to main menu");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Login incorrect, return to main menu");
                Console.WriteLine();
            }
        }
        #endregion
        #region WorkAdmin
        void WorkAdmin()
        {
            int keypress;
            Console.WriteLine();
            try
            {
                do
                {
                    Console.WriteLine("Enter 1 for list of users");
                    Console.WriteLine("Enter 2 to add new user");
                    Console.WriteLine("Enter 3 to remove existing user");
                    Console.WriteLine("Enter 4 to deblock existing user");
                    Console.WriteLine("Enter 0 to log out");
                    Console.WriteLine();
                    keypress = int.Parse(Console.ReadLine()); // read keystrokes
                    if (keypress == 1)
                    {
                        User Us = new User();
                        Console.WriteLine("list of existing users");
                        for (int i = 0; i < NumberOfUsers; i++)
                        {
                            Us = (F[i]);
                            Console.WriteLine("User name: {0}; password: {1}; account: {2}; user is blocked: {3}; CountBadTry: {4}", Us.Login, Us.Password, Us.Account, Us.Isblocked, Us.CountBadTry);
                        }
                        Console.WriteLine();
                    }
                    if (keypress == 2)
                    {
                        Console.WriteLine("Add new user");
                        User User = new User();
                        Console.WriteLine("Please input user name");
                        string a = (Console.ReadLine().ToString());
                        bool BadName = false;
                        for (int i = 0; i < NumberOfUsers; i++)
                        {
                            User U = new User();
                            U = (F[i]);
                            if (U.Login == a)
                            {
                                Console.WriteLine("user name {0} exists, operation canceled", U.Login);
                                Console.WriteLine();
                                BadName = true;
                            }

                        }
                        if (BadName == false)
                        {
                            User.Login = a;
                            User.Password = a;
                            User.Account = 100;
                            User.Isadmin = false;
                            User.Isblocked = false;
                            User.IsFirst = true;
                            F[NumberOfUsers] = User;
                            User = F[NumberOfUsers];
                            NumberOfUsers++;
                            Console.WriteLine();
                            Console.WriteLine("User {0} was added", a);
                            Console.WriteLine();
                        }
                        else
                        {
                            keypress = 2;
                        }
                    }
                    if (keypress == 3)
                    {
                        Console.WriteLine("remove existing user");
                        for (int i = 0; i < NumberOfUsers; i++)
                        {
                            User U = new User();
                            U = (User)(F[i]);
                            Console.WriteLine("User name: {0}; user password: {1}; user account: {2}; user is blocked: {3}", U.Login, U.Password, U.Account, U.Isblocked);
                        }
                        Console.WriteLine("Please input the user name");
                        string a = (Console.ReadLine().ToString());
                        for (int i = 0; i < NumberOfUsers; i++)
                        {
                            User U = new User();
                            U = (User)(F[i]);
                            if (U.Login == a)
                            {
                                U.Isblocked = true;
                                F[i] = U;
                                Console.WriteLine("User : {0} was blocked", U.Login);
                                Console.WriteLine();
                            }
                        }
                    }
                    if (keypress == 4)
                    {
                        Console.WriteLine("deblock existing user");
                        for (int i = 0; i < NumberOfUsers; i++)
                        {
                            User U = new User();
                            U = (User)(F[i]);
                            Console.WriteLine("User name: {0}; user password: {1}; user account: {2}; user is blocked: {3}", U.Login, U.Password, U.Account, U.Isblocked);
                        }
                        Console.WriteLine("Please input the user name");
                        string a = (Console.ReadLine().ToString());
                        for (int i = 0; i < NumberOfUsers; i++)
                        {
                            User U = new User();
                            U = F[i];
                            if (U.Login == a)
                            {
                                U.Isblocked = false;
                                U.CountBadTry = 0;
                                F[i] = U;
                                Console.WriteLine("User : {0} was deblocked", U.Login);
                                Console.WriteLine();
                            }
                        }
                    }
                    //                    throw new Exception("new try");

                } while (keypress != 0);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Ошибка поймана" + exc);
            }
        }
        #endregion
        #region WorkUser
        void WorkUser()
        {
            int keypress;
            try
            {
                User Us = new User();
                Us.CountBadTry = 0;
                for (int i = 0; i < NumberOfUsers; i++)
                {
                    Us = (F[i]);
                    if (Us.Login == NameCurrentUser)
                    {
                        do
                        {
                            Console.WriteLine("Enter 1 for view account balance");
                            Console.WriteLine("Enter 2 to cashing out");
                            Console.WriteLine("Enter 3 to add funds");
                            Console.WriteLine("Enter 0 to log out");
                            keypress = int.Parse(Console.ReadLine()); // read keystrokes
                            if (keypress == 1)
                            {
                                Console.WriteLine("view account balance");
                                Console.WriteLine("User name: {0}; account balance: {1}", Us.Login, Us.Account);
                                Console.WriteLine();
                            }
                            if (keypress == 2)
                            {
                                Console.WriteLine("cashing out");
                                Console.WriteLine("Please input amount for cashing out");
                                Double a = double.Parse(Console.ReadLine());
                                if (Us.Account >= a)
                                {
                                    Us.Account = Us.Account - a;
                                }
                                else
                                {
                                    Console.WriteLine("User {0} does not have enough funds in the account", Us.Login);
                                    Console.WriteLine();
                                }
                                Console.WriteLine("User name: {0}; account balance: {1}", Us.Login, Us.Account);
                                Console.WriteLine();
                            }
                            if (keypress == 3)
                            {
                                Console.WriteLine("add funds");
                                Console.WriteLine("Please input amount of deposit");
                                Double a = double.Parse(Console.ReadLine());
                                Us.Account = Us.Account + a;
                                F[i] = Us;
                                Console.WriteLine("User name: {0}; account balance: {1}", Us.Login, Us.Account);
                                Console.WriteLine();
                            }
                            //                                        throw new Exception("new try");
                        } while (keypress != 0);
                    }
                    F[i] = Us;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Ошибка поймана" + exc);
            }
        }
        #endregion
    }
}

