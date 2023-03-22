// Lab #1
// Functions.
//
// Task: create a function and pass some arguments.
//

#include <iostream>
#include <cmath>

using namespace std;

double calculate(double x);

int main()
{
  double x;
  cout << "Input x: ";
  cin >> x;
  cout << "Result: R=" << calculate(x) << endl;
}

double calculate(double x)
{
  return ((pow(sin(x * x + 4), 3) + 4.3) / (pow(sin(pow(x, 4)), 3)));
}
