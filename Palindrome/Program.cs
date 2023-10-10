using System.Diagnostics.Metrics;

namespace Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> word = new List<string>() {"Dad","Man","Mom","Sister", "civic", "radar", "level", "rotor", "kayak", "madam", "and", "refer" };
            //for (int i = 0; i < word.Count; i++)
            //{
            //    Console.WriteLine(checkPalindrome(word[i]));

            //}
            //int nth =100;
            //Fibonaci(nth,0,0,1,1);
            List<int> nums = new List<int>() {1,2,3,4,5,6,7,8,9,10 };
            //string test = "ABC";
            //permutations(test.ToArray(),0,0);

            BinarySearch(8, nums, 0, 0, nums.Count - 1);


        }



        
        public static void BinarySearch(int target, List<int> nums, int mid, int start, int end)
        {
            //bool result=false;
            if (nums.Count == 0 || start >= nums.Count() - 1) {
                Console.WriteLine("Not found");
                return; }


            //finding middle
            mid = start + (end - start) / 2;

            if (nums[mid]==target){
                Console.WriteLine("Number found at index : "+mid );
                return;
            }
        
            if (target > nums[mid])
            {
                start = mid+1;
            }else if (target < nums[mid])
            {
                end = mid-1;
            }

            BinarySearch(target, nums, mid, start, end);

        }
        public static void Fibonaci(int Term,int count,int current,int prev,int next) {

            
            if (Term<=0||count>=Term)
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