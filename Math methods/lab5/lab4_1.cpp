#include <iostream>
#include <vector>

using namespace std;

int main()
{
  int matrix_size;
  int directed_graph;

  do
  {
    cout << "Graph is directed? (0/1): ";
    cin >> directed_graph;
  } while (directed_graph != 0 && directed_graph != 1);

  cout << "Input graph vertex count: ";
  cin >> matrix_size;

  int **matrix = new int *[matrix_size];
  for (int row = 0; row < matrix_size; row++)
  {
    matrix[row] = new int[matrix_size];
    for (int column = 0; column < matrix_size; column++)
      matrix[row][column] = -1;
  }

  cout << "Input adjacency matrix: " << endl;
  for (int row = 0; row < matrix_size; row++)
  {
    for (int column = 0; column < matrix_size; column++)
    {
      do
      {
        if (matrix[row][column] != -1)
          continue;

        cout << "  V" << row + 1 << " -> V" << column + 1 << " = ";
        cin >> matrix[row][column];

        if (!directed_graph)
          matrix[column][row] = matrix[row][column];
      } while (matrix[row][column] != 0 && matrix[row][column] != 1);
    }
  }

  cout << "Adjacency matrix: " << endl;
  for (int row = 0; row < matrix_size; row++)
  {
    for (int column = 0; column < matrix_size; column++)
      cout << "\t" << matrix[row][column];
    cout << endl;
  }

  for (int row = 0; row < matrix_size; row++)
    delete[] matrix[row];
  delete[] matrix;
}
