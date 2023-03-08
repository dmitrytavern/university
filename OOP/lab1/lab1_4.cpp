// Lab #1
// Functions.
//
// Task: create a function and pass some arguments.
//

#include <iostream>
#define _USE_MATH_DEFINES
#include <cmath>
#include <math.h>

using namespace std;

double calculate_option_1(double x);
double calculate_option_2(double x);
double calculate_option_3(double x);

int main()
{
  double x, h, y;

  cout << "Input h: ";
  cin >> h;

  for (x = -1 * M_PI / 2; x <= 2 * M_PI; x += h)
  {
    if (x < 0)
    {
      y = calculate_option_1(x);
      cout << "option 1: ";
    }
    else if (0 <= x && x <= 2.5)
    {
      y = calculate_option_2(x);
      cout << "option 2: ";
    }
    else
    {
      y = calculate_option_3(x);
      cout << "option 3: ";
    }

    cout << "x=" << x << ", y=" << y << endl;
  }
}

double calculate_option_1(double x)
{
  return x * log(cos(x));
}

double calculate_option_2(double x)
{
  return 1 + pow(x, 2);
}

double calculate_option_3(double x)
{
  return x - 2;
}
