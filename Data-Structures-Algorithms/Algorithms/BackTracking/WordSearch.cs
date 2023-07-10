using System;

namespace Data_Structures_Algorithms.Algorithms
{
    //Backtracking Recursion with Breadth First Search
    public class WordSearch
    {
        //O(MxN)
        //TC:(MxN)
        public void Test()
        {
            char[] sequence1 = { 'A', 'B', 'C', 'E' };
            char[] sequence2 = { 'S', 'F', 'C', 'S' };
            char[] sequence3 = { 'A', 'D', 'E', 'E' };
            char[][] board = { sequence1, sequence2, sequence3 };

            var result1 = Exist(board, "ABCB"); //False
            var result2 = Exist(board, "SEE"); //True
            var result3 = Exist(board, "ABCCED"); //True

            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);

        }

        bool[][] visited;
        private bool Exist(char[][] board, string word)
        {
            visited = new bool[board.Length][];
            for (int i = 0; i < board.Length; i++)
            {
                visited[i] = new bool[board[i].Length];
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == word[0] && SearchWord(i, j, 0, word, board))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool SearchWord(int i, int j, int index, string word, char[][] board)
        {
            if (index == word.Length) 
                return true;


            if (i < 0 || i >= board.Length || j < 0 || j >= board[i].Length || word[index] != board[i][j] || visited[i][j]) 
                return false;

            visited[i][j] = true;

            if (SearchWord(i, j + 1, index + 1, word, board) ||
                SearchWord(i, j - 1, index + 1, word, board) ||
                SearchWord(i + 1, j, index + 1, word, board) ||
                SearchWord(i - 1, j, index + 1, word, board))
            {
                return true;
            }

            visited[i][j] = false;
            return false;
        }
    }
}