// Lab #8
// Graph Algorithms.
//
// Task: create a program that works with a weighted graph consisting of N
// vertices and M edges. The program should determine the number of vertices
// where the shortest paths from vertex A to B and from vertex C to D intersect.
// The graph is given in the form of an edge list and read from a file, where
// A and B are specified as the first pair of vertices between which the shortest
// path should be found, and C and D are specified as the second pair of vertices.
//

#include <iostream>
#include <fstream>
#include <stdio.h>
#include <functional>

using namespace std;

struct Matrix
{
  int **matrix;
  int matrix_row;
  int matrix_column;
};

void UIMainMenu(char *input);
void UIPressEnter();
void clear();

int findShortestDistance(Matrix matrix, bool *visited_output, int start, int end);
void printMatrix(int **matrix, int matrix_row, int matrix_size);
int **createMatrix(int row, int column);
Matrix createAdjacencyMatrix();

int A, B, C, D;

int main()
{
  Matrix adjacency = createAdjacencyMatrix();
  char main_menu_task;

  do
  {
    clear();
    UIMainMenu(&main_menu_task);
    clear();

    switch (main_menu_task)
    {
    case '1':
    {
      cout << "Adjacency matrix: " << endl;
      printMatrix(adjacency.matrix, adjacency.matrix_row, adjacency.matrix_column);
      UIPressEnter();
      break;
    }
    case '2':
    {
      int start, end, result_1, result_2, cross_count = 0;
      bool *visited_1 = new bool[adjacency.matrix_row];
      bool *visited_2 = new bool[adjacency.matrix_row];
      bool *cross = new bool[adjacency.matrix_row];

      cout << "Print cross vertexes:" << endl;
      cout << " A: " << A << " B: " << B << endl;
      cout << " C: " << C << " D: " << D << endl;

      result_1 = findShortestDistance(adjacency, visited_1, A - 1, B - 1);
      result_2 = findShortestDistance(adjacency, visited_2, C - 1, D - 1);

      for (int index = 0; index < adjacency.matrix_row; index++)
      {
        if (visited_1[index] == true && visited_2[index] == true)
        {
          cross[index] = true;
          cross_count++;
        }
      }

      cout << " Result: " << endl;
      cout << "   Minimum way length for A - B is " << result_1 << endl;
      cout << "   Minimum way length for C - B is " << result_2 << endl;
      cout << "   Cross vertexes:";

      if (cross_count > 0)
      {
        for (int cross_index = 0; cross_index < adjacency.matrix_row; cross_index++)
          if (cross[cross_index] == true)
            cout << " " << cross_index + 1;
      }
      else
      {
        cout << " not exists";
      }

      cout << endl;

      UIPressEnter();
      break;
    }
    }

    if (main_menu_task == 'e')
      break;
  } while (true);
}

void UIMainMenu(char *input)
{
  cout << "Printing:" << endl;
  cout << "1 - Print adjacency matrix" << endl;
  cout << "2 - Print cross vertexes" << endl;
  cout << "e - Exit" << endl;
  cout << "Your answer: ";
  cin >> *input;
}

int findShortestDistance(Matrix matrix, bool *visited_output, int start, int end)
{
  int distance[matrix.matrix_row];
  int parent[matrix.matrix_row];
  bool visited[matrix.matrix_row];

  for (int i = 0; i < matrix.matrix_row; i++)
  {
    parent[i] = -1;
    distance[i] = 10000;
    visited[i] = false;
  }

  distance[start] = 0;

  for (int i = 0; i < matrix.matrix_row - 1; i++)
  {
    int min = 10000;
    int min_index = 10000;

    for (int i = 0; i < matrix.matrix_row; i++)
    {
      if (!visited[i] && distance[i] <= min)
      {
        min = distance[i];
        min_index = i;
      }
    }

    visited[min_index] = true;

    for (int j = 0; j < matrix.matrix_row; j++)
    {
      int curr_distance = distance[min_index] + matrix.matrix[min_index][j];

      if (!visited[j] && matrix.matrix[min_index][j] && curr_distance < distance[j])
      {
        parent[j] = min_index;
        distance[j] = curr_distance;
      }
    }
  }

  int parent_index = end;
  while (parent[parent_index] != -1)
  {
    visited_output[parent_index] = true;
    parent_index = parent[parent_index];
  }

  return distance[end];
}

Matrix createAdjacencyMatrix()
{
  Matrix adjacency;
  int vertex_count;

  ifstream graph("graph2.txt");
  graph >> vertex_count;

  graph >> A >> B;
  graph >> C >> D;

  adjacency.matrix = createMatrix(vertex_count, vertex_count);
  adjacency.matrix_row = vertex_count;
  adjacency.matrix_column = vertex_count;

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

int **createMatrix(int row, int column)
{
  int **matrix = new int *[row];
  for (int row_index = 0; row_index < row; row_index++)
  {
    matrix[row_index] = new int[column];
    for (int column_index = 0; column_index < column; column_index++)
      matrix[row_index][column_index] = 0;
  }
  return matrix;
}

void printMatrix(int **matrix, int matrix_row, int matrix_column)
{
  for (int row = 0; row < matrix_row; row++)
  {
    for (int column = 0; column < matrix_column; column++)
      cout << "\t" << matrix[row][column];
    cout << endl;
  }
}

void UIPressEnter()
{
  cout << "Enter to continue..." << endl;
  cin.ignore(10, '\n');
  cin.get();
}

void clear()
{
#ifdef __linux__
  system("clear");
#else
  system("cls");
#endif
}
