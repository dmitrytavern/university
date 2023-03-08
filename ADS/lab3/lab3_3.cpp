// Lab #3
// Dynamic memory allocation.
//
// Task: Obtain a sequence of characters containing only the last occurrences
// of each character in the string, while preserving their original order.
//
// Description: given a sequence of characters s1, s2, ..., sn (n >= 2 and unknown in advance).
// Write a program that takes a string of characters as input and outputs a new
// string that contains only the last occurrence of each character in the original
// string, while preserving their original order.
//

#include <iostream>

using namespace std;

struct Node
{
  char Data;
  Node *Next;
};

void create_single_list(Node **Head, int length);
void output_last_chars(Node *Head, int length);

int main()
{
  int single_list_length;
  Node *Head;
  Node *Current;

  do
  {
    cout << "Input char list length (>=2): ";
    cin >> single_list_length;
  } while (single_list_length < 2);

  create_single_list(&Head, single_list_length);
  output_last_chars(Head, single_list_length);
}

void create_single_list(Node **Head, int length)
{
  if (length > 0)
  {
    (*Head) = new Node();
    cout << "Input char: ";
    cin >> (*Head)->Data;
    (*Head)->Next = NULL;
    create_single_list(&(*Head)->Next, length - 1);
  }
}

void output_last_chars(Node *Head, int length)
{
  Node *Current = Head;

  cout << "Result: ";

  while (Current != NULL)
  {
    bool exists = false;
    Node *CurrentForCompare = Current->Next;

    while (CurrentForCompare != NULL)
    {
      if (Current->Data == CurrentForCompare->Data)
        exists = true;
      CurrentForCompare = CurrentForCompare->Next;
    }

    if (!exists)
      cout << Current->Data << " ";
    Current = Current->Next;
  }

  cout << endl;
}
