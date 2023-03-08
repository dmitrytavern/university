// Lab #5
// Stack, queue and deque.
//
// Task: create a program that implements the formation of an increasing
// sequence based on a deque.
//
// Description: the first input value is the beginning of the deque. If
// the user enters a value greater than the first input value, it is
// placed on the right, otherwise on the left. If the value is equal
// to the input value, the user is prompted to choose whether to place it
// on the left or right. Output the resulting deque on the screen. The
// direction of output is specified by the user.
//

#include <iostream>

using namespace std;

struct dek_node
{
  int data;
  dek_node *prev;
  dek_node *next;
};

dek_node *CreateDek(int Data)
{
  dek_node *dekNode = new dek_node;
  dekNode->data = Data;
  dekNode->prev = NULL;
  dekNode->next = NULL;
  return dekNode;
}

int GetRight(dek_node *dek)
{
  while (dek->next != NULL)
    dek = dek->next;
  return dek->data;
}

int GetLeft(dek_node *dek)
{
  while (dek->prev != NULL)
    dek = dek->prev;
  return dek->data;
}

dek_node *PushLeft(dek_node *dek, int Data)
{
  dek_node *dekNode = new dek_node;
  while (dek->prev != 0)
    dek = dek->prev;
  dekNode->data = Data;
  dekNode->prev = NULL;
  dekNode->next = dek;
  dek->prev = dekNode;
  return dekNode;
}

dek_node *PushRight(dek_node *dek, int Data)
{
  dek_node *dekNode = new dek_node;
  while (dek->next != 0)
    dek = dek->next;
  dekNode->data = Data;
  dekNode->prev = dek;
  dekNode->next = NULL;
  dek->next = dekNode;
  return dekNode;
}

dek_node *DeleteRight(dek_node *dek)
{
  while (dek->next != 0)
    dek = dek->next;
  dek_node *tmp = dek;
  dek = dek->prev;
  if (dek != NULL)
    dek->next = NULL;
  delete tmp;
  return dek;
}

dek_node *DeleteLeft(dek_node *dek)
{
  while (dek->prev != 0)
    dek = dek->prev;
  dek_node *tmp = dek;
  dek = dek->next;
  if (dek != NULL)
    dek->prev = NULL;
  delete tmp;
  return dek;
}

dek_node *PrintDek(dek_node *dek, bool direction)
{
  int start_data = direction ? GetRight(dek) : GetLeft(dek);
  int currect_data = start_data;
  dek_node *tmpDek = CreateDek(start_data);

  cout << "  " << currect_data << " ";

  dek = direction ? DeleteRight(dek) : DeleteLeft(dek);

  while (dek != NULL)
  {
    currect_data = direction ? GetRight(dek) : GetLeft(dek);

    cout << currect_data << " ";

    tmpDek = direction ? PushLeft(tmpDek, currect_data) : PushRight(tmpDek, currect_data);
    dek = direction ? DeleteRight(dek) : DeleteLeft(dek);
  }

  return tmpDek;
}

int main()
{
  int first_node_data, printing_direction;

  cout << "Input first dek node: ";
  cin >> first_node_data;
  dek_node *dek = CreateDek(first_node_data);

  do
  {
    cout << "Currect dek: " << endl;
    dek = PrintDek(dek, false);
    cout << endl;

    int node_data;
    cout << "Input element: ";
    cin >> node_data;

    if (node_data == -1)
      break;

    if (first_node_data > node_data)
      dek = PushLeft(dek, node_data);

    if (first_node_data < node_data)
      dek = PushRight(dek, node_data);

    if (first_node_data == node_data)
    {
      string direction;
      cout << "Select direction (left/right): ";
      cin >> direction;

      if (direction == "left")
        dek = PushLeft(dek, node_data);

      if (direction == "right")
        dek = PushRight(dek, node_data);
    }
  } while (true);

  do
  {
    cout << "Select printing direction: left->right(0) / right->left(1): ";
    cin >> printing_direction;
  } while (printing_direction != 1 && printing_direction != 0);

  cout << "Result: " << endl;
  cout << "  Currect dek:\n  ";

  dek = PrintDek(dek, printing_direction);

  cout << endl;
  cout << "  Left: " << GetLeft(dek) << endl;
  cout << "  Center: " << first_node_data << endl;
  cout << "  Right: " << GetRight(dek) << endl;
  cout << "Exiting..." << endl;
}
