// Lab #2
// Pointer.
//
// Task: Given an array of n real numbers, remove from the array all elements
// that are less than the arithmetic mean of all elements of the original array.
//
// Description: Write a program that takes an array of n real numbers as input
// and removes all elements from the array that are less than the arithmetic mean
// of all elements of the original array. Finally, the program should output the
// modified array.
//

#include <iostream>

using namespace std;

void output_numbers(double *numbers, int length);

int main()
{
  int numbers_length;

  cout << "Input array length: ";
  cin >> numbers_length;

  double *numbers = new double[numbers_length];
  double numbers_sum = 0;
  double numbers_average = 0;

  for (int index = 0; index < numbers_length; index++)
  {
    cout << "a[" << index << "]=";
    cin >> *(numbers + index);
    numbers_sum += *(numbers + index);
  }

  numbers_average = numbers_sum / numbers_length;

  output_numbers(numbers, numbers_length);
  cout << "Numbers sum: " << numbers_sum << endl;
  cout << "Numbers length: " << numbers_length << endl;
  cout << "Numbers avarage: " << numbers_average << endl;

  for (int index = 0; index < numbers_length; index++)
  {
    if (*(numbers + index) <= numbers_average)
    {
      for (int j = index; j < (numbers_length - 1); j++)
        *(numbers + j) = *(numbers + j + 1);
      index--;
      numbers_length--;
    }
  }

  output_numbers(numbers, numbers_length);
}

void output_numbers(double *numbers, int length)
{
  cout << "numbers[]=[ ";
  for (int index = 0; index < length; index++)
    cout << *(numbers + index) << " ";
  cout << "]" << endl;
}
