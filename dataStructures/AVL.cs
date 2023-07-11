using System;
using System.ComponentModel;
using System.Data;
using System.Numerics;

namespace dataStructures
{
    public class AVL : BST
    {
        int height;
        new TreeNode? root;

        public AVL() : base()
        {
            root = null;
        }

        public class TreeNode
        {
            public int height, data;
            public TreeNode? parent, rChild, lChild;
            public TreeNode (int val)
            {
                this.data = val;
                height = 1;
            }
        }

        new public void Add(int val)
        {
            //makes the new node
            TreeNode node = new TreeNode(val);

            //if there's no elements, you make the new node the root
            //else, navigate to the place where the node belongs to and add there
            if (root == null)
            {
                root = node;
            }
            else
            {
                //navigates to spot to place the new node
                TreeNode? currentNode = root;
                BtreeAdd(root, node);
                
                //now that the node has a parent, you go from the newly placed node up to its parents and update any heights. It also checks for balance here
                currentNode = node.parent;

                //keep going up the tree until you reach the root
                while (currentNode != null) {
                    //as you go up, you update the height and also check if the node is balanced. If it's unbalanced, you move to the bottom most node of the trinode structure and start the rotation.
                    if (isBalanced(currentNode) == false)
                    {
                        TreeNode x = currentNode;
                        if (x.rChild == null || x.lChild.height > x.rChild.height)
                        {
                            x = x.lChild;
                        }
                        else
                        {
                            x = x.rChild;
                        }

                        if (x.rChild == null || x.lChild.height > x.rChild.height)
                        {
                            x = x.lChild;
                        }
                        else
                        {
                            x = x.rChild;
                        }

                        Restructure(x);
                    }

                    updateHeight(currentNode);
                    currentNode = currentNode.parent;
                }
            }
        }

        //currentNode is the node you're comparing with the node you're trying to add
        //
        new public void BtreeAdd(TreeNode currentNode, TreeNode node)
        {
            if (node.data < currentNode.data)
            {
                if (currentNode.lChild == null)
                {
                    currentNode.lChild = node;
                    node.parent = currentNode;
                }
                else
                {
                    BtreeAdd(currentNode.lChild, node);
                }
            }
            else if (node.data > currentNode.data)
            {
                if (currentNode.rChild == null)
                {
                    currentNode.rChild = node;
                    node.parent = currentNode;
                }
                else
                {
                    BtreeAdd(currentNode.rChild, node);
                }
            }
        }

