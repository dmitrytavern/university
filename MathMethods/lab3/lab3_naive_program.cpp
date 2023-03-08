#include <iostream>
#include <fstream>
#include <string>

using namespace std;

const long MAX = 100000;
unsigned int numbers[MAX];

void write_result(string filename, int count, int time);

int main()
{
  int count, result = 0;

  cout << "Input numbers count: ";
  cin >> count;

  clock_t time1 = clock();

  for (long i = 0; i < count; i++)
    for (long j = i + 1; j < count; j++)
      if (numbers[i] == numbers[j])
        result++;

  clock_t time2 = clock();

  int result_time = (time2 - time1) * 1000 / CLOCKS_PER_SEC;

  write_result("numbers_naive_result.txt", count, result_time);
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
