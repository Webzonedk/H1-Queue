using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Transactions;

namespace Queue
{
    class Program
    {
        static ConsoleKeyInfo keypress = new ConsoleKeyInfo();
        static Queue<Cow> cows = new Queue<Cow>();
        static bool run = true;

        static void Main(string[] args)
        {
            //Cow cow1 = new Cow();

            while (run)
            {
                MainMenu();
                Menu();

            }









        }
        static void MainMenu()
        {





            Console.Clear();
            Console.WriteLine(@"                       (                        ");
            Console.WriteLine(@"                     ( )\     (  (      (  (    ");
            Console.WriteLine(@"                     )((_)    )\ )\     )\ )\   ");
            Console.WriteLine(@"                    ((_)_  _ ((_|(_) _ ((_|(_)  ");
            Console.WriteLine(@"                     / _ \| | | | __| | | | __| ");
            Console.WriteLine(@"                    | (_) | |_| | _|| |_| | _|  ");
            Console.WriteLine(@"                     \__\_\\___/|___|\___/|___| ");
            Console.WriteLine();
            Console.WriteLine("==================================================================");
            Console.WriteLine("=                                                                =");
            Console.WriteLine("=                    H1 Queue Operations Menu                    =");
            Console.WriteLine("=                                                                =");
            Console.WriteLine("==================================================================");
            Console.WriteLine();
            Console.WriteLine("1. Add cows");
            Console.WriteLine("2. Delete the first cow in the");
            Console.WriteLine("3. Show the number of cows");
            Console.WriteLine("4. Show min and max cows");
            Console.WriteLine("5. Find a cow");
            Console.WriteLine("6. Print all cows");
            Console.WriteLine("7. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice: \n");
            Console.WriteLine();
        }
        static void Menu()
        {
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    //Add cows
                    bool runAdd = true;
                    while (runAdd)
                    {
                        try
                        {
                            Console.WriteLine("Add a new cow to the Milking queue:\n");
                            Console.WriteLine();
                            Console.Write("Add name: ");
                            string name = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Add number: ");
                            uint number = UInt32.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Cow cow = new Cow(name, number);
                            cows.Enqueue(new Cow() { Number = number, Name = name });
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("| Add another cow: Press 1 || Main menu: Press 2 |");
                            switch (Console.ReadKey(true).KeyChar)
                            {
                                case '1':
                                    runAdd = true;
                                    break;
                                case '2':
                                    runAdd = false;
                                    break;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("That is not a correct number within the approved range 0 - 4.294.967.295");
                        }
                    }
                    break;
                case '2':
                    //Delete cows
                    bool runDel = true;
                    while (runDel)
                    {
                        Cow deletedCow = cows.Dequeue();
                        Console.WriteLine();
                        Console.WriteLine("You have just deleted:");
                        Console.WriteLine();
                        string delNameHeader = "Name";
                        string delNumberHeader = "Number";
                        Console.Write($"{delNumberHeader,10}");
                        Console.Write($"  {delNameHeader,-20}\n");
                        Console.Write($"{deletedCow.Number,10}");
                        Console.Write($"  {deletedCow.Name,-20}\n");
                        Console.WriteLine();
                        Console.WriteLine("| Remove next cow from queue: Press 1 || Main menu: Press 2 |");
                        switch (Console.ReadKey(true).KeyChar)
                        {
                            case '1':
                                runDel = true;
                                break;
                            case '2':
                                runDel = false;
                                break;
                        }
                    }
                    break;
                case '3':
                    //show the number of cows
                    Console.WriteLine($"There is a total of {cows.Count} in the Queue at the moment.\n");
                    Console.WriteLine("Press any key to return to main menu");
                    Console.ReadKey();
                    break;
                case '4':
                    //Show min and max cows
                    uint min = 0;
                    uint max = 4294967295;
                    foreach (Cow cow in cows)
                    {
                        if (cow.Number < max)
                        {
                            max = cow.Number;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine($"The cow with the lowest number is:{max}");
                    foreach (Cow cow in cows)
                    {
                        if (cow.Number > min)
                        {
                            min = cow.Number;
                        }
                    }
                    Console.WriteLine($"The cow with the highest number is:{min}");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to main menu");
                    Console.ReadKey();
                    break;
                case '5':
                    //Find a cow
                    Console.Clear();
                    SeachForNames();
                    break;
                case '6':
                    //Print all cows
                    string nameHeader = "Name";
                    string numberHeader = "Number";
                    Console.Write($"{numberHeader,10}");
                    Console.Write($"  {nameHeader,-20}\n");
                    foreach (var cow in cows)
                    {
                        Console.Write($"{cow.Number,10}");
                        Console.Write($"  {cow.Name,-20}\n");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to main menu");
                    Console.ReadKey();

                    break;
                case '7':
                    //Exit
                    run = false;
                    break;
                    //default:
                    //    break;

            }
        }

        /// <summary>
        /// This method is made to search for names on the run for each letter typed
        /// </summary>
        static void SeachForNames()
        {
            bool runAdd = true;
            while (runAdd)
            {

                //Here starts the seach option
                string tempInput = null;
                Console.WriteLine();
                Console.Write($"Søg efter et navn:\t");
                //creating options to check while writing
                while (keypress.Key != ConsoleKey.Enter)
                {

                    keypress = Console.ReadKey(true);
                    //This part deletes letters from the search string
                    if (keypress.Key == ConsoleKey.Backspace)
                    {
                        Console.Clear();

                        Console.Write($"Search for a cow by name:\t");
                        try
                        {
                            tempInput = tempInput.Substring(0, tempInput.Length - 1);
                        }
                        catch (Exception)
                        {
                        }
                        Console.WriteLine(tempInput);
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write($"Search for a cow by name:\t");
                        tempInput += keypress.KeyChar;
                        Console.WriteLine(tempInput);
                    }
                    if (tempInput.Length != 0)//Shows the result I still need to implement that the mainmenu needs to keep occuring
                    {
                        Console.Write("\n\n");
                        Console.WriteLine("The following cows occur in the database:");
                        foreach (Cow cow in cows)
                        {
                            if (cow.Name.ToLower().StartsWith(tempInput.ToLower()))
                            {
                                Console.Write($"{cow.Number,10}");
                                Console.Write($"  {cow.Name,-20}\n");
                            }

                        }

                    }
                }
                Console.WriteLine();
                Console.WriteLine("| Search for another cow: Press 1 || Main menu: Press 2 |");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        runAdd = true;
                        break;
                    case '2':
                        runAdd = false;
                        break;
                }
            }
        }

    }
}