#include <iostream>
#include <fstream>
#include <stdio.h>

using namespace std;

struct Matrix
{
  int **matrix;
  int matrix_size;
};

Matrix CreateAdjacencyMatrix();
void PrintMatrix(Matrix matrix);
void PrintShortestDistance(Matrix matrix, int start, int end);

int main()
{
  int from_vertex, to_vertex;
  Matrix adjacency = CreateAdjacencyMatrix();

  cout << "Adjacency matrix of graph: " << endl;

  PrintMatrix(adjacency);

  cout << "Calculating distance: " << endl;

  do
  {
    cout << "  From vertex: ";
    cin >> from_vertex;
    from_vertex--;
  } while (from_vertex < 0 || from_vertex >= adjacency.matrix_size);

  do
  {
    cout << "  To vertex: ";
    cin >> to_vertex;
    to_vertex--;
  } while (to_vertex < 0 || to_vertex >= adjacency.matrix_size);

  cout << "Result:" << endl;

  PrintShortestDistance(adjacency, from_vertex, to_vertex);
}

void PrintShortestDistance(Matrix matrix, int start, int end)
{
  int distance[matrix.matrix_size];
  int parent[matrix.matrix_size];
  bool visited[matrix.matrix_size];

  for (int i = 0; i < matrix.matrix_size; i++)
  {
    parent[0] = -1;
    distance[i] = 10000;
    visited[i] = false;
  }

  distance[start] = 0;

  for (int i = 0; i < matrix.matrix_size - 1; i++)
  {
    int min = 10000;
    int min_index = 10000;

    for (int i = 0; i < matrix.matrix_size; i++)
    {
      if (!visited[i] && distance[i] <= min)
      {
        min = distance[i];
        min_index = i;
      }
    }

    visited[min_index] = true;

    for (int j = 0; j < matrix.matrix_size; j++)
    {
      int curr_distance = distance[min_index] + matrix.matrix[min_index][j];

      if (!visited[j] && matrix.matrix[min_index][j] && curr_distance < distance[j])
      {
        parent[j] = min_index;
        distance[j] = curr_distance;
      }
    }
  }

  cout << "  Optimized path from " << start + 1 << " to " << end + 1 << ":";

  for (int i = 0; i < matrix.matrix_size; i++)
    visited[i] = false;

  int parent_index = end;
  while (parent[parent_index] != 0)
  {
    if (visited[parent_index] || parent[parent_index] == -1)
      break;

    cout << " " << parent_index + 1;
    visited[parent_index] = true;
    parent_index = parent[parent_index];
  }

  cout << endl;

  cout << "  Distance: " << distance[end] << endl;
}

Matrix CreateAdjacencyMatrix()
{
  Matrix adjacency;
  int vertex_count;

  ifstream graph("graph2.txt");
  graph >> vertex_count;

  adjacency.matrix = new int *[vertex_count];
  for (int row_index = 0; row_index < vertex_count; row_index++)
  {
    adjacency.matrix[row_index] = new int[vertex_count];
    for (int column_index = 0; column_index < vertex_count; column_index++)
      adjacency.matrix[row_index][column_index] = 0;
  }

  adjacency.matrix_size = vertex_count;

  while (!graph.eof())
  {
    int v1, v2, weight;
    graph >> v1 >> v2 >> weight;
    adjacency.matrix[v1 - 1][v2 - 1] = weight;
    adjacency.matrix[v2 - 1][v1 - 1] = weight;
  }

  graph.close();

  return adjacency;
}

void PrintMatrix(Matrix matrix)
{
  for (int row = 0; row < matrix.matrix_size; row++)
  {
    for (int column = 0; column < matrix.matrix_size; column++)
      cout << "\t" << matrix.matrix[row][column];
    cout << endl;
  }
}
