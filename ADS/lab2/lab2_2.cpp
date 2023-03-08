// Lab #2
// Pointer.
//
// Task: Determine the number of prime numbers among 10 numbers using a variable
// number of arguments function.
//
// Description: You need to write a function that takes a variable number of
// arguments (10 in this case) and determines how many of them are prime.
// The function should return the number of prime numbers among the input arguments.
//
// Result: code works only on 32bit
//

#include <iostream>
#include <stdarg.h>

using namespace std;

int getSimpleNumberCount(int numbers, ...);
bool isPrime(int number, int index);

int main()
{
  int count_1 = getSimpleNumberCount(2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 0);

  cout << "Result: from (2, 3, 4, 5, 6, 7, 8, 9, 10, 12) only " << count_1 << " is prime numbers" << endl;
}

int getSimpleNumberCount(int numbers, ...)
{
  int count = 0;

  for (int *pointer = &numbers; (*pointer) != 0; pointer++)
    if (isPrime(*pointer, 1))
      count++;

  return count;
}

bool isPrime(int number, int index)
{
  int _index = index + 1;
  if (_index < number && (number % _index) != 0)
    return isPrime(number, _index);
  return _index == number;
}
