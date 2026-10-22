using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> names = new List<string>();

        bool running = true;

        while (running)
        {
            try
            {
                Console.WriteLine("\n===== NAME MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Add a Name");
                Console.WriteLine("2. Remove a Name");
                Console.WriteLine("3. Display All Names");
                Console.WriteLine("4. Exit");

                Console.WriteLine("");

                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();

                int choice;

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input! Enter a number.");

                    continue;
                }

                switch (choice)
                {
                    case 1:

                        Console.WriteLine("");

                        Console.Write("Enter a name to add: ");

                        string newName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(newName))
                        {
                            Console.WriteLine("Name cannot be empty!");
                        }

                        else if (names.Any(n =>
                            string.Equals(n, newName,
                            StringComparison.OrdinalIgnoreCase)))
                        {
                            Console.WriteLine("Name already exists!");
                        }

                        else
                        {
                            names.Add(newName.Trim());

                            Console.WriteLine("");

                            Console.WriteLine("Name added successfully!");
                        }

                        break;

                    case 2:

                        Console.WriteLine("");

                        Console.Write("Enter a name to remove: ");

                        string removeName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(removeName))
                        {
                            Console.WriteLine("Name cannot be empty!");
                        }

                        else
                        {
                            int index = names.FindIndex(n =>
                                string.Equals(n, removeName.Trim(),
                                StringComparison.OrdinalIgnoreCase));

                            if (index != -1)
                            {
                                names.RemoveAt(index);

                                Console.WriteLine("");

                                Console.WriteLine("Name removed successfully!");
                            }

                            else
                            {
                                Console.WriteLine("Name not found!");
                            }
                        }

                        break;

                    case 3:

                        if (names.Count == 0)
                        {
                            Console.WriteLine("No names in the list.");
                        }

                        else
                        {
                            Console.WriteLine("");

                            Console.WriteLine("\nAll Names:");

                            foreach (string name in names)
                            {
                                Console.WriteLine(name);
                            }

                            double totalLength = names.Sum(n => n.Length);

                            double averageLength = totalLength / names.Count;

                            Console.WriteLine("");

                            Console.WriteLine("Average name length: " + Math.Round(averageLength, 2));
                        }

                        break;

                    case 4:

                        running = false;

                        Console.WriteLine("");

                        Console.WriteLine("Program exited successfully.");

                        break;

                    default:

                        Console.WriteLine("Invalid choice! Select 1, 2, 3, or 4.");

                        break;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}

