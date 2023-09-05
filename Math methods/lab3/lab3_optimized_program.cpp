#include <iostream>
#include <fstream>
#include <string>

using namespace std;

const long MAX = 1000000;
const long MAX_VAL = 100000;
unsigned int numbers[MAX];
unsigned int indexes[MAX_VAL + 1];

void find_numbers(int count);
void write_result(string filename, int count, int time);

int main()
{
  int count, result = 0;

  cout << "Input numbers count: ";
  cin >> count;

  clock_t time1 = clock();

  for (int i = 0; i < count; i++)
  {
    numbers[i] = rand() % (MAX_VAL - 0 + 1) + 0;
    indexes[numbers[i]]++;
  }

  for (int i = 0; i < MAX_VAL; i++)
    result += indexes[i] * (indexes[i] - 1) / 2;

  clock_t time2 = clock();

  int result_time = (time2 - time1) * 1000 / CLOCKS_PER_SEC;

  write_result("numbers_optimized_result.txt", count, result_time);
}

void write_result(string filename, int count, int time)
{
  ofstream numberso(filename, ios::app);

  if (!numberso)
  {
    cout << "Cannot open the file to output" << endl;
    exit(1);
  }

  numberso << count << "\t" << time << endl;

  numberso.close();

  cout << "Number in the amount of " << count << " finded. Time(ms): " << time << endl;
}
