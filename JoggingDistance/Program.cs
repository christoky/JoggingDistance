using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Xml.Schema;
using Microsoft.VisualBasic;
using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JoggingDistance
{
    internal class Program
    {
        public const double STRIDE = 2.5;
        public const double FEET_PER_MILE = 5280;

        static void Main(string[] args)
        {
            int initialStrideCount;
            int finalStrideCount;
            int hrs;
            int mins;
            int totalMinutes;
            double numberOfStepsPerMin;
            double distanceTraveled;

            DisplayInstructions();

            initialStrideCount = GetNumberStrides("first");
            finalStrideCount = GetNumberStrides("last");            

            hrs = InputiJoggingTime("hours");
            mins = InputiJoggingTime("minutes");

            totalMinutes = CalculateTime(hrs, mins);
            numberOfStepsPerMin = CalculateAvgSteps( initialStrideCount, finalStrideCount );
            distanceTraveled = CalculateDistance(numberOfStepsPerMin, totalMinutes);

            WriteLine();
            WriteLine("JOGGING DISTANCE CALCULATOR");
            WriteLine("---------------------------");
            WriteLine("Stride:             {0} ", STRIDE + " Feet Per Step ");
            WriteLine();
            DisplayResults(numberOfStepsPerMin, mins, hrs, distanceTraveled);

        }

        

        public static void DisplayInstructions()
        {           
            WriteLine("The application determines: " +
                "\n\t- Number of strides per minute," +
                "\n\t- Time or number of minutes jogged," +
                "\n\t- The distance jogged.");

            WriteLine();

            WriteLine("You will be asked to enter the nomber of strides" +
                "\nand the time made (hour and minutes)");
            WriteLine();
            WriteLine("=================================================");
            WriteLine();
        }

        public static int GetNumberStrides(string when)
        {           
            Write("Enter the number of strides during the {0} minutes: ", when);
            string inputValue = ReadLine();
            int numberOfStrids = int.Parse(inputValue);

            return numberOfStrids;

        }

        public static int InputiJoggingTime(string time)
        {
            string inputValue;
            int timeRun;

            Write("Enter total {0} made: ", time);
            inputValue = ReadLine();
            timeRun = int.Parse(inputValue);

            return timeRun;
        }

        public static double CalculateAvgSteps(int initialStrideCount, int finalStrideCount)
        {
            return ((initialStrideCount + finalStrideCount) / 2);
        }

        public static int CalculateTime(int hrs, int mins)
        {
            return ((hrs * 60 + mins));
        }

        public static double CalculateDistance(double numberOfStepsPerMin, int totalMinutes)
        {

            return (numberOfStepsPerMin * STRIDE * totalMinutes / FEET_PER_MILE);
        }

        public static void DisplayResults(double numberOfStepsPerMin, int mins, int hrs, double disttanceTraveled )
        {
            WriteLine("Strides Per Minute: {0}", numberOfStepsPerMin + " Steps");
            WriteLine();
            WriteLine("Jogging Time:       {0}", hrs + " Hours");
            WriteLine();
            WriteLine("                    {0}", mins + " Minutes");
            WriteLine();
            WriteLine("Distance Traveled:  {0}", disttanceTraveled + " Miles");
            
        }
    }
}
