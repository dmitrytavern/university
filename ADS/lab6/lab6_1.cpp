// Lab #6
// Binary Trees.
//
// Task: create a program for working with a binary search tree.
//
// Description:
// Implement the following:
// - Adding elements to the binary search tree. The values of the elements are
// entered by the user from the keyboard. The first added element becomes the root
// node of the binary tree. Adding is done according to the algorithm for building
// a binary search tree.
// - Displaying the tree on the screen.
// - Find the number of leaves in the tree.
//

#include <iostream>
#include <iomanip>
#include <string>
#ifdef __linux__
#include "./coniolinux.cpp"
#else
#include <conio.h>
#endif

using namespace std;

struct Tree
{
  double data;
  Tree *left;
  Tree *right;
};

Tree *createTree(Tree *tree);
Tree *createFirstElement(double data);
void addElement(Tree *root, double data);
void printTree(Tree *node, int deep_length);
int getLeavesCount(Tree *node);

int main()
{
  Tree *root = NULL;

  root = createTree(root);

  printTree(root, 0);

  cout << "Leaves: " << getLeavesCount(root) << endl;
}

Tree *createFirstElement(double data)
{
  Tree *root = new Tree;
  root->data = data;
  root->left = NULL;
  root->right = NULL;
  return root;
}

Tree *createTree(Tree *tree)
{
  Tree *current = tree;
  Tree *root = NULL;
  double data;

  do
  {
    cout << "Enter data: ";
    cin >> data;

    if (data == -1)
      break;

    if (current == NULL)
    {
      current = createFirstElement(data);
      root = current;
    }
    else
    {
      addElement(current, data);
    }
  } while (true);

  return root;
}

void addElement(Tree *root, double data)
{
  Tree *current = root, *previous = NULL;
  Tree *leaf = new Tree;

  while (current)
  {
    previous = current;
    if (data < current->data)
      current = current->left;
    else
      current = current->right;
  }

  leaf->data = data;
  leaf->left = NULL;
  leaf->right = NULL;

  if (leaf->data < previous->data)
    previous->left = leaf;
  else
    previous->right = leaf;
}

void printTree(Tree *node, int deep_length)
{
  string spaces = "";
  for (int index = 0; index < deep_length; index++)
    spaces += " ";

  if (node != NULL)
  {
    cout << node->data << endl;

    if (node->right != NULL)
    {
      cout << spaces << " Right: ";
      printTree(node->right, deep_length + 1);
    }

    if (node->left != NULL)
    {
      cout << spaces << " Left: ";
      printTree(node->left, deep_length + 1);
    }
  }
  else
  {
    cout << endl;
  }
}

int getLeavesCount(Tree *node)
{
  if (node != NULL)
  {
    int count = 0;

    if (node->right != NULL)
      count += getLeavesCount(node->right);

    if (node->left != NULL)
      count += getLeavesCount(node->left);

    if (node->right == NULL && node->left == NULL)
      return 1;

    return count;
  }

  return 0;
}
