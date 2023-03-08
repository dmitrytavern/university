// Lab #2
// Pointer.
//
// Task: Fill with zeros the elements of a square matrix located along its
// perimeter.
//
// Description: Write a program that takes a square matrix as input and
// fills with zeros all elements located along its perimeter. The program
// should output the modified matrix.
//

#include <iostream>

using namespace std;

const int MAX_MATRIX_SIZE = 10;

void setZeroOnBorders(int (*numbers_pointer)[MAX_MATRIX_SIZE], int numbers_size);

int main()
{
  int numbers[MAX_MATRIX_SIZE][MAX_MATRIX_SIZE];
  int(*numbers_pointer)[MAX_MATRIX_SIZE] = numbers;
  int numbers_size;

  cout << "Input size of matrix: ";
  cin >> numbers_size;

  for (int i = 0; i < numbers_size; i++)
  {
    for (int j = 0; j < numbers_size; j++)
    {
      cout << "numbers[" << i << "][" << j << "]=";
      cin >> *(*(numbers_pointer + i) + j);
    }
  }

  setZeroOnBorders(numbers_pointer, numbers_size);

  cout << "Numbers:" << endl;
  for (int i = 0; i < numbers_size; i++)
  {
    for (int j = 0; j < numbers_size; j++)
      cout << "\t" << *(*(numbers_pointer + i) + j);
    cout << endl;
  }
}

void setZeroOnBorders(int (*numbers_pointer)[MAX_MATRIX_SIZE], int numbers_size)
{
  int i, j;
  for (i = 0; i < numbers_size; i++)
  {
    for (j = 0; j < numbers_size; j++)
    {
      if (i == 0 || i == numbers_size - 1)
        *(*(numbers_pointer + i) + j) = 0;
      else if (j == 0 || j == numbers_size - 1)
        *(*(numbers_pointer + i) + j) = 0;
    }
  }
}
