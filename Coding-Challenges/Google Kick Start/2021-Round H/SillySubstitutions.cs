/*
 * Solution for Google Kick Start 2021 Round H "Transform the String" problem
 * Problem URL: https://codingcompetitions.withgoogle.com/kickstart/round/0000000000435914/00000000008d94f5
 * Successful Date: 
 * Author: Jóvin Jóvinsson
*/

using System;

namespace Coding_Challenges.Google_Kick_Start._2021_Round_H
{
    class SillySubstitutions
    {
        // Main method declaration removed while running other problems
        //public static void XMain(string[] args)
        public static void Main(string[] args)
        {
            // Get the number of test cases
            int numCases = Convert.ToInt32(Console.ReadLine());
            // Repeat the code for the number of times
            for (int i = 0; i < numCases; i++)
            {
                // Retrieve the length of the string
                int length = Convert.ToInt32(Console.ReadLine());
                // Retrieve the padlock & favourites strings as char[]
                string startString = Console.ReadLine();

                // If they input a string with a different length to what they anticipated throw an error
                if (startString.Length != length) { throw new Exception("Input string length does not match specified length"); }

                // Output the desired results
                Console.WriteLine("Case #" + (i + 1) + ": " + MakeChanges(startString));
            }
            // Wait for the user to input a key before closing
            Console.ReadKey();
        }

        /// <summary>
        /// Make all the changes inside an infinite loop, then when no further changes occur return the new string
        /// </summary>
        /// <param name="current">The starting string that will be modified</param>
        /// <returns></returns>
        static string MakeChanges(string current)
        {
            // Continue to do string replacements while we have changes happening
            while (true)
            {
                // Store the string in it's current state to check if changes were made
                string previous = current;

                // This allows us to efficiently replace all values without doing .Replace().Replace() manually typing it out
                int x = 0;
                int y = 1;
                int z = 2;
                // When X hits 10 we no longer want to change, this means our final search will be "90" to replace with "1"
                while (x < 10)
                {
                    // Reset Y back to zero when it hits 10
                    if (y == 10) { y = 0; }
                    // Reset Z back to zero when it hits 10
                    if (z == 10) { z = 0; }

                    // Replace the new substring from our numbers
                    current = current.Replace(x++ + "" + y++, "" + z++);
                }

                // No changes happened this iteration, return the final string
                if (current == previous)
                {
                    return current;
                }
            }
        }
    }
}
