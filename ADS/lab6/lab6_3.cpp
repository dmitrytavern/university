// Lab #6
// Binary Trees.
//
// Task: given a non-empty binary tree, add a new leaf node to every leaf
// node of the tree. If the value of the original leaf node is odd, add a
// new left child node, and if it's even, add a new right child node. Set
// the value of each new node to be equal to its parent node's value.
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

#define TREE_ADD_ELEMENT 1
#define TREE_ADD_ELEMENT_INTERACTIVE 2
#define TREE_ADD_ELEMENT_TO_LEFT 3
#define TREE_ADD_ELEMENT_TO_RIGHT 4

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
Tree *findNode(Tree *Node, int target);
void addElement(int signum, Tree *root, int data);
void printTree(Tree *node, int deep_length);
void printTreePreOrder(Tree *Node);
void printTreePostOrder(Tree *Node);
void printTreeInOrder(Tree *Node);
void addElementForLeaves(Tree *Node);

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
      cout << "Tree created!" << endl;
      press_enter();
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
      cout << "Tree before:" << endl;
      printTree(root, 0);

      addElementForLeaves(root);

      cout << endl
           << "============" << endl
           << endl;

      cout << "Tree after:" << endl;
      printTree(root, 0);
      press_enter();
      break;
    }

    if (main_menu_task == 'e')
      break;
  } while (true);
}

void main_menu(char *input)
{
  cout << "1 - Create arbitrary birary tree" << endl;
  cout << "2 - Print binary tree" << endl;
  cout << "3 - Print binary tree in orders" << endl;
  cout << "4 - Add element for leaves" << endl;
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
    Tree *node;
    do
    {
      cout << "Enter data: ";
      cin >> data;
      node = findNode(root, data);
      if (node != NULL)
        cout << "  error: Node already exists in tree" << endl;
    } while (node != NULL);

    if (current == NULL)
    {
      current = createFirstElement(data);
      root = current;
    }
    else
    {
      addElement(TREE_ADD_ELEMENT_INTERACTIVE, current, data);
    }

    count++;
  };

  return root;
}

void addElement(int signum, Tree *root, int data)
{
  Tree *leaf = new Tree;
  leaf->data = data;
  leaf->left = NULL;
  leaf->right = NULL;

  switch (signum)
  {
  case TREE_ADD_ELEMENT:
  {
    Tree *current = root, *previous = NULL;

    while (current)
    {
      previous = current;
      if (data < current->data)
        current = current->left;
      else
        current = current->right;
    }

    if (leaf->data < previous->data)
      previous->right = leaf;
    else
      previous->left = leaf;
    break;
  }

  case TREE_ADD_ELEMENT_INTERACTIVE:
  {
    Tree *node;
    int target;
    bool target_value_valid, target_side_valid;
    do
    {
      cout << "Node " << data << ": select node: ";
      cin >> target;
      node = findNode(root, target);
      target_value_valid = node == NULL;
      target_side_valid = node != NULL && (node->left != NULL && node->right != NULL);

      if (target_value_valid)
        cout << "  error: Node not exists!" << endl;

      if (target_side_valid)
        cout << "  error: Node already have right and left node!" << endl;
    } while (target_value_valid || target_side_valid);

    int side;
    bool side_value_valid, side_left_exists, side_right_exists;
    do
    {
      cout << "Node " << data << ": select side (left(0) or right(1)): ";
      cin >> side;
      side_value_valid = side != 1 && side != 0;
      side_left_exists = side == 0 && node->left != NULL;
      side_right_exists = side == 1 && node->right != NULL;

      if (side_value_valid)
        cout << "  error: Value is not correct!" << endl;
      if (side_left_exists)
        cout << "  error: Left side already busy!" << endl;
      if (side_right_exists)
        cout << "  error: Right side already busy!" << endl;
    } while (side_value_valid || side_left_exists || side_right_exists);

    if (side)
      node->right = leaf;
    else
      node->left = leaf;
    break;
  }

  case TREE_ADD_ELEMENT_TO_LEFT:
  {
    root->left = leaf;
    break;
  }
  case TREE_ADD_ELEMENT_TO_RIGHT:
  {
    root->right = leaf;
    break;
  }
  }
}

Tree *findNode(Tree *Node, int target)
{
  if (Node != NULL)
  {
    if (Node->data == target)
      return Node;

    Tree *leftResult = findNode(Node->left, target);
    Tree *rightResult = findNode(Node->right, target);

    if (leftResult != NULL)
      return leftResult;

    if (rightResult != NULL)
      return rightResult;
  }

  return NULL;
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

void addElementForLeaves(Tree *node)
{
  if (node != NULL)
  {
    if (node->right == NULL && node->left == NULL)
    {
      if (node->data % 2 == 0)
      {
        addElement(TREE_ADD_ELEMENT_TO_RIGHT, node, node->data);
      }
      else
      {
        addElement(TREE_ADD_ELEMENT_TO_LEFT, node, node->data);
      }
    }
    else
    {
      addElementForLeaves(node->left);
      addElementForLeaves(node->right);
    }
  }
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