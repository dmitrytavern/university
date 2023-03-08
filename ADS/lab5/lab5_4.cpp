// Lab #5
// Stack, queue and deque.
//
// Task: using a stack data structure, solve the problem.
//
// Description: N people are arranged in a circle. Starting from the first
// person, every k-th person is removed, closing the circle after each removal.
// Determine the order in which people are removed from the circle, i.e. print
// the numbers of people in the order they are removed.
//

#include <iostream>

using namespace std;

struct Stack
{
  int data;
  Stack *prev;
};

Stack *createStack(Stack *, int count);
Stack *reverseStack(Stack *);
Stack *printStack(Stack *);
Stack *push(Stack *, int);
Stack *pop(Stack *);
bool isEmpty(Stack *);

int main()
{
  int count;
  int delete_index;
  Stack *stack = NULL;
  Stack *store_stack = NULL;

  cout << "Input members count: ";
  cin >> count;

  cout << "Input k delete node: ";
  cin >> delete_index;

  stack = createStack(stack, count);

  cout << "Stack: " << endl;
  stack = printStack(stack);

  cout << "Start deleting: " << endl;
  stack = reverseStack(stack);

  int index = 1;
  while (!isEmpty(stack))
  {
    if (index % delete_index == 0)
    {
      cout << "  Delete node: " << stack->data << endl;
    }
    else
    {
      store_stack = push(store_stack, stack->data);
    }

    stack = pop(stack);

    if (stack == NULL)
    {
      while (store_stack != NULL)
      {
        stack = push(stack, store_stack->data);
        store_stack = pop(store_stack);
      }
    }

    index++;
  }
}

Stack *createStack(Stack *top, int count)
{
  for (int index = 0; index < count; index++)
    top = push(top, index + 1);

  return top;
}

Stack *printStack(Stack *top)
{
  Stack *temp = NULL;

  if (isEmpty(top))
    cout << "  Stack is empty" << endl;

  while (top != NULL)
  {
    cout << "  NodeData: " << top->data << "\t NodeAddress: " << top << "\t Node Address previous: " << top->prev << endl;
    temp = push(temp, top->data);
    top = pop(top);
  }

  while (temp != NULL)
  {
    top = push(top, temp->data);
    temp = pop(temp);
  }

  return top;
}

Stack *reverseStack(Stack *top)
{
  Stack *temp = NULL;

  while (top != NULL)
  {
    temp = push(temp, top->data);
    top = pop(top);
  }

  return temp;
}

Stack *push(Stack *top, int data)
{
  Stack *temp = new Stack;
  if (top == NULL)
    temp->prev = NULL;
  else
    temp->prev = top;
  temp->data = data;
  return temp;
}

Stack *pop(Stack *top)
{
  Stack *temp = NULL;
  temp = top;
  top = top->prev;
  delete temp;
  return top;
}

bool isEmpty(Stack *top)
{
  return top == NULL;
}