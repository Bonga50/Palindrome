namespace Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> word = new List<string>() { "Dad", "Man", "Mom", "Sister", "civic", "radar", "level", "rotor", "kayak", "madam", "and", "refer" };
            //for (int i = 0; i < word.Count; i++)
            //{
            //    Console.WriteLine(checkPalindrome(word[i]));

            //}
            //int nth =6;
            //Fibonaci(nth,0,0,1,1);
            //List<int> nums = new List<int>() {1,2,3,4,5,6,7,8,9,10 };
            //string test = "ABC";
            //permutations(test.ToArray(),0,0);

            //BinarySearch(9, nums, 0, 0, nums.Count - 1);
            int numQueens = 4;
            
            int[,] chessboard = new int[numQueens, numQueens];
            nQueenProblem(numQueens, chessboard, numQueens,0,0,0,1,0);

        }




        public static void BinarySearch(int target, List<int> nums, int mid, int start, int end)
        {
            //bool result=false;
            if (nums.Count == 0 || start >= nums.Count() - 1)
            {
                Console.WriteLine("Not found");
                return;
            }


            //finding middle
            mid = start + (end - start) / 2;

            if (nums[mid] == target)
            {
                Console.WriteLine("Number found at index : " + mid);
                return;
            }

            if (target > nums[mid])
            {
                start = mid + 1;
            }
            else if (target < nums[mid])
            {
                end = mid - 1;
            }

            BinarySearch(target, nums, mid, start, end);

        }

        public static void nQueenProblem(int numQueens, int[,] matix, int count, int startIndex,int qrow,int qcol, int iterator,int sentinal)
        {
            //check if array size is less than 3 or if number of queens is 0
            if (numQueens <= 3 ||  count<=0)
            {
                PrintArray(matix);
                Console.WriteLine($"This took {iterator} iterations");
                return;
            }

            PrintArray(matix);

            int rows = matix.GetLength(0);
            int cols = matix.GetLength(1);
            if (cols%2==0)
            {
                sentinal = 3;
            }else 
            {
                sentinal = 2;
            }

            if (qrow>=rows && numQueens>=1)
            {
                
                matix= startOver(rows,cols);
                qrow= 0;
                qcol= 0;
                count = cols;
            }

            

            if (matix[0, startIndex] == 0&&count==rows)
            {
                matix[0, startIndex] = 1;
                qcol = qcol + sentinal;
                qrow++;
                count--;
                matix = Update2DArray(matix);
                nQueenProblem(numQueens,matix,count,startIndex,qrow,qcol,iterator,sentinal);

            } else 
            {
                if (matix[qrow, qcol] == -1)
                {
                    startIndex++;
                    iterator++;
                    matix = startOver(rows, cols);
                    qrow = 0;
                    qcol = 0;
                    count = cols;
                }
                else
                {
                    matix[qrow, qcol] = 1;

                    if (qcol + sentinal > cols - 1)
                    {
                        qcol = qcol + sentinal - cols;
                    }
                    else
                    {
                        qcol = qcol + sentinal;
                    }
                    qrow++;
                    count--;
                    matix = Update2DArray(matix);
                }
               
                nQueenProblem(numQueens, matix, count, startIndex, qrow, qcol, iterator, sentinal);
            }
 
            


        }

        
        public static int[,] startOver(int rows, int cols ) {
            return new int[rows, cols];
        }
        public static int[,] addNewQueen(int[,] chessboard)
        {
            for (int i = 0; i < chessboard.GetLength(0); i++)
            {
                for (int j = 0; j < chessboard.GetLength(1); j++)
                {
                    if (chessboard[i, j] == 0)
                    {
                        chessboard[i, j] = 1;
                        break;
                    }
                }
            }
            return chessboard;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[,] Update2DArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int[,] resultArray = new int[rows, cols];

            resultArray= UpdateColMatrix(array);
            resultArray=UpdateRowMatrix(resultArray);
            resultArray = UpdateRightDiagonalMatrix(resultArray);
            resultArray = UpdateLeftDiagonalMatrix(resultArray);
            return resultArray;
        }

        public static int[,] UpdateRightDiagonalMatrix(int[,] matrix)
        {
            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        // Set current cell to 1
                        matrix[row, col] = 1;
                        // Set all cells diagonally right and below to -1
                        int i = row + 1;
                        int j = col + 1;
                        while (i < numRows && j < numCols)
                        {
                            matrix[i, j] = -1;
                            i++;
                            j++;
                        }
                        // No need to check the rest of the matrix, so break the loop
                        break;
                    }
                }
            }

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        // Set all cells diagonally left and above to -1
                        int i = row - 1;
                        int j = col - 1;
                        while (i >= 0 && j >= 0)
                        {
                            matrix[i, j] = -1;
                            i--;
                            j--;
                        }
                    }
                }
            }

            return matrix;
        }

        public static int[,] UpdateColMatrix(int[,] matrix)
        {
            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);

            for (int col = 0; col < numCols; col++)
            {
                for (int row = 0; row < numRows; row++)
                {
                    if (matrix[row, col] == 1)
                    {
                        // Set current cell to 1
                        matrix[row, col] = 1;
                        // Set all cells above to -1
                        for (int i = row - 1; i >= 0; i--)
                        {
                            matrix[i, col] = -1;
                        }
                        // No need to check the rest of the column, so break the loop
                        break;
                    }
                }
            }

            for (int col = 0; col < numCols; col++)
            {
                bool foundOne = false;
                for (int row = 0; row < numRows; row++)
                {
                    if (matrix[row, col] == 1)
                    {
                        foundOne = true;
                    }
                    else if (foundOne)
                    {
                        matrix[row, col] = -1;
                    }
                }
            }
            return matrix;
        }
        public static int[,] UpdateRowMatrix(int[,] matrix)
        {
            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        // Set current cell to 1
                        matrix[row, col] = 1;
                        // Set all cells to the left to -1
                        for (int i = col - 1; i >= 0; i--)
                        {
                            matrix[row, i] = -1;
                        }
                        // Set all cells to the right to -1
                        for (int i = col + 1; i < numCols; i++)
                        {
                            matrix[row, i] = -1;
                        }
                        // No need to check the rest of the row, so break the loop
                        break;
                    }
                }
            }

            for (int row = 0; row < numRows; row++)
            {
                bool foundOne = false;
                for (int col = 0; col < numCols; col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        foundOne = true;
                    }
                    else if (foundOne)
                    {
                        matrix[row, col] = -1;
                    }
                }
            }

            return matrix;
        }
        public static int[,] UpdateLeftDiagonalMatrix(int[,] matrix)
        {
            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        // Set current cell to 1
                        matrix[row, col] = 1;
                        // Set all cells diagonally left and below to -1
                        int i = row + 1;
                        int j = col - 1;
                        while (i < numRows && j >= 0)
                        {
                            matrix[i, j] = -1;
                            i++;
                            j--;
                        }
                        // No need to check the rest of the matrix, so break the loop
                        break;
                    }
                }
            }

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        // Set all cells diagonally right and above to -1
                        int i = row - 1;
                        int j = col + 1;
                        while (i >= 0 && j < numCols)
                        {
                            matrix[i, j] = -1;
                            i--;
                            j++;
                        }
                    }
                }
            }

            return matrix;
        }




        public static void PrintArray(int[,] nums)
        {

            for (int i = 0; i < nums.GetLength(0); i++)
            {
                for (int j = 0; j < nums.GetLength(1); j++)
                {
                    Console.Write($" [{nums[i, j]}] ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");

        }

        public static void Fibonaci(int Term, int count, int current, int prev, int next)
        {


            if (Term <= 0 || count >= Term - 1)
            {
                Console.WriteLine(current);
                return;
            }
            next = current + prev;
            prev = current;
            current = next;

            Fibonaci(Term, ++count, current, prev, next);

            //return Fibonaci(Term - 2) + Fibonaci(Term - 1);
        }
        public static void permutations(char[] s, int anchor, int count)
        {
            if (s.Length <= 0 || count == (s.Length * 2))
            {
                return;
            }
            Console.WriteLine(s);
            if (anchor == s.Length - 1)
            {
                anchor = 0;
            }
            count++;
            s = swap(s.ToArray(), anchor, anchor + 1);
            anchor++;

            permutations(s, anchor, count);


        }
        public static char[] swap(char[] word, int i, int j)
        {
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