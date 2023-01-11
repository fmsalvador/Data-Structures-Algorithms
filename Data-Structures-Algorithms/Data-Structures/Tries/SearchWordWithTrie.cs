using System;

namespace Data_Structures_Algorithms.Data_Structures
{
    //Trie is a type of search tree used for storing and searching a specific key from a set.
    //Using Trie, search complexities can be brought to optimal limit(key length). 
    //Is a based data structure that is used for storing some collection of strings and performing efficient search operations on them.
    //The word Trie is derived from reTRIEval, which means finding something or obtaining it.
    public class SearchWordWithTrie
    {
        static TrieNode root;

        public void Test()
        {
            // Input keys (use only 'a'
            // through 'z' and lower case)
            String[] keys = {"the", "a", "there", "answer",
                        "any", "by", "bye", "their"};

            String[] output = { "Not present in trie", "Present in trie" };


            root = new TrieNode();

            // Construct trie
            int i;
            for (i = 0; i < keys.Length; i++)
                Insert(keys[i]);

            // Search for different keys
            if (Search("the") == true)
                Console.WriteLine("the --- " + output[1]);
            else Console.WriteLine("the --- " + output[0]);

            if (Search("these") == true)
                Console.WriteLine("these --- " + output[1]);
            else Console.WriteLine("these --- " + output[0]);

            if (Search("their") == true)
                Console.WriteLine("their --- " + output[1]);
            else Console.WriteLine("their --- " + output[0]);

            if (Search("thaw") == true)
                Console.WriteLine("thaw --- " + output[1]);
            else Console.WriteLine("thaw --- " + output[0]);

        }

        static bool Search(String key)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';

                if (pCrawl.children[index] == null)
                    return false;

                pCrawl = pCrawl.children[index];
            }

            return (pCrawl.isEndOfWord);
        }

        static void Insert(String key)
        {
            int level;
            int length = key.Length;
            int index;

            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null)
                    pCrawl.children[index] = new TrieNode();

                pCrawl = pCrawl.children[index];
            }

            // mark last node as leaf
            pCrawl.isEndOfWord = true;
        }
    }

    public class TrieNode
    {
        static readonly int ALPHABET_SIZE = 26;

        public TrieNode[] children = new TrieNode[ALPHABET_SIZE];

        // isEndOfWord is true if the node represents
        // end of a word
        public bool isEndOfWord;

        public TrieNode()
        {
            isEndOfWord = false;
            for (int i = 0; i < ALPHABET_SIZE; i++)
                children[i] = null;
        }
    };

    //Insertion O(n)    O(n* m)
    //Searching O(n)    O(1)
}
