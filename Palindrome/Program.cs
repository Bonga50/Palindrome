using System.Diagnostics.Metrics;

namespace Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //List<string> word = new List<string>() {"Dad","Man","Mom","Sister", "civic", "radar", "level", "rotor", "kayak", "madam", "and", "refer" };
            //for (int i = 0; i < word.Count; i++)
            //{
            //    Console.WriteLine(checkPalindrome(word[i]));

            //}
            //int nth = 6;
            //Fibonaci(nth,0,0,1,1);
            string test = "ABC";
            permutations(test.ToArray(),0,0);
            

        }

        public static void Fibonaci(int Term,int count,int current,int prev,int next) {

            
            if (Term<=0||count>=Term-1)
            {
                Console.WriteLine(current);
                return;
            }
            next = current + prev;
            prev = current;
            current = next;
            
            Fibonaci(Term,++ count,current,prev,next);

            //return Fibonaci(Term - 2) + Fibonaci(Term - 1);
        }
        public static void permutations(char[] s, int anchor,int count) {
            if (s.Length <= 0 || count == (s.Length*2))
            {
                return;
            }
            Console.WriteLine(s);
            if (anchor==s.Length-1)
            {
               anchor = 0;
            }
            count++;
            s = swap(s.ToArray(), anchor, anchor+1);
            anchor++;
            
            permutations(s, anchor, count);


        }
        public static char[] swap(char[] word, int i,int j) {
            char temp = word[i];
            word[i] = word[j];
            word[j] = temp;
            return word;
        }
        public static bool checkPalindrome(string word)
        {
            word = word.ToLower();
            char[] wordArg = word.Reverse().ToArray();

            
            for (int i = 0; i < wordArg.Length; i++)
            {
                if (wordArg[i] != word[i])
                {
                    return false;
                }

            }
            return true;

        }
    }
}