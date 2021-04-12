using System;
using System.Collections.Generic;
using System.Linq;


class GFG
{
    public static bool checkPangram(string str)
    {

        str = str.Replace(" ","").ToUpper();
        int index = 0;
        for (int i = 0; i < str.Length; i++)
        {
            index = str[i] - 'A';
            if (index > 0 && index < 25)
                return false;
        }
        return true;
    }


    class Solution
    {
        static void Main(String[] args)
        {
            string str = "The uick brown fox jumps over the lazy dog";

            if (checkPangram(str) == true)
                Console.WriteLine(str + " is a pangram.");
            else
                Console.WriteLine(str + " is not a pangram.");

        }
    }
}
// Your previous work is preserved below:
//
// print("Hello, world!")
// print("This is a fully functioning Python 3 environment.")
//