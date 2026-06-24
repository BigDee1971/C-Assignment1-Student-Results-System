using System;

class StudentResultsSystem
{
    static string[] names = new string[3];
    static string[] ids = new string[3];
    static string[] programmes = new string[3];
    static string[] levels = new string[3];
    static double[,] scores = new double[3, 5];

    static bool dataEntered = false;

    static string[] courses =
    {
        "Programming with C#",
        "Database Systems",
        "Computer Networks",
        "Web Development",
        "Mathematics for Computing"
    };

    static void Main()
    {
        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine("===== STUDENT RESULTS PROCESSING SYSTEM =====");
            Console.WriteLine("1. Enter Student Results");
            Console.WriteLine("2. View Student Report");
            Console.WriteLine("3. Exit");
            Console.Write("\nChoose an option: ");

            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   choice < 1 || choice > 3)
            {
                Console.Write("Invalid option. Choose 1, 2, or 3: ");
            }

            switch (choice)
            {
                case 1:
                    EnterStudentResults();
                    break;

                case 2:
                    ViewStudentReport();
                    break;

                case 3:
                    Console.WriteLine("\nThank you for using the system.");
                    break;
            }

        } while (choice != 3);
    }

    static void EnterStudentResults()
    {
        Console.Clear();

        if (dataEntered)
        {
            Console.Write("Results already exist. Overwrite? (Y/N): ");
            string answer = (Console.ReadLine() ?? "").ToUpper();

            if (answer != "Y")
                return;
        }

        for (int i = 0; i < 3; i++)
        {
            Console.Clear();
            Console.WriteLine($"===== STUDENT {i + 1} OF 3 =====\n");

            Console.Write("Enter Full Name: ");
            names[i] = Console.ReadLine() ?? "";

            Console.Write("Enter Student ID: ");
            ids[i] = Console.ReadLine() ?? "";

            Console.Write("Enter Programme: ");
            programmes[i] = Console.ReadLine() ?? "";

            Console.Write("Enter Level: ");
            levels[i] = Console.ReadLine() ?? "";

            Console.WriteLine();

            for (int j = 0; j < 5; j++)
            {
                double score;

                do
                {
                    Console.Write($"Enter score for {courses[j]} (0-100): ");

                    while (!double.TryParse(Console.ReadLine(), out score))
                    {
                        Console.Write("Invalid input. Enter a number: ");
                    }

                    if (score < 0 || score > 100)
                    {
                        Console.WriteLine("Score must be between 0 and 100.");
                    }

                } while (score < 0 || score > 100);

                scores[i, j] = score;
            }
        }

        dataEntered = true;

        Console.WriteLine("\nAll student results entered successfully!");
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    static void ViewStudentReport()
    {
        Console.Clear();

        if (!dataEntered)
        {
            Console.WriteLine("No student data found.");
            Console.WriteLine("Please enter results first.");
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("========== STUDENT RESULTS REPORT ==========\n");

        for (int i = 0; i < 3; i++)
        {
            double total = 0;

            for (int j = 0; j < 5; j++)
            {
                total += scores[i, j];
            }

            double average = total / 5;
            string grade = GetGrade(average);
            string status = average >= 50 ? "PASSED" : "FAILED";

            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Name      : {names[i]}");
            Console.WriteLine($"Student ID: {ids[i]}");
            Console.WriteLine($"Programme : {programmes[i]}");
            Console.WriteLine($"Level     : {levels[i]}");
            Console.WriteLine();

            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine($"{courses[j],-30}: {scores[i, j]}");
            }

            Console.WriteLine();
            Console.WriteLine($"Total   : {total}");
            Console.WriteLine($"Average : {average:F2}");
            Console.WriteLine($"Grade   : {grade}");
            Console.WriteLine($"Status  : {status}");
            Console.WriteLine();
        }

        Console.WriteLine(new string('=', 50));
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }

    static string GetGrade(double average)
    {
        if (average >= 80)
            return "A";
        else if (average >= 70)
            return "B";
        else if (average >= 60)
            return "C";
        else if (average >= 50)
            return "D";
        else
            return "F";
    }
}