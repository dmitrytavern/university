// Lab #4
// Doubly linked and cyclic lists.
//
// Task: organize a doubly linked circular list and obtain the sequence:
// yn, yn-1, ..., y1, y1, ..., yn.
//
// Description: given real numbers y1, y2, ..., yn (n >= 2 and is not known in advance).
// Create a doubly linked circular list and store the given real numbers
// in it and obtain the sequence: yn, yn-1, ..., y1, y1, ..., yn. Print
// the resulting sequence of values.
//

#include <iostream>

using namespace std;

struct DoubleList
{
  int Data;
  DoubleList *Next;
  DoubleList *Prev;
};

void CreateDoubleList(int length, DoubleList **Head, DoubleList **Tail);
void Push(DoubleList **Tail, int data);
void PrintList(DoubleList *Head);

int main()
{
  int double_list_length;
  char main_menu_task;
  DoubleList *Head = NULL;
  DoubleList *Tail = NULL;

  do
  {
    cout << "Input char list length (>=2): ";
    cin >> double_list_length;
  } while (double_list_length < 2);

  CreateDoubleList(double_list_length, &Head, &Tail);

  DoubleList *Current = Tail;
  do
  {
    Push(&Tail, Current->Data);
    Current = Current->Prev;
  } while (Current);

  PrintList(Head);
}

void Push(DoubleList **Tail, int data)
{
  (*Tail)->Next = new DoubleList();
  (*Tail)->Next->Data = data;
  (*Tail)->Next->Prev = (*Tail);
  (*Tail) = (*Tail)->Next;
}

void PrintList(DoubleList *Head)
{
  cout << "Order: ";
  DoubleList *Current = Head;
  while (Current != NULL)
  {
    cout << Current->Data << " ";
    Current = Current->Next;
  }
  cout << endl;
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

void press_enter()
{
  cout << "Enter to continue..." << endl;
  cin.ignore(10, '\n');
  cin.get();
}
