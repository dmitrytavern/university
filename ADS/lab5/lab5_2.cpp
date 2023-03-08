// Lab #5
// Stack, queue and deque.
//
// Task: given a queue of integers, swap each pair of adjacent elements from 
// the beginning of the queue until the end.
//

#include <stdio.h>
#include <iostream>
#include <conio.h>

using namespace std;

struct Queue
{
  int data;
  Queue *next;
};

void PrintQueue();
void Add(int data);
void Delete();
bool isEmpty(Queue *);

Queue *head;
Queue *tail;

int main()
{
  int elements_count;

  cout << "Input elements count: ";
  cin >> elements_count;

  for (int index = 0; index < elements_count; index++)
  {
    int data;
    cout << "Input element(" << index << "): ";
    cin >> data;
    Add(data);
  }

  cout << "Queue" << endl;
  PrintQueue();

  int temp;
  for (int index = 1; index <= elements_count; index++)
  {
    if (index % 2 == 1)
    {
      temp = head->data;
      if (index == elements_count)
        Add(temp);
    }
    else
    {
      Add(head->data);
      Add(temp);
    }

    Delete();
  }

  cout << "Queue after: " << endl;
  PrintQueue();
};

void Add(int data)
{
  Queue *temp = new Queue;
  temp->data = data;
  temp->next = NULL;
  if (isEmpty(head))
    head = tail = temp;
  else
  {
    tail->next = temp;
    tail = temp;
  }
}

void Delete()
{
  if (head != NULL)
  {
    Queue *tmp;
    int tint;
    tmp = head;
    head = head->next;
    tint = tmp->data;
    delete tmp;
  }
  else
  {
    cout << "Cannot delete element. Queue is empty" << endl;
  }
};

bool isEmpty(Queue *head)
{
  return (head == NULL) ? true : false;
}

void PrintQueue()
{
  Queue *Head = NULL;
  Queue *tempQueue = new Queue;
  Queue *tempHead = NULL;
  Head = head;

  if (isEmpty(head))
  {
    cout << "  Queue is empty" << endl;
    return;
  }

  tempQueue->data = 0;
  tempQueue->next = NULL;
  tempHead = tempQueue;

  while (head != NULL)
  {
    cout << "  NodeData: " << head->data << "\t NodeAddress: " << head << "\t NodeAddress Next: " << head->next << endl;

    tempQueue->next = new Queue;
    tempQueue->next->data = head->data;
    tempQueue->next->next = NULL;
    tempQueue = tempQueue->next;
    Delete();
  }

  tempQueue = tempHead->next;
  while (tempQueue)
  {
    Add(tempQueue->data);
    tempQueue = tempQueue->next;
  }

  Head = tempHead->next;
  while (Head)
  {
    tempQueue = Head;
    Head = Head->next;
    delete tempQueue;
  }
}