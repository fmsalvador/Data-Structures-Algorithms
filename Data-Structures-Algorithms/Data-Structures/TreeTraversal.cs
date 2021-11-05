using System;

namespace Data_Structures_Algorithms.Data_Structures
{
    public class Node
    {
        public int key;
        public Node left, right;

        public Node(int item)
        {
            key = item;
            left = right = null;
        }
    }

    public class TreeTraversal
    {
        // Root of Binary Tree
        Node root;

        void PrintPostorder(Node node)
        {
            if (node == null)
                return;

            // first recur on left subtree
            PrintPostorder(node.left);

            // then recur on right subtree
            PrintPostorder(node.right);

            // now deal with the node
            Console.Write(node.key + " ");
        }

        void PrintInorder(Node node)
        {
            if (node == null)
                return;

            /* first recur on left child */
            PrintInorder(node.left);

            /* then print the data of node */
            Console.Write(node.key + " ");

            /* now recur on right child */
            PrintInorder(node.right);
        }

        void PrintPreorder(Node node)
        {
            if (node == null)
                return;

            /* first print data of node */
            Console.Write(node.key + " ");

            /* then recur on left subtree */
            PrintPreorder(node.left);

            /* now recur on right subtree */
            PrintPreorder(node.right);
        }

        void PrintPostorder() { PrintPostorder(root); }
        void PrintInorder() { PrintInorder(root); }
        void PrintPreorder() { PrintPreorder(root); }

        public virtual void PrintLevelOrder()
        {
            int h = Height(root);
            int i;
            for (i = 1; i <= h; i++)
            {
                PrintCurrentLevel(root, i);
            }
        }

        /// <summary>
        /// Compute the "height" of a tree
        /// the number of nodes along the longest
        /// path from the root node down to the
        /// farthest leaf node
        /// </summary>
        public virtual int Height(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                int lheight = Height(root.left);
                int rheight = Height(root.right);

                if (lheight > rheight)
                {
                    return (lheight + 1);
                }
                else
                {
                    return (rheight + 1);
                }
            }
        }

        public virtual void PrintCurrentLevel(Node root, int level)
        {
            if (root == null)
            {
                return;
            }
            if (level == 1)
            {
                Console.Write(root.key + " ");
            }
            else if (level > 1)
            {
                PrintCurrentLevel(root.left, level - 1);
                PrintCurrentLevel(root.right, level - 1);
            }
        }

        public void Test()
        {
            /*
            *               1
            *              / \
            *             2   3
            *            / \  
            *           4    5    
            *
            * Depth First Traversals:
            * (a) Inorder(Left, Root, Right) : 4 2 5 1 3
            * (b) Preorder(Root, Left, Right) : 1 2 4 5 3
            * (c) Postorder(Left, Right, Root) : 4 5 2 3 1
            * Breadth First or Level Order Traversal: 1 2 3 4 5
            */

            TreeTraversal tree = new TreeTraversal
            {
                root = new Node(1)
            };

            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            Console.WriteLine("Preorder traversal of binary tree is ");
            tree.PrintPreorder();

            Console.WriteLine("\nInorder traversal of binary tree is ");
            tree.PrintInorder();

            Console.WriteLine("\nPostorder traversal of binary tree is ");
            tree.PrintPostorder();

            Console.WriteLine("\nLevel order traversal of binary tree is ");
            tree.PrintLevelOrder();
        }
    }
}
