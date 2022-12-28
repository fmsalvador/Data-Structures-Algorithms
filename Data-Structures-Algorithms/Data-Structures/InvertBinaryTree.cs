using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_Algorithms.Data_Structures
{
    public class InvertBinaryTree
    {
        public void Test()
        {
            TreeNode node = new TreeNode(2)
            {
                left = new TreeNode(1),
                right = new TreeNode(3)
            };
            Console.WriteLine("Original tree");
            PrintTree(node);
            InvertTree(node);
            Console.WriteLine("Inverted tree");
            PrintTree(node);

        }
        public TreeNode InvertTree(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }
            TreeNode left = InvertTree(node.left);
            TreeNode right = InvertTree(node.right);
            node.left = right;
            node.right = left;
            return node;
        }

        void PrintTree(TreeNode node)
        {
            if (node == null)
                return;

            PrintTree(node.left);
            Console.WriteLine(node.val + " ");
            PrintTree(node.right);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    //    As you are traversing each node of the binary tree only once, the time complexity of the above problem will be O(n),
    //    where ‘n’ is the total number of nodes in the binary tree.
    //    The space complexity of the above problem will be O(h).
    //    Here, the space complexity is directly proportional to the maximum depth of the recursion tree,
    //    which is equal to the height of the binary tree "h."
}
