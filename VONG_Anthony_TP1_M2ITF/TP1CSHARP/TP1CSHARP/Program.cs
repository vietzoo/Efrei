using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1CSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            int check;
            Console.WriteLine("Veuillez insérer le numéro d'exercice que vous souhaitez regarder ! \n");
            Console.WriteLine("1.Multiplications Tables\n");
            Console.WriteLine("2.More Math\n");
            Console.WriteLine("3.Try/Catch\n");
            Console.WriteLine("4.Square\n");
            Console.WriteLine("5.Christmas Tree\n");
            check = int.Parse(Console.ReadLine());
            switch (check)
            {
                case 1:
                    Console.WriteLine("Voici l'exercice 1");
                    Multiplication();
                    Console.WriteLine("Appuyer sur une touche pour voir la partie 2\n");
                    Console.ReadLine();
                    Odd();
                    Console.WriteLine("Appuyer sur une touche pour voir la partie 3\n");
                    Console.ReadLine();
                    Feature();
                    break;
                case 2:
                    Console.WriteLine("Voici l'exercice 2");
                    Prime();
                    Console.WriteLine("Appuyer sur une touche pour voir la partie 2\n");
                    Console.ReadLine();
                    Fibonacci();
                    Console.WriteLine("Appuyer sur une touche pour voir la partie 3\n");
                    Console.ReadLine();
                    Factorial();
                    break;
                case 3:
                    Console.WriteLine("Voici l'exercice 3");
                    for (int i = -3; i <= 3; i++)
                    {
                        try
                        {
                            Console.WriteLine(10 / PowerFunction(i));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Voici l'exercice 4");
                    Console.WriteLine("Veuillez insérer les dimensions de votre rectangles, 1 à 1000 \n");
                    Console.WriteLine("Longueur? \n");
                    var n = Convert.ToInt32(Console.ReadLine());
                    if (n>1000 || n<1)
                    {
                        Console.WriteLine("Valeur invalide \n");
                        break;
                    }
                    Console.WriteLine("Largeur? \n");
                    var m = Convert.ToInt32(Console.ReadLine());
                    if (m > 1000 || m < 1)
                    {
                        Console.WriteLine("Valeur invalide \n");
                        break;
                    }
                    Square(n, m);
                    break;
                case 5:
                    Console.WriteLine("Voici l'exercice 5 (je n'ai pas reussi a decorer le sapin)");
                    Console.WriteLine("Veuillez insérer la taille de l'arbre de noel\n");
                    var l = Convert.ToInt32(Console.ReadLine());
                    Christmas(l);
                    break;
                default:
                    Console.WriteLine("Unnapropriate value \n");
                    break;
            }
        }

        static void Multiplication()
        {
            Console.WriteLine("Partie 1 Table de Multiplication : \n");
            for (int k = 1; k <= 10; k++)
                for (int j = 1; j <= 10; j++)
                    Console.WriteLine(k + "*" + j + "=" + k * j + "\n");
        }

        static void Odd()
        {
            Console.WriteLine("Partie 2 Table de Multiplication Impair : \n");
            for (int k = 1; k <= 10; k++)
                for (int j = 1; j <= 10; j++)
                    if (k % 2 != 0 && j % 2 != 0)
                    {
                        Console.WriteLine(k + "*" + j + "=" + k * j + "\n");
                    }
        }

        private static int Feature()
        {
            Console.WriteLine("Partie 3 Feature : \n ");
            Console.WriteLine("Veuillez entrer le nombre de la table de multiplication que vous souhaitez \n");
            int.TryParse(Console.ReadLine(), out var check2);
                for (int k = 1; k <= 10; k++)
                    Console.WriteLine(check2 + "*" + k + "=" + check2 * k + "\n");
                return check2;
        }

        private static void Prime()
        {
            Console.WriteLine("Partie 1 prime number \n");
            for (var i = 2; i <= 1000; i++)
            {
                int result = Check_Prime(i);
                if (result == 1)
                {
                    Console.WriteLine(i + "is a prime number \n");
                }
            }

        }
        private static int Check_Prime(int number)
        {
            int i;
            for (i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                {
                    return 0;
                }
            }
            if (i == number)
            {
                return 1;
            }
            return 0;
        }

        private static void Fibonacci()
        {
            int var1 = 0, var2 = 1, var3 = 0;
            Console.WriteLine("Partie 2 Fibonacci \n");
            Console.WriteLine("Veuillez entrer votre valeur fibonacci : \n");
            var n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("First {0} Fibonacci numbers {1} {2} \n", n, var1, var2);

            for (int i = 3; i <= n; i++)
            {
                var3 = var1 + var2;
                Console.WriteLine("{0} \n", var3);
                var1 = var2;
                var2 = var3;
            }
        }

        static void Factorial()
        {
            int i, f = 1, number;
            Console.WriteLine("Entrez le factoriel à calculer: ");
            number = int.Parse(Console.ReadLine());
            for (i = 1; i <= number; i++)
            {
                f = f * i;
            }
            Console.WriteLine("Factoriel de " + number + "! = " + f);

        }

        private static int PowerFunction(int x)
        {
            return (int)(Math.Pow(x, 2) - 4);
        }

        private static void Square(int n, int m)
        {
            int check = 0;
            if (n == 1 || m == 1)
            {
                Console.Write("0");
                return;
            }
            string space = new string('-', (n - 2));
            Console.Write("0" + space + "0\n");
            for (int cd1 = 0; cd1 < m - 2; ++cd1)
            {
                Console.Write("|");
                for (int cd2 = 0; cd2 < n - 2; cd2++)
                {
                    if (check == 0)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    check = ++check % 3;
                }
                Console.Write("|\n");
                check = ++check % 3;
            }
            Console.Write('0' + space + "0 \n");
        }

    

    private static void Christmas(int n)
        {
            for (int i = 0; i<n; i++)
            {
                string branch = new string('*', i);
                Console.WriteLine(branch.PadLeft(n+10) + "*" + branch);
            }
        }

    }

}
