// Lab #3
// Dynamic memory allocation.
//
// Task: create a program in which a singly linked list is created.
//
// Description: the program should allow the user to create a singly linked list 
// of elements. The user should then be able to print the list, add an element 
// after a specified element, and output the number of odd elements in the list.
//
// The program should print the list in 3 lines for each element: the value of 
// the list element, the address value of the field, and the value of the pointer 
// field.
//

#include <iostream>

using namespace std;

struct Node
{
  int Data;
  Node *Next;
};

void main_menu(char *input);

void create_single_list(Node **Head, int length);
void print_single_list(Node *Head);
Node *insert_node_to_single_list(Node *Head, int Number, int DataItem);
void press_enter();

int main()
{
  int single_list_length;
  char main_menu_task;
  Node *Head;
  Node *Current;

  do
  {
    system("clear");
    main_menu(&main_menu_task);
    system("clear");

    switch (main_menu_task)
    {
    case '1':
      cout << "Input list length: ";
      cin >> single_list_length;
      create_single_list(&Head, single_list_length);
      break;
    case '2':
      print_single_list(Head);
      press_enter();
      break;
    case '3':
      int position, data;
      cout << "Input position of single list: ";
      cin >> position;
      cout << "Input data: ";
      cin >> data;
      Head = insert_node_to_single_list(Head, position, data);
      single_list_length++;
      break;
    case '4':
      int count = 0;
      Node *Current = Head;

      if (single_list_length > 0)
      {
        do
        {
          if (Current->Data % 2 != 0)
            count++;
          Current = Current->Next;
        } while (Current != NULL);
      }

      cout << "Count of odd elements: " << count << endl;
      press_enter();
      break;
    }

    if (main_menu_task == 'e')
      break;
  } while (true);
}

void main_menu(char *input)
{
  cout << "1 - Create single list" << endl;
  cout << "2 - Output single list" << endl;
  cout << "3 - Insert node to signle list" << endl;
  cout << "4 - Ouput count of odd nodes" << endl;
  cout << "e - Exit" << endl;
  cout << "Your answer: ";
  cin >> *input;
}

void create_single_list(Node **Head, int length)
{
  if (length > 0)
  {
    (*Head) = new Node();
    cout << "Input node data: ";
    cin >> (*Head)->Data;
    (*Head)->Next = NULL;
    create_single_list(&(*Head)->Next, length - 1);
  }
}

void print_single_list(Node *Head)
{
  if (Head != NULL)
  {
    cout << "NodeData: " << Head->Data;
    cout << "  NodeAddress: " << Head;
    cout << "  NodeDataAddress: " << (Head->Next) << endl;
    cout << endl;
    print_single_list(Head->Next);
  }
}

Node *insert_node_to_single_list(Node *Head, int position, int data)
{
  position--;

  Node *NewItem = new Node;
  NewItem->Data = data;
  NewItem->Next = NULL;

  if (Head == NULL)
  {
    Head = NewItem;
  }
  else
  {
    Node *Current = Head;

    for (int i = 1; i <= position && Current->Next != NULL; i++)
      Current = Current->Next;

    if (position == 0)
    {
      NewItem->Next = Head;
      Head = NewItem;
    }
    else
    {
      if (Current->Next != NULL)
        NewItem->Next = Current->Next;
      Current->Next = NewItem;
    }
  }

  return Head;
}

void press_enter()
{
  cout << "Enter to continue..." << endl;
  cin.ignore(10, '\n');
  cin.get();
}
