#include <iostream>

using namespace std;

const long MAX = 1000000;
const long MAX_VAL = 1000000;
unsigned int numbers[MAX];
unsigned int indexes[MAX_VAL + 1];

int main()
{
  int n, k = 0;

  srand((unsigned)time(0));

  cout << "Input n: ";
  cin >> n;

  clock_t time1 = clock();

  for (long i = 0; i < MAX_VAL; i++)
  {
    numbers[i] = rand() % (MAX_VAL - 0 + 1) + 0;
    indexes[numbers[i]]++;
  }

  for (long i = 0; i < n; i++)
    k += indexes[i] * (indexes[i] - 1) / 2;

  clock_t time2 = clock();

  int delta_time = (time2 - time1) * 1000 / CLOCKS_PER_SEC;

  cout << "Result: k=" << k << endl;
  cout << "Time(ms): " << delta_time << endl;
}
