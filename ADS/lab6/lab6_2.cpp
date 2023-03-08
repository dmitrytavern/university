// Lab #6
// Binary Trees.
//
// Task: given a non-empty binary search tree, for each level of the tree starting
// from level zero, output the sum of the values of the nodes on that level.
// Assume that the depth of the tree does not exceed 10.
//

#include <iostream>
#include <iomanip>
#include <string>
#include <functional>
#ifdef __linux__
#include "./coniolinux.cpp"
#else
#include <conio.h>
#endif

using namespace std;

struct Tree
{
  int data;
  Tree *left;
  Tree *right;
};

void main_menu(char *input);
void press_enter();
void clear();

Tree *createTree(Tree *tree, int length);
Tree *createFirstElement(int data);
void addElement(Tree *root, int data);
void printTree(Tree *node, int deep_length);
void printTreePreOrder(Tree *Node);
void printTreePostOrder(Tree *Node);
void printTreeInOrder(Tree *Node);
void printTreeLevelSums(Tree *Node);
int getTreeHeight(Tree *p);

int main()
{
  Tree *root = NULL;
  char main_menu_task;

  do
  {
    clear();
    main_menu(&main_menu_task);
    clear();

    switch (main_menu_task)
    {
    case '1':
      int binary_tree_length;
      cout << "Input binary tree length: ";
      cin >> binary_tree_length;
      root = createTree(NULL, binary_tree_length);
      break;
    case '2':
      printTree(root, 0);
      press_enter();
      break;
    case '3':
      cout << "In order printing: ";
      printTreeInOrder(root);
      cout << "\nPre order printing: ";
      printTreePreOrder(root);
      cout << "\nPost order printing: ";
      printTreePostOrder(root);
      cout << "\n";
      press_enter();
      break;
    case '4':
      printTree(root, 0);
      printTreeLevelSums(root);
      press_enter();
      break;
    }

    if (main_menu_task == 'e')
      break;
  } while (true);
}

void main_menu(char *input)
{
  cout << "1 - Create birary tree" << endl;
  cout << "2 - Print binary tree" << endl;
  cout << "3 - Print binary tree in orders" << endl;
  cout << "4 - Print binary tree level sums" << endl;
  cout << "e - Exit" << endl;
  cout << "Your answer: ";
  cin >> *input;
}

Tree *createFirstElement(int data)
{
  Tree *root = new Tree;
  root->data = data;
  root->left = NULL;
  root->right = NULL;
  return root;
}

Tree *createTree(Tree *tree, int length)
{
  Tree *current = tree;
  Tree *root = NULL;
  int data, count = 0;

  while (count < length)
  {
    cout << "Enter data: ";
    cin >> data;

    if (current == NULL)
    {
      current = createFirstElement(data);
      root = current;
    }
    else
    {
      addElement(current, data);
    }

    count++;
  };

  return root;
}

void addElement(Tree *root, int data)
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

void printTreePreOrder(Tree *Node)
{
  if (Node != NULL)
  {
    cout << setw(3) << Node->data;
    printTreePreOrder(Node->left);
    printTreePreOrder(Node->right);
  }
}

void printTreePostOrder(Tree *Node)
{
  if (Node != NULL)
  {
    printTreePostOrder(Node->left);
    printTreePostOrder(Node->right);
    cout << setw(3) << Node->data;
  }
}

void printTreeInOrder(Tree *Node)
{
  if (Node != NULL)
  {
    printTreeInOrder(Node->left);
    cout << setw(3) << Node->data;
    printTreeInOrder(Node->right);
  }
}

void printTreeLevelSums(Tree *tree)
{
  int height = getTreeHeight(tree);
  int *row = new int[height];
  for (int index = 0; index < height; index++)
    row[index] = 0;

  std::function<void(Tree *, int)> treeAlgoritm = [&](Tree *node, int deep_length) -> void
  {
    if (node != NULL)
    {
      row[deep_length] += node->data;
      treeAlgoritm(node->left, deep_length + 1);
      treeAlgoritm(node->right, deep_length + 1);
    }
  };

  treeAlgoritm(tree, 0);

  cout << "Binary tree row sums: " << endl;
  for (int index = 1; index <= height; index++)
  {
    cout << "  Sum of " << index << " row: " << row[index - 1] << endl;
  }

  delete[] row;
}

int getTreeHeight(Tree *p)
{
  struct Tree *temp = p;
  int h1 = 0, h2 = 0;
  if (p == NULL)
    return (0);
  if (p->left)
  {
    h1 = getTreeHeight(p->left);
  }
  if (p->right)
  {
    h2 = getTreeHeight(p->right);
  }
  if (h1 >= h2)
    return h1 + 1;
  else
    return h2 + 1;
}

void press_enter()
{
  cout << "Enter to continue..." << endl;
  cin.ignore(10, '\n');
  cin.get();
}

void clear()
{
#ifdef __linux__
  system("clear");
#else
  system("cls");
#endif
}