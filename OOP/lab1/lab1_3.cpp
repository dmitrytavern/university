// Lab #1
// Functions.
//
// Task: create a function and pass some arguments.
//

#include <iostream>
#include <cmath>

using namespace std;

double calculate_z(double coefficient, double x, double a);
double calculate_option_1(double x, double a, double b, double z);
double calculate_option_2(double x, double a, double b, double z);
double calculate_option_3(double x, double a, double b, double z);

int main()
{
  double x, a, b, z, y, z_coefficient;

  cout << "Input x: ";
  cin >> x;

  cout << "Input a: ";
  cin >> a;

  cout << "Input b: ";
  cin >> b;

  cout << "Input z coefficient: ";
  cin >> z_coefficient;

  z = calculate_z(z_coefficient, x, a);

  if (x <= 5 * a)
  {
    y = calculate_option_1(x, a, b, z);
  }
  else if (x > b)
  {
    y = calculate_option_2(x, a, b, z);
  }
  else if (5 * a < x && x <= b)
  {
    y = calculate_option_3(x, a, b, z);
  }

  cout << "Result: y=" << y << endl;
}

double calculate_z(double coefficient, double x, double a)
{
  return exp(coefficient * a * x);
}

double calculate_option_1(double x, double a, double b, double z)
{
  return (2.5 * pow(b, 2)) + (a * x) - (4.5 * cos(x * z));
}

double calculate_option_2(double x, double a, double b, double z)
{
  return pow((a * a - 5.4 * x), 3) + log(x * z);
}

double calculate_option_3(double x, double a, double b, double z)
{
  return sqrt(6.5 * b * b + (a - pow(x, 3) * z));
}
