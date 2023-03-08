// Lab #5
// Stack, queue and deque.
//
// Task: create a dynamic stack based on a linear singly connected list.
//
// Description:
// The program should contain the following functions:
// - Insertion into the stack (push);
// - Deletion from the stack (pop);
// - Checking the emptiness of the stack (isEmpty);
// - Viewing the contents of the stack (print) using an additional data structure.
//
// After creation, move the top of the stack to the bottom using an auxiliary stack.
//

#include <iostream>

using namespace std;

struct Stack
{
  int data;
  Stack *prev;
};

Stack *createStack(Stack *);
Stack *reverseStack(Stack *);
Stack *printStack(Stack *);
Stack *push(Stack *, int);
Stack *pop(Stack *);
bool isEmpty(Stack *);

int main()
{
  Stack *stack = NULL;
  Stack *store_stack = NULL;

  cout << "If stack is empty" << endl;
  stack = printStack(stack);

  stack = createStack(stack);

  cout << "Stack: " << endl;
  stack = printStack(stack);

  store_stack = push(store_stack, stack->data);
  stack = pop(stack);

  stack = reverseStack(stack);

  while (stack != NULL)
  {
    store_stack = push(store_stack, stack->data);
    stack = pop(stack);
  }

  cout << "New stack: " << endl;
  store_stack = printStack(store_stack);
}

Stack *createStack(Stack *top)
{
  int count;
  cout << "Count: ";
  cin >> count;

  for (int index = 0; index < count; index++)
  {
    int random_number = rand() % (100 - 0 + 1) + 0;
    top = push(top, random_number);
  }

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