// Lab #4
// Doubly linked and cyclic lists.
//
// Task: create a program in which a linear bidirectional list of N elements
// is created.
//
// Description: Create a program that creates a linear bidirectional list of N
// elements, where the value of N and the list elements are entered by the user.
// The program should have the following menu options:
// - Create a list
// - Print the list
// - Insert an element after the element with the ordinal number M (input by the user).
//   The search for the element with the ordinal number M should be done from the
//   end of the list
// - Delete the last element of the list
// The list should be displayed in 3 lines: the value of the list element, the
// value of the field address, and the value of the pointer field.
//

#include <iostream>

using namespace std;

struct DoubleList
{
  int Data;
  DoubleList *Next;
  DoubleList *Prev;
};

void main_menu(char *input);

void CreateDoubleList(int length, DoubleList **Head, DoubleList **Tail);
void PrintDoubleList(DoubleList *Head);
void InsertItemDoubleListFromTail(DoubleList **Head, DoubleList **Tail, int list_length, int index, int data);
void DeleteLastItemDoubleList(DoubleList **Tail);
void press_enter();

int main()
{
  int double_list_length;
  char main_menu_task;
  DoubleList *Head = NULL;
  DoubleList *Tail = NULL;

  do
  {
    system("clear");
    main_menu(&main_menu_task);
    system("clear");

    switch (main_menu_task)
    {
    case '1':
      cout << "Input list length: ";
      cin >> double_list_length;
      CreateDoubleList(double_list_length, &Head, &Tail);
      break;
    case '2':
      PrintDoubleList(Head);
      press_enter();
      break;
    case '3':
      int index, value;
      cout << "Input index for insert item: ";
      cin >> index;
      cout << "Input node value: ";
      cin >> value;
      InsertItemDoubleListFromTail(&Head, &Tail, double_list_length, index, value);
      double_list_length++;
      break;
    case '4':
      DeleteLastItemDoubleList(&Tail);
      double_list_length--;

      if (double_list_length == 0)
      {
        Head = NULL;
        Tail = NULL;
      }
      break;
    }

    if (main_menu_task == 'e')
      break;
  } while (true);
}

void main_menu(char *input)
{
  cout << "1 - Create double list" << endl;
  cout << "2 - Output double list" << endl;
  cout << "3 - Insert node to double list" << endl;
  cout << "4 - Delete last item from list" << endl;
  cout << "e - Exit" << endl;
  cout << "Your answer: ";
  cin >> *input;
}

void CreateDoubleList(int length, DoubleList **Head, DoubleList **Tail)
{
  if (length > 0)
  {
    (*Head) = new DoubleList();
    cout << "Input node data: ";
    cin >> (*Head)->Data;
    (*Head)->Next = NULL;
    (*Head)->Prev = (*Tail);
    (*Tail) = (*Head);
    CreateDoubleList(length - 1, &((*Head)->Next), &(*Tail));
  }
}

void PrintDoubleList(DoubleList *Head)
{
  if (Head != NULL)
  {
    cout << "NodeData: " << Head->Data;
    cout << "\tNodeAddress: " << Head;
    cout << "\tNodeNextAddress: " << Head->Next;
    cout << "\tNodePrevAddress: " << Head->Prev;
    cout << endl;
    PrintDoubleList(Head->Next);
  }
}

void InsertItemDoubleListFromTail(DoubleList **Head, DoubleList **Tail, int list_length, int index, int data)
{
  DoubleList *NewItem = new DoubleList;
  NewItem->Data = data;
  NewItem->Prev = NULL;
  NewItem->Next = NULL;

  if (index < 0)
    index = 0;
  if (index > list_length)
    index = list_length;

  if (Head == NULL)
  {
    (*Head) = NewItem;
  }
  else
  {
    DoubleList *Current = (*Tail);
    for (int i = 0; i < list_length - index && Current->Prev != NULL; i++)
      Current = Current->Prev;

    if (index == 0)
    {
      NewItem->Next = (*Head);
      (*Head)->Prev = NewItem;
      (*Head) = NewItem;
    }
    else
    {
      if (Current->Next != NULL)
        Current->Next->Prev = NewItem;
      if (Current->Next == NULL)
        (*Tail) = NewItem;
      NewItem->Next = Current->Next;
      Current->Next = NewItem;
      NewItem->Prev = Current;
      Current = NewItem;
    }
  }
}

void DeleteLastItemDoubleList(DoubleList **Tail)
{
  if ((*Tail) != NULL)
  {
    DoubleList *LastItem = (*Tail);

    if ((*Tail)->Prev != NULL)
      (*Tail)->Prev->Next = NULL;

    (*Tail) = (*Tail)->Prev;
    delete (LastItem);
  }
}

void press_enter()
{
  cout << "Enter to continue..." << endl;
  cin.ignore(10, '\n');
  cin.get();
}
