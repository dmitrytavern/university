// Lab #3
// Dynamic memory allocation.
//
// Task: Create a dynamic two-dimensional array and add K columns to the end of
// the matrix.
//
// Description: Write a program that dynamically creates a two-dimensional
// array of a specified size and fills it with random numbers in the range (0,20).
// The program should then output the array to the screen. After that, the
// program should prompt the user to enter the number of columns (K) they want
// to add to the end of the array. The program should then create a new array with
// K additional columns and copy the contents of the original array into the new
// array. Finally, the program should fill the new columns with random numbers in the
// same range as before and output the modified array to the screen.
//

#include <iostream>

using namespace std;

int int_random();
void create_matrix(int **matrix, int row, int column);
void output_matrix(int **matrix, int row, int column);
void add_columns_to_matrix(int **matrix, int row, int column, int column_count);

int main()
{
  srand(time(0));

  int **matrix, matrix_row_length, matrix_column_length, k;

  cout << "Input matrix row length: ";
  cin >> matrix_row_length;

  cout << "Input matrix column length: ";
  cin >> matrix_column_length;

  matrix = new int *[matrix_row_length];

  create_matrix(matrix, matrix_row_length, matrix_column_length);

  output_matrix(matrix, matrix_row_length, matrix_column_length);

  cout << "Input count of new columns: ";
  cin >> k;

  add_columns_to_matrix(matrix, matrix_row_length, matrix_column_length, k);

  matrix_column_length += k;

  output_matrix(matrix, matrix_row_length, matrix_column_length);

  delete[] matrix;
}

void create_matrix(int **matrix, int row, int column)
{
  for (int matrix_row = 0; matrix_row < row; matrix_row++)
    matrix[matrix_row] = new int[column];

  for (int matrix_row = 0; matrix_row < row; matrix_row++)
    for (int matrix_column = 0; matrix_column < column; matrix_column++)
      matrix[matrix_row][matrix_column] = int_random();
}

void output_matrix(int **matrix, int row, int column)
{
  cout << "Matrix: " << endl;
  for (int matrix_row = 0; matrix_row < row; matrix_row++)
  {
    for (int matrix_column = 0; matrix_column < column; matrix_column++)
      cout << "\t" << matrix[matrix_row][matrix_column];
    cout << endl;
  }
}

void add_columns_to_matrix(int **matrix, int row, int column, int column_count)
{
  int *temp = new int[column];

  for (int matrix_row = 0; matrix_row < row; matrix_row++)
  {
    temp = matrix[matrix_row];

    matrix[matrix_row] = new int[column + column_count];

    for (int matrix_column = 0; matrix_column < column; matrix_column++)
      matrix[matrix_row][matrix_column] = temp[matrix_column];

    for (int matrix_column = column; matrix_column < column + column_count; matrix_column++)
      matrix[matrix_row][matrix_column] = int_random();
  }

  delete[] temp;
}

int int_random()
{
  return rand() % (20 - 0 + 1) + 0;
}
