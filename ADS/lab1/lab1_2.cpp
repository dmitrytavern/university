// Lab #1
// Recursion.
//
// Write a program-function that checks whether a given natural number n is prime.
//
// Description: Need to write a function that takes a positive integer as input
// and checks whether it is prime.
//

#include <iostream>

using namespace std;

bool isPrime(int number, int index);

int main()
{
  int number;

  cout << "Input number: ";
  cin >> number;

  if (isPrime(number, 1))
  {
    cout << "Result: this is prime number" << endl;
  }
  else
  {
    cout << "Result: this is not prime number" << endl;
  }
}

bool isPrime(int number, int index)
{
  int _index = index + 1;
  if (_index < number && (number % _index) != 0)
    return isPrime(number, _index);
  return _index == number;
}
