// Lab #1
// Functions.
//
// Task: create a function and pass some argument.
//

#include <iostream>
#define _USE_MATH_DEFINES
#include <cmath>
#include <math.h>

using namespace std;

double calculate(int k, double x);
int factorial(int k);

int main()
{
  double sum = 0, h = 0.1, calc;
  int k = 1;

  cout << "h=" << h << endl;

  for (double x = 1; x < 2.1; x += h)
  {
    calc = calculate(k, x);
    cout << "calculate(" << k << ", " << x << ")=" << calc << endl;
    sum += calc;
    k++;
  }

  cout << "Result: f(x)=" << sum << endl;
}

double calculate(int k, double x)
{
  return (pow(x, 2 * k)) / factorial(2 * k);
}

int factorial(int k)
{
  int result = 1;
  for (int i = 1; i <= k; i++)
    result = result * i;
  return result;
}