        //removes a node with val and returns null if the node doesn't exist
        new public int? Remove(int val)
        {
            TreeNode? currentNode = search(val);

            //2 cases: you either found a null node and value doesn't exist, or you found the node and you'll need to remove it
            if (currentNode == null)
            {
                return null;
            }
            else
            {
                TreeNode deleteNode = currentNode;

                //cases: node is root and only item, node is a leaf, node has 1 child, node has 2 children
                if (deleteNode.rChild == null && deleteNode.lChild == null)
                {
                    if (deleteNode.parent == null)
                    {
                        root = null;
                    }
                    else if (deleteNode.parent.lChild == deleteNode)
                    {
                        deleteNode.parent.lChild = null;
                    }
                    else
                    {
                        deleteNode.parent.rChild = null;
                    }
                    deleteNode.parent = null;
                }
                else if (deleteNode.rChild == null && deleteNode.lChild != null)
                {
                    if (deleteNode.parent.lChild == deleteNode)
                    {
                        deleteNode.parent.lChild = deleteNode.lChild;
                    }
                    else
                    {
                        deleteNode.parent.rChild = deleteNode.lChild;
                    }

                    deleteNode.lChild.parent = deleteNode.parent;
                    deleteNode.parent = null;
                }
                else if (deleteNode.rChild != null && deleteNode.lChild == null)
                {
                    if (deleteNode.parent.lChild == deleteNode)
                    {
                        deleteNode.parent.lChild = deleteNode.rChild;
                    }
                    else
                    {
                        deleteNode.parent.rChild = deleteNode.rChild;
                    }

                    deleteNode.rChild.parent = deleteNode.parent;
                    deleteNode.parent = null;
                }
                else
                {
                    TreeNode successor = findSuccessor(currentNode);
                    Remove(successor.data);
                    if (deleteNode.parent == null)
                    {
                        root = successor;
                    }
                    else if (deleteNode.parent.rChild == deleteNode)
                    {
                        deleteNode.parent.rChild = successor;
                    }
                    else
                    {
                        deleteNode.parent.lChild = successor;
                    }

                    successor.parent = deleteNode.parent;
                    deleteNode.parent = null;
                    successor.rChild = deleteNode.rChild;
                    deleteNode.rChild.parent = successor;
                    successor.lChild = deleteNode.lChild;
                    deleteNode.lChild.parent = successor;
                }

                return deleteNode.data;
            }

        }
        private TreeNode findSuccessor(TreeNode node)
        {
            node = node.rChild;
            while (node.lChild != null)
            {
                node = node.lChild;
            }
            return node;
        }
        private TreeNode? search(int val)
        {
            TreeNode? currentNode = root;
            //search for position of node you want to remove
            while (currentNode != null)
            {   //3 cases: move left if value is less than currentnode, right if greater than, and leave if it's equal to it and you found the spot
                if (val < currentNode.data)
                {
                    currentNode = currentNode.lChild;
                }
                else if (val > currentNode.data)
                {
                    currentNode = currentNode.rChild;
                }
                else
                {
                    break;
                }
            }
            return currentNode;
        }
        private bool updateHeight(TreeNode node) {
            //default height of 1 if there are no children nodes
            int height = 1;

            //if right child exists, you make the height based on the right child node
            if (node.rChild != null) {
                height += node.rChild.height;
            }
            //if the left child exists and the expected height is greater than if you calculated it with the right child, you update height to be based on the left child
            if (node.lChild != null && node.lChild.height + 1 > height) { 
                height = node.lChild.height + 1;
            }

            if (node.height == height) {
                return false;
            } else
            {
                node.height = height;
                return true;
            }
        }
        private bool isBalanced(TreeNode node) {
            int bf = 0;
            if (node.rChild != null)
            {
                bf -= node.rChild.height;
            }
            if (node.lChild != null)
            {
                bf += node.lChild.height;
            }

            if(bf >= -1 &&  bf <= 1)
            {
                return true;
            } else { 
                return false; 
            }
        }
        private void Restructure(TreeNode x)
        {   //if the 3 nodes being restructured are in a straight line or in a zig zag formation
            if (x.parent.rChild == x && x.parent.parent.rChild == x.parent || x.parent.lChild == x && x.parent.parent.lChild == x.parent)
            {
                Rotate(x.parent);
            }
            else {
                Rotate(x);
                Rotate(x);
            }
        }
        private void Rotate(TreeNode x) {
            TreeNode[] uprootedNodes = new TreeNode[2];
            TreeNode? grandparent = x.parent.parent;
            if (x.parent.rChild == x)
            {
                if (grandparent == null) { 
                    

                }
                //do left rotation
            }
            else { 
                //do right rotation
            }
        }

        //gets string of a node and all of its descendents
        static void Stringer(TreeNode node)
        {
            String s = "parent: ";
            if (node.parent != null)
            {
                s += node.parent.data;
            }
            s += "\tvalue: " + node.data + "\t left: ";

            if (node.lChild != null)
            {
                s += node.lChild.data;
            }
            s += " \tright: ";

            if (node.rChild != null)
            {
                s += node.rChild.data;
            }

            s += " \theight: " + node.height;

            Console.Write(s + "\n");

            if (node.lChild != null)
            {
                Stringer(node.lChild);
            }
            if (node.rChild != null)
            {
                Stringer(node.rChild);
            }
        }
        new public void print()
        {
            Stringer(root);
            Console.Write("------------------------------------------------------------\n");
        }
    }
}

