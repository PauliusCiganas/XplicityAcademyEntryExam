using System;

namespace Xplicity.Academy.EntranceExam.Tasks
{
    //Task #3 (Points: 40)
    //An anagram is a word formed by rearranging the letters of a different word using all the original letters exactly once.
    //For example, “elbow” - “below”. Calculate a number of anagram pairs in the specified text.
    //Each anagram pair should be counted only once, therefore for the text “My elbow was below” expected result is 1,
    //however for the text “My elbow was below, below another elbow” expected result is 2 (2 pairs)
    //The input text is not-nullable string of English letters, digits 0-9 and punctuation symbols.
    //The output data is an integer representing the amount of pairs.
    public class Task3
    {
        public static int GetNumberOfAnagrams(string text)
        {
            string[] words = text.Split(' ');
            List<string> result = new List<string>();
            bool match = false;
            List <List<string>> anagramCounter = new List<List<string>>();

            for (int i = 0; i < words.Count(); i++)
                words[i] = words[i].Trim();

            for (int i = 0; i < words.Count() - 1; i++)
            {
                result.Add(words[i]);
                for (int c = i + 1; c < words.Count(); c++)
                {
                    if (words[i].Length == words[c].Length && words[i] !="")
                    {
                        char[] a = words[i].ToUpper().ToCharArray();
                        char[] b = words[c].ToUpper().ToCharArray();
                        Array.Sort(a);
                        Array.Sort(b);

                        match = false;
                        int counter = 0;

                        foreach (char x in a)
                        {
                            if (x == b[counter])
                            {
                                match = true;
                            }
                            else
                            {
                                match = false;
                                break;
                            }
                            counter++;
                        }
                        if (match)
                        {
                            result.Add(words[c]);
                            words[c] = "";
                        }
                    }
                }
                if (result.Count() > 1 && result[0] != "")
                {
                    List<string> uniqueList = result.Distinct().ToList();
                    anagramCounter.Add(uniqueList);

                    // anagrams found : 
                    Console.Write("Anagrams: ");
                    foreach (var s in uniqueList)
                    {
                        Console.Write(s + " ");
                    }
                    Console.WriteLine();

                }
                result.Clear();

            }
            Console.WriteLine(anagramCounter.Count);
            return anagramCounter.Count;
        }
    }
} 