using System;

namespace Praktikumsaufgabe_1
{
    class Program
    {
        static void Main(string[] args)
        {
            CMySentence sentence = new CMySentence("Dies ist ein Test!");
            CMyWord s = new CMyWord(sentence);
            CMyWord t = new CMyWord(sentence[2] + " ");
            Console.WriteLine(s);
            Console.WriteLine(s + t);
            Console.WriteLine(s - t);
            Console.WriteLine(s[" :eraepsekahS"] + "S" + t | !("s" + t + "?"));
            if (s) Console.WriteLine("s ist länger als 20 Zeichen.");
            else Console.WriteLine("s ist höchstens 20 Zeichen lang.");
            s *= 3;
            Console.WriteLine(s);
            if (s) Console.Write("s ist länger als 20 Zeichen ");
            else Console.Write("s ist höchstens 20 Zeichen lang ");
            Console.WriteLine("und enthält " + (int)sentence + " Wörter.");
            if (new CMyWord("ein ") == t) Console.WriteLine("So soll es s" + t);
        }
    }
}
