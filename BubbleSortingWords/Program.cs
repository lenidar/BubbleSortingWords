using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortingWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inPath = "ToSort";
            string outPath = "Sorted_";
            string line = "";
            List<string> uList = new List<string>();
            string temp = "";
            int leastCharCount = 0;
            bool sorted = false;

            // read content of list
            using (StreamReader sr = new StreamReader(inPath + ".txt"))
                while ((line = sr.ReadLine()) != null)
                    if (line.Length > 0)
                        uList.Add(line.ToUpper());

            // sort
            for(int x = 0; x < uList.Count; x++) // dictate number of passes
            {
                for(int y = 0; y < uList.Count - 1; y++) // sorting pairs
                {
                    // this is just a reset
                    sorted = false;

                    // check which word is the shortest
                    if (uList[y].Length > uList[y + 1].Length)
                        leastCharCount = uList[y + 1].Length;
                    else
                        leastCharCount = uList[y].Length;

                    // comparing all the letters of the word
                    for(int z = 0; z < leastCharCount; z++)
                    {
                        if ((int)uList[y][z] > (int)uList[y + 1][z])
                        {
                            temp = uList[y];
                            uList[y] = uList[y + 1];
                            uList[y + 1] = temp;
                            sorted = true;
                            break;
                        }
                        else if ((int)uList[y][z] < (int)uList[y + 1][z])
                        {
                            sorted = true;
                            break;
                        }

                        // there is an invisible statement here, when both letters are equal
                        // if that is the case, z will increment and move on to the next set
                        // of letters
                    }

                    // if by any chance that it is not sorted after the for loop
                    // this is only for special cases
                    if(!sorted)
                    {
                        if(uList[y].Length > leastCharCount)
                        {
                            temp = uList[y];
                            uList[y] = uList[y + 1];
                            uList[y + 1] = temp;
                        }

                        // if word A is apple and word B is apples, this short logic just
                        // makes sure that in an alphabetical sense, apple is before apples.
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(outPath + inPath + ".txt"))
            {
                foreach (string word in uList)
                {
                    sw.WriteLine(word);
                }
            }
        }
    }
}
