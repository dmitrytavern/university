#include <iostream>

using namespace std;

const long MAX = 1000000;
unsigned int numbers[MAX];

int main()
{
  int n, k = 0;

  srand((unsigned)time(0));

  cout << "Input n: ";
  cin >> n;

  clock_t time1 = clock();

  for (long i = 0; i < n; i++)
    numbers[i] = rand();

  for (long i = 0; i < n; i++)
    for (long j = i + 1; j < n; j++)
      if (numbers[i] == numbers[j])
        k++;

  clock_t time2 = clock();

  int delta_time = (time2 - time1) * 1000 / CLOCKS_PER_SEC;

  cout << "Result: k=" << k << endl;
  cout << "Time(ms): " << delta_time << endl;
}