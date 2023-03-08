// Lab #1
// Recursion.
//
// Write a recursive function that calculates the sum of digits in a given number.
//
// Description: Need to write a function that takes an integer as input and
// recursively calculates the sum of its digits.
//

#include <iostream>

using namespace std;

int getNumberSum(int number);

int main()
{
  int number;

  cout << "Input number: ";
  cin >> number;

  cout << "Result: " << getNumberSum(number) << endl;
}

int getNumberSum(int number)
{
  int n1 = number / 10;
  int n2 = number % 10;
  if (n1 == 0)
    return n2;
  return n2 + getNumberSum(n1);
}
