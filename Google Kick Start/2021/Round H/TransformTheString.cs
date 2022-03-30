/*
 * Solution for Google Kick Start 2021 Round H "Transform the String" problem
 * Problem URL: https://codingcompetitions.withgoogle.com/kickstart/round/0000000000435914/00000000008da461#problem
 * Submission Date: 30th March 2022
 * Author: Jovin Sveinbjornsson
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KickStart2021
{
    class TransformTheString
    {
        static void Main(string[] args)
        {
            // Get the number of test cases
            int numCases = Convert.ToInt32(Console.ReadLine());
            // Repeat the code for the number of times
            for (int i = 0; i < numCases; i++)
            {
                // Retrieve the padlock & favourites strings as char[]
                char[] padlock = (Console.ReadLine()).ToCharArray();
                char[] faves = (Console.ReadLine()).ToCharArray();
                // The number of operations is the number of steps taken for the padlock to have letters matching the favourites
                int numberOfOperations = 0;
                // Iterate over each letter in the padlock
                for (int j = 0; j < padlock.Length; j++)
                {
                    // Set shortestDistance to an arbitrarily high number
                    int shortestDistance = 100;
                    // If the letter exists in favourites
                    if (faves.Contains(padlock[j]))
                    {
                        // Set shortest distance to 0 and move on
                        shortestDistance = 0;
                    }
                    else
                    {
                        // Otherwise, let's iterate over each favourite letter
                        for (int k = 0; k < faves.Length; k++)
                        {
                            // Calculate the distance in clockwise (a->b directly) and anticlockwise (a->b via z)
                            int clockwise = Math.Abs(padlock[j] - faves[k]);
                            int antiClockwise = 26 - clockwise;
                            // That that clockwise is the shortest distance overall
                            if (clockwise <= antiClockwise && clockwise < shortestDistance)
                            {
                                // Store the distance
                                shortestDistance = clockwise;
                            }
                            else if (antiClockwise < shortestDistance)
                            {
                                // Otherwise if anticlockwise is shortest, store this
                                shortestDistance = antiClockwise;
                            }
                            // There is no final else, as if neither are shorter than the current shortest, ignore it
                        }
                    }
                    // Increment our operation count by the distance
                    numberOfOperations += shortestDistance;
                }
                // Output the desired results
                Console.WriteLine("Case #" + (i + 1) + ": " + numberOfOperations);
            }
        }
    }
}
