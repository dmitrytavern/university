#include <iostream>
#include <vector>

using namespace std;

void printShortestDistance(int **matrix, int matrix_size, int start, int end);

int main()
{
  int matrix_size, from_vertex, to_vertex;

  cout << "Input directed graph vertex count: ";
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
        cout << "  V" << row + 1 << " -> V" << column + 1 << " = ";
        cin >> matrix[row][column];
      } while (matrix[row][column] < 0);
    }
  }

  cout << "Input route:" << endl;

  do
  {
    cout << "  From: ";
    cin >> from_vertex;
    from_vertex--;
  } while (from_vertex < 0 || from_vertex >= matrix_size);

  do
  {
    cout << "  To: ";
    cin >> to_vertex;
    to_vertex--;
  } while (to_vertex < 0 || to_vertex >= matrix_size);

  cout << "Adjacency matrix: " << endl;
  for (int row = 0; row < matrix_size; row++)
  {
    for (int column = 0; column < matrix_size; column++)
      cout << "\t" << matrix[row][column];
    cout << endl;
  }

  cout << "Result:" << endl;

  printShortestDistance(matrix, matrix_size, from_vertex, to_vertex);

  for (int row = 0; row < matrix_size; row++)
    delete[] matrix[row];
  delete[] matrix;
}

void printShortestDistance(int **matrix, int matrix_size, int start, int end)
{
  int distance[matrix_size];
  int parent[matrix_size];
  bool visited[matrix_size];

  for (int i = 0; i < matrix_size; i++)
  {
    parent[0] = -1;
    distance[i] = 10000;
    visited[i] = false;
  }

  distance[start] = 0;

  for (int i = 0; i < matrix_size - 1; i++)
  {
    int min = 10000;
    int min_index = 10000;

    for (int i = 0; i < matrix_size; i++)
    {
      if (!visited[i] && distance[i] <= min)
      {
        min = distance[i];
        min_index = i;
      }
    }

    visited[min_index] = true;

    for (int j = 0; j < matrix_size; j++)
    {
      int curr_distance = distance[min_index] + matrix[min_index][j];

      if (!visited[j] && matrix[min_index][j] && curr_distance < distance[j])
      {
        parent[j] = min_index;
        distance[j] = curr_distance;
      }
    }
  }

  cout << "  Optimized path from " << start + 1 << " to " << end + 1 << ": " << start + 1;
  int parent_index = end;
  while (parent[parent_index] != 0)
  {
    if (parent[parent_index] == -1)
      break;
    parent_index = parent[parent_index];
    cout << " " << parent_index + 1;
  }
  cout << " " << end + 1 << endl;
  cout << "  Distance: " << distance[end] << endl;
}
