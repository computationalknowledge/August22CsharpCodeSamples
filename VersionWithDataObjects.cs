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


            NameAndNumberData [] theAnswer = MySolution.MyMethod(names);

            foreach (var VARIABLE in theAnswer)
            {

                if (VARIABLE is null) break;
                VARIABLE.DisplayData();
            }


        }

    }

    class NameAndNumberData
    {
        public String name;
        public int AsciiValueOfName;

        // make a method called display data!

        public void DisplayData()
        {
            Console.WriteLine("{0}    *****   {1}", name, AsciiValueOfName);
        }
    }

    class MySolution
    {
        public static NameAndNumberData [] results = new NameAndNumberData[5];
        private static int ctr = 0;

        public static NameAndNumberData[] MyMethod(String[] names)
        {
            // setup the ASCII values array once, not per each name call!
            AsciiSymbols.GenerateAsciiValues();
            
            foreach (var name in names)
            {   NameAndNumberData dataRecord = new NameAndNumberData();

                // call the method DisplaySumOfAsciiValues for each name!
                dataRecord.name = name;
                dataRecord.AsciiValueOfName = AsciiSymbols.DisplaySumOfAsciiValues(name);
                results[ctr++] = dataRecord;
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
