// Lab #2
// Pointer.
//
// Task: Given two real numbers X and Y. Compute the following formula.
// (formula provided in the instructions) in the function.
//
// Description: You need to create a program that provides a solution
// to the equation. Variable values are entered from the keyboard in
// the main function and passed as arguments to the function that provides
// the calculation. Organize work with the function using an pointer.
//

#include <iostream>
#include <cmath>

using namespace std;

double calculate(double x, double y);

int main()
{
  double x, y;
  double (*calc_fn)(double, double) = calculate;

  cout << "Input x: ";
  cin >> x;

  cout << "Input y: ";
  cin >> y;

  cout << "Result: a=" << calculate(x, y) << endl;
  cout << "Result (with pointer): a=" << calc_fn(x, y) << endl;
}

double calculate(double x, double y)
{
  return ((1 + pow(sin(x + y), 2)) / (2 + abs(x - ((2 * x) / (1 + abs(sin(x + y)))))));
}
