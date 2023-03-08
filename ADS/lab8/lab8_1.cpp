// Lab #8
// Graph Algorithms.
//
// Task: given a graph with a certain number of vertices and a list of edges
// with their weights, implement the following operations:
// - Set a starting vertex and find the shortest path from it to all vertices
// of the graph using Dijkstra's algorithm.
// - Output a matrix of the shortest path lengths between all vertices of the graph.
// - Determine all vertices of the graph that are at a fixed distance d from a
// given vertex. The distance d and the vertex number are entered by the user
// from the keyboard. If there are no vertices at a distance d, notify the user
// and output all vertices that are at a distance less than d.
//

#include <iostream>
#include <fstream>
#include <stdio.h>
#include <functional>
#include <vector>

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

int AlgorithmDeikstry(Matrix matrix, int start, int end);
void printMatrix(int **matrix, int matrix_row, int matrix_size);
int **createMatrix(int row, int column);
Matrix createAdjacencyMatrix();
Matrix createIncidenceMatrix();

int main()
{
  Matrix adjacency = createAdjacencyMatrix();
  Matrix incidence = createIncidenceMatrix();
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
      cout << "----" << endl;
      cout << "Incidence matrix: " << endl;
      printMatrix(incidence.matrix, incidence.matrix_row, incidence.matrix_column);
      UIPressEnter();
      break;
    }
    case '2':
    {
      int start, end, result;

      cout << "Algorithm Deikstry:" << endl;

      cout << " Start vertex: ";
      cin >> start;

      cout << " End vertex: ";
      cin >> end;

      result = AlgorithmDeikstry(adjacency, start - 1, end - 1);

      cout << " Result: minimum way length is " << result << endl;
      UIPressEnter();
      break;
    }
    case '3':
    {
      cout << "Algorithm Deikstry for all vertexes:" << endl;

      int **ways_matrix = createMatrix(adjacency.matrix_row, adjacency.matrix_column);

      for (int row_index = 0; row_index < adjacency.matrix_row; row_index++)
      {
        for (int column_index = 0; column_index < adjacency.matrix_column; column_index++)
        {
          if (row_index != column_index)
          {
            ways_matrix[row_index][column_index] = AlgorithmDeikstry(adjacency, row_index, column_index);
          }
          else
          {
            ways_matrix[row_index][column_index] = 0;
          }
        }
      }

      printMatrix(ways_matrix, adjacency.matrix_row, adjacency.matrix_column);
      UIPressEnter();
      break;
    }
    case '4':
    {
      int start_vertex, distance;
      vector<int> vertexes = {};

      cout << "Vertexes by custom distance: " << endl;

      do
      {
        cout << "  Enter start vertex: ";
        cin >> start_vertex;
        start_vertex--;
      } while (start_vertex < 0 || start_vertex >= adjacency.matrix_row);

      cout << "  Enter distance: ";
      cin >> distance;

      int **ways_matrix = createMatrix(adjacency.matrix_row, adjacency.matrix_column);
      for (int row_index = 0; row_index < adjacency.matrix_row; row_index++)
      {
        for (int column_index = 0; column_index < adjacency.matrix_column; column_index++)
        {
          if (row_index != column_index)
          {
            ways_matrix[row_index][column_index] = AlgorithmDeikstry(adjacency, row_index, column_index);
          }
          else
          {
            ways_matrix[row_index][column_index] = 0;
          }
        }
      }

      for (int row_index = 0; row_index < adjacency.matrix_row; row_index++)
      {
        if (row_index != start_vertex && ways_matrix[row_index][start_vertex] == distance)
          vertexes.push_back(row_index);
      }

      cout << "Result: ";

      if (vertexes.size() == 0)
      {
        cout << "vertexes not exists.\nOther result: ";
        for (int row_index = 0; row_index < adjacency.matrix_row; row_index++)
        {
          if (row_index != start_vertex && ways_matrix[row_index][start_vertex] <= distance)
            vertexes.push_back(row_index);
        }
      }

      if (vertexes.size() != 0)
      {
        for (int vertex_index = 0; vertex_index < vertexes.size(); vertex_index++)
        {
          cout << vertexes[vertex_index] + 1 << " ";
        }
      }
      else
      {
        cout << "not exists";
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
  cout << "1 - Print adjacency and incidence matrixes" << endl;
  cout << "2 - Print minimum way by algorithm Deikstry" << endl;
  cout << "3 - Print minimum way matrix by algorithm Deikstry" << endl;
  cout << "4 - Print all vertexes by distance" << endl;
  cout << "e - Exit" << endl;
  cout << "Your answer: ";
  cin >> *input;
}

int AlgorithmDeikstry(Matrix matrix, int start, int end)
{
  int matrix_size = matrix.matrix_column;
  int *TopsWeight = new int[matrix_size];
  bool *visited = new bool[matrix_size];

  int minindex, min, temp;

  for (int i = 0; i < matrix_size; i++)
  {
    *(TopsWeight + i) = 10000;
    *(visited + i) = 1;
  }

  *(TopsWeight + start) = 0;

  do
  {
    minindex = 10000;
    min = 10000;

    for (int i = 0; i < matrix_size; i++)
    {
      if ((*(visited + i) == true) && (*(TopsWeight + i) < min))
      {
        min = *(TopsWeight + i);
        minindex = i;
      }
    }

    if (minindex != 10000)
    {
      for (int i = 0; i < matrix_size; i++)
      {
        if (*(*(matrix.matrix + minindex) + i) > 0)
        {
          temp = min + *(*(matrix.matrix + minindex) + i);
          if (temp < *(TopsWeight + i))
            *(TopsWeight + i) = temp;
        }
      }

      *(visited + minindex) = false;
    }
  } while (minindex < 10000);

  return *(TopsWeight + end);
}

Matrix createAdjacencyMatrix()
{
  Matrix adjacency;
  int vertex_count;

  ifstream graph("graph.txt");
  graph >> vertex_count;

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

Matrix createIncidenceMatrix()
{
  Matrix incidence;
  int vertex_count, ribs_count = 0;

  ifstream graph_ribs("graph.txt");
  graph_ribs >> vertex_count;

  while (!graph_ribs.eof())
  {
    int v1, v2, weight;
    graph_ribs >> v1 >> v2 >> weight;
    ribs_count++;
  }

  graph_ribs.close();

  ifstream graph("graph.txt");
  graph >> vertex_count;

  incidence.matrix = createMatrix(vertex_count, ribs_count);
  incidence.matrix_row = vertex_count;
  incidence.matrix_column = ribs_count;

  int currect_rib = 0;
  while (!graph.eof())
  {
    int v1, v2, weight;
    graph >> v1 >> v2 >> weight;
    incidence.matrix[v1 - 1][currect_rib] = weight;
    incidence.matrix[v2 - 1][currect_rib] = weight;
    currect_rib++;
  }

  graph.close();

  return incidence;
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
