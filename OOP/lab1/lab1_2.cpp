// Lab #1
// Functions.
//
// Task: create a function and pass some arguments.
//

#include <iostream>
#include <cmath>

using namespace std;

double calculate_t(double b, double k);
double calculate_a(double b, double t);
double calculate_y(double a, double b);

int main()
{
  double b, k, t, a, y;

  cout << "Input b: ";
  cin >> b;

  cout << "Input k: ";
  cin >> k;

  t = calculate_t(b, k);
  a = calculate_a(b, t);
  y = calculate_y(a, b);

  cout << "Result: y=" << y << endl;
}

double calculate_t(double b, double k)
{
  return (pow(b, 2) + pow(k, 3));
}

double calculate_a(double b, double t)
{
  return sqrt(b + t);
}

double calculate_y(double a, double b)
{
  return pow(sin(a * a + b * b), 4);
}
