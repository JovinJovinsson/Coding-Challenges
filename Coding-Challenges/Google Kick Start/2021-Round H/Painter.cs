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
        // Create a dictionary of the colours, leave out U as we just skip any spots with that
        Dictionary<char, char[]> colours = new Dictionary<char, char[]>();
        colours.Add('R', new char[] { 'R' });
        colours.Add('Y', new char[] { 'Y' });
        colours.Add('B', new char[] { 'B' });
        colours.Add('O', new char[] { 'R', 'Y' });
        colours.Add('P', new char[] { 'R', 'B' });
        colours.Add('G', new char[] { 'B', 'Y' });
        colours.Add('A', new char[] { 'R', 'Y', 'B' });
        // Repeat the code for the number of times
        for (int i = 0; i < numCases; i++)
        {
            // Retrieve the padlock & favourites strings as char[]
            int length = Convert.ToInt32(Console.ReadLine());
            char[] painting = (Console.ReadLine()).ToCharArray();

            // Store the total number of strokes
            int numberOfStrokes = 0;
            
            // Iterate over each colour
            /*foreach (KeyValuePair<char, char[]> kvp in colours)
            {*/
            numberOfStrokes += strokesForColour(painting, length, 'R', colours);
            numberOfStrokes += strokesForColour(painting, length, 'Y', colours);
            numberOfStrokes += strokesForColour(painting, length, 'B', colours);
            //}

            // Output the desired results
            Console.WriteLine("Case #" + (i + 1) + ": " + numberOfStrokes);
        }
        // Wait for the user to input a key before closing
        Console.ReadKey();
    }

    /// <summary>
    /// Identifies the number of strokes required by unwrapping the colours to their base and ensuring no duplicate
    /// </summary>
    /// <param name="painting">The painting input as a char array</param>
    /// <param name="length">The length of the painting</param>
    /// <param name="colour">The current colour being analysed</param>
    /// <param name="colourMap">The map of secondary colours to primary</param>
    /// <returns></returns>
    static int strokesForColour(char[] painting, int length, char colour, Dictionary<char, char[]> colourMap)
    {
        // Count the number of strokes for this colour
        int strokes = 0;
        // Store the position of of our stroke to ensure we don't double up
        int lastStroke = int.MinValue;
        
        // Iterate over each position in the painting
        for (int i = 0; i < length; i++)
        {
            // When it's uncoloured, just skip
            if (painting[i] == 'U')
            {
                continue;
            }
            // If the current colour matches the input colour, or the colour is a parimary of the secondary colour
            if (painting[i] == colour || Array.Exists(colourMap[painting[i]], element => element.Equals(colour)))
            {
                // If the last colour change position was not the previous position in the array, increment
                if (lastStroke != i - 1)
                {
                    strokes++;
                }
                // We're matching the colour, so increase the stroke position
                // This won't change if the colour changes
                lastStroke = i;
            }
        }

        return strokes;
    }
}