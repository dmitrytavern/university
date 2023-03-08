#include <iostream>
#include <cmath>

using namespace std;

int factorial(int n);

int main()
{
  float z, a;

  cout << "Input z: ";
  cin >> z;

  a = z - (pow(z, 2) / factorial(3)) + (pow(z, 5) / factorial(5));

  cout << "Result: " << a << endl;
}

int factorial(int n)
{
  if (n > 1)
    return n * factorial(n - 1);
  else
    return 1;
}
