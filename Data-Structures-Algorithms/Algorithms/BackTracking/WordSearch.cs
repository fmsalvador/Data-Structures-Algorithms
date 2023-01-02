using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Structures_Algorithms.Algorithms
{
    // Backtracking Recursion
    internal class WordSearch
    {
        //O(MxN)
        public void Test()
        {
            char[] sequence1 = { 'A', 'B', 'C', 'E' };
            char[] sequence2 = { 'S', 'F', 'C', 'S' };
            char[] sequence3 = { 'A', 'D', 'E', 'E' };
            char[][] board = { sequence1, sequence2, sequence3 };

            var result1 = exist(board, "ABCB"); //False
            var result2 = exist(board, "SEE"); //True
            var result3 = exist(board, "ABCCED"); //True
        }

        bool[][] visited;
        public bool Exist(char[][] board, string word)
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
                    if (board[i][j] == word[0] && searchWord(i, j, 0, word, board))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool searchWord(int i, int j, int index, string word, char[][] board)
        {
            if (index == word.Length) 
                return true;


            if (i < 0 || i >= board.Length || j < 0 || j >= board[i].Length || word[index] != board[i][j] || visited[i][j]) 
                return false;

            visited[i][j] = true;

            if (
                searchWord(i, j + 1, index + 1, word, board) ||
                searchWord(i, j - 1, index + 1, word, board) ||
                searchWord(i + 1, j, index + 1, word, board) ||
                searchWord(i - 1, j, index + 1, word, board)
                )
            {
                return true;
            }

            visited[i][j] = false;
            return false;
        }

        public bool exist(char[][] board, String word)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == word[0] && this.dfs(board, i, j, 0, word))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool dfs(char[][] board, int i, int j, int count, String word)
        {
            if (count == word.Length)
            {
                return true;
            }
            if (i < 0 || j < 0 || i >= board.Length || j >= board[0].Length || board[i][j] != word[count])
            {
                return false;
            }
            var temp = board[i][j];
            board[i][j] = ' ';
            var found = this.dfs(board, i + 1, j, count + 1, word) || this.dfs(board, i - 1, j, count + 1, word) || this.dfs(board, i, j + 1, count + 1, word) || this.dfs(board, i, j - 1, count + 1, word);
            board[i][j] = temp;
            return found;
        }
        // TC: O(m * n)
    }
}