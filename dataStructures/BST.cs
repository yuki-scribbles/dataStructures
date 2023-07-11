using Microsoft.VisualBasic.FileIO;
using System;
using System.Xml.Linq;

namespace dataStructures {
    public class BST
    {
        public BtreeNode? root;

        //2 constructors: one with no elements and one with a root
        public BST()
        {
            this.root = null;
        }

        public BST(int val)
        {
            this.root = new BtreeNode(val);
        }

        /*BST node constructor
         * data = value of node
         * reference to parent node and the nodes 2 children
         */
        public class BtreeNode
        {
            public int data;
            public BtreeNode? parent;
            public BtreeNode? rChild;
            public BtreeNode? lChild;
            public BtreeNode(int val) { 
                this.data = val;
            }
        }

        /*Adds a node with data = val
         */
        public void Add(int val) { 
            //makes the new node
            BtreeNode node = new BtreeNode(val);

            //if there's no elements, you make the new node the root
            //else, navigate to the place where the node belongs to and add there
            if (root == null)
            {
                root = node;
            }
            else {

                //navigates to spot to place the new node
                BtreeNode currentNode = root;

                BtreeAdd(root, node);
            }
        }
        
        //helps Add method by finding place of the new node
        public void BtreeAdd(BtreeNode currentNode, BtreeNode node) {
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
        public int? Remove(int val)
        {
            BtreeNode? currentNode = search(val);

            //2 cases: you either found a null node and value doesn't exist, or you found the node and you'll need to remove it
            if (currentNode == null)
            {
                return null;
            }
            else {
                BtreeNode deleteNode = currentNode;

                //cases: node has no children, node has 1 child, node has 2 children
                if (deleteNode.rChild == null && deleteNode.lChild == null) {
                    //3 cases for no children: the node is root, node is leaf and a left child of its parent, and node is leaf and right child of its parent
                    if (deleteNode.parent == null) {
                        root = null;
                    }
                    else if (deleteNode.parent.lChild == deleteNode)
                    {
                        deleteNode.parent.lChild = null;
                    }
                    else {
                        deleteNode.parent.rChild = null;
                    }
                    deleteNode.parent = null;
                }
                else if (deleteNode.rChild == null && deleteNode.lChild != null)
                {
                    //2 cases for node having left child: deleted node is left child of its parent or right child of its parent
                    if (deleteNode.parent.lChild == deleteNode)
                    {
                        deleteNode.parent.lChild = deleteNode.lChild;
                    }
                    else { 
                        deleteNode.parent.rChild = deleteNode.lChild;
                    }

                    deleteNode.lChild.parent = deleteNode.parent;
                    deleteNode.parent = null;
                }
                else if (deleteNode.rChild != null && deleteNode.lChild == null)
                {
                    //2 cases for node having a right child: node is left child of parent or right child of parent
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
                {   //if node has 2 children, you need to first find sucessor node that will replace it by being removed. Reassignment of references then occur.
                    BtreeNode successor = findSuccessor(currentNode);
                    Remove(successor.data);
                    if (deleteNode.parent == null) {
                        root = successor;
                    } else if (deleteNode.parent.rChild == deleteNode) {
                        deleteNode.parent.rChild = successor;
                    } else
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

        //finds a node's right child's left most element
        private BtreeNode findSuccessor(BtreeNode node)
        {
            node = node.rChild;
            while (node.lChild != null)
            {
                node = node.lChild;
            }
            return node;
        }

        //checks if tree has a certain value
        public bool Has(int val) {
            BtreeNode currentNode = search(val);

            //2 cases: you either found a null node and value doesn't exist, or you found the node and you return true
            if (currentNode == null)
            {
                return false;
            }
            else {
                return true;
            }
        }

        //looks for a node in the binary tree with a certain val. Will return null if not present and the node itself if it is present.
        private BtreeNode? search(int val) {
            BtreeNode? currentNode = root;
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
        
        //finds height of the tree
        public int Height()
        {
            return findHeight(root);
        }

        //finds height of a ndoe
        private static int findHeight(BtreeNode? node)
        {   if (node == null) {
                return 0;
            }
            else if (node.lChild == null && node.rChild == null)
            {
                return 1;
            }
            else
            {
                int lHeight = findHeight(node.lChild);
                int rHeight = findHeight(node.rChild);
                if (lHeight > rHeight) { 
                    return (1 + lHeight);
                }
                else
                {
                    return (1 + rHeight);
                }
            }
        }

        //gets string of a node and all of its descendents
        static void Stringer(BtreeNode node) {
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
            s += "\tright: ";

            if (node.rChild != null)
            {
                s += node.rChild.data;
            }


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
        public void print()
        {
            Stringer(root);
            Console.Write("------------------------------------------------------------\n");
        }
    }
}

