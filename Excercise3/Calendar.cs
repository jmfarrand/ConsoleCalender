using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise3
{
    class Calendar
    {
        const string Days = "Mo Tu We Th Fr Sa Su";
        const int LengthOfCalendar = 20;

        int[,] monthDisplay = new int[7, 7];

        // Create array to print out the name
        string[] monthName = {"January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

        int year;
        int month;
        string input;

        // Initialise the variables to store the month to display
        DateTime firstDayOfMonth;
        DayOfWeek dayOfWeek;
        int daysInMonth;

        void Input()
        {
            Console.Write("Enter the year: ");
            input = Console.ReadLine();
            int.TryParse(input, out year);

            Console.Write("Enter the number of the month (Jan = 1, etc): ");
            input = Console.ReadLine();
            int.TryParse(input, out month);
            while (month < 1 || month > 12)
            {
                Console.Write("Wrong input. Please enter a number between 1 and 12, since there are only 12 months in a year: ");
                input = Console.ReadLine();
                int.TryParse(input, out month);
            }
        }

        void Initialisation()
        {
            firstDayOfMonth = new DateTime(year, month, 1);
            dayOfWeek = firstDayOfMonth.DayOfWeek;
            daysInMonth = DateTime.DaysInMonth(year, month);

            int x = 0;
            int y = (int)dayOfWeek - 1;

            if (y == -1)
            {
                y = 6;
            }

            for (int i = 1; i <= daysInMonth; i++)
            {
                monthDisplay[x, y] = i;
                y++;
                if (y != 0 && y % 7 == 0)
                {
                    y = 0;
                    x++;
                }
            }
        }

        void Print()
        {
            // print out the spaces to centre the month name, then print the name of the month itself
            for (int i = 1; i <= (LengthOfCalendar / 2) - (monthName[month - 1].Length / 2); i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(monthName[month - 1]);

            // print out the days
            Console.WriteLine(Days);

            int j = 0;
            foreach (int day in monthDisplay)
            {
                if (day == 0)
                {
                    Console.Write("  ");
                }
                else if (day < 10)
                {
                    Console.Write(" " + day);
                }
                else
                {
                    Console.Write(day);
                }

                Console.Write(" ");
                j++;
                if (j % 7 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        public void Run()
        {
            Input();
            Initialisation();
            Console.WriteLine();
            Print();
        }
    }
}
