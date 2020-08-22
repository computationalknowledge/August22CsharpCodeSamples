using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ConsoleApp2
{
    // This code can be used to illustrate a number of interesting applications of OO Code features
    // as well as the use of ASCII data encoding and how it can be manipulated
    class Program
    {
        static void Main(string[] args)
        {
            // int sumOfLetterValues = AsciiSymbols.DisplaySumOfAsciiValues("Jordan");
            //  Console.WriteLine(sumOfLetterValues);
            
            // let's make an Array of Names

            String[] names = new String[3];
            names[0] = "Mary";
            names[1 ] = "Jordan";
            names[2] = "Susan";


            String [] theAnswer = MySolution.MyMethod(names);

            for (int i = 0; i < theAnswer.Length; i++)
            {
                Console.WriteLine(theAnswer[i]);
            }

        }

    }

    class MySolution
    {
        public static String [] results = new string[5];
        private static String a = null;
        private static int b = 0;
        private static int ctr = 0;

        public static String[] MyMethod(String[] names)
        {
            // setup the ASCII values array once, not per each name call!
            AsciiSymbols.GenerateAsciiValues();
            
            foreach (var name in names)
            {
                // call the method DisplaySumOfAsciiValues for each name!
                a  = name;
                b = AsciiSymbols.DisplaySumOfAsciiValues(name);
                results[ctr++] = a + " " + b;
            }

            return results;
        }
    }

    class AsciiSymbols
    {
        // ascii table chart: https://www.screencast.com/t/ssxYu6d3xNgc 
        private static Char[] _asciiSymbols;
        public static int DisplaySumOfAsciiValues(string input1)
        {
            int sumOfLetterValues = 0;
            foreach (var letter in input1)
            {
                int counter = 0;
                foreach (var asciiCharacter in _asciiSymbols)
                {
                    if (asciiCharacter.Equals(letter))
                    {
                        sumOfLetterValues += counter;

                    }
                    counter++;
                }
            }

            return sumOfLetterValues;
        }

        public static Char[] GenerateAsciiValues()
        {
            _asciiSymbols = new Char[200];

            for (int i = 32; i < 128; i++)
            {
                _asciiSymbols[i] = Convert.ToChar(i);
            }
            return _asciiSymbols;
        }

    }


}
