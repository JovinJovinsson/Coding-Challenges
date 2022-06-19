/*
 * Solution for Google Kick Start 2021 Round H "Painter" problem
 * Problem URL: https://codingcompetitions.withgoogle.com/kickstart/round/0000000000435914/00000000008d9a88#problem
 * Start Date: 18th June 2022
 * Submission Date: 
 * Author: Jóvin Jóvinsson
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Painter
{
    // Main method declaration removed while running other problems
    //public static void XMain(string[] args)
    public static void Main(string[] args)
    {
        // Get the number of test cases
        int numCases = Convert.ToInt32(Console.ReadLine());
        // Create a basic array for the primary colours
        char[] primary = new char[] { 'R', 'Y', 'B' };
        // Create a jagged array to store the values
        char[][] secondary = new char['Q'][];
        secondary['A'] = primary;
        secondary['O'] = new char[] { 'R', 'Y' };
        secondary['P'] = new char[] { 'R', 'B' };
        secondary['G'] = new char[] { 'Y', 'B' };
        // We'll leave U out of both as we can handle that directly
        // Repeat the code for the number of times
        for (int i = 0; i < numCases; i++)
        {
            // Retrieve the padlock & favourites strings as char[]
            int length = Convert.ToInt32(Console.ReadLine());
            char[] painting = (Console.ReadLine()).ToCharArray();
            // The number of operations is the number of steps taken for the padlock to have letters matching the favourites
            int numberOfStrokes = 0;
            // Iterate over the characters of the painting
            for (int j = 0; j < length; j++)
            {
                // This is our first stroke, ensure it's not uncoloured, then increment
                if (j == 0 && painting[j] != 'U') { numberOfStrokes++; }
                // Skip if it's uncoloured as we have no stroke, or if the stroke is the same as previous
                else if (painting[j] == 'U' || painting[j] == painting[j - 1]) { continue; }
                else
                {
                    if (Array.Exists(primary, element => element == painting[j]))
                    {
                        
                    } else // We have a secondary colour
                    {

                    }
                }
            }
            // Output the desired results
            Console.WriteLine("Case #" + (i + 1) + ": " + numberOfStrokes);
        }
        // Wait for the user to input a key before closing
        Console.ReadKey();
    }


}