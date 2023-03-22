// Lab #2
// Functions.
//
// Task: Determine the function for calculating the NDS(n,m) of natural
// numbers, which is based on the ratio NDS(n,m) = NDS(m,r), where r is
// the remainder from the division of n by m. Use pointers.
//

#include <iostream>

using namespace std;

int nsd(int const *n, int const *m);

int main()
{
  const int n = 125;
  const int m = 25;

  int const *n_pointer = &n;
  int const *m_pointer = &m;

  cout << "Result: " << nsd(n_pointer, m_pointer) << endl;
}

int nsd(int const *n, int const *m)
{
  if (*n == 0)
  {
    return *m;
  }
  else
  {
    const int temp = (*n % *m);
    return nsd(&temp, m);
  }
}
