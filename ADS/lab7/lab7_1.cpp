// Lab #7
// Graphs.
//
// Create a program that implements the following operations for a graph:
// - Adding a vertex with a given number entered from the keyboard.
// - Adding an edge between specified vertices.
// - Removing a vertex with a given number from the graph.
// - Removing an edge between vertices specified by their numbers, for example, 1 2.
// - Determining the number of vertices that have only one outgoing edge.
// - Printing the adjacency and incidence matrices.
// - Printing the sequence of vertices obtained using breadth-first and depth-first
// traversal algorithms. The starting vertex is specified by the user from the keyboard.
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

int getVertexName(int index);
int getVertexIndex(int name);
void printMatrix(int **matrix, int matrix_row, int matrix_size);
void printGraphInWidth(int **matrix, int matrix_size);
void printGraphInDepth(int **matrix, int matrix_size);
void removeMatrixRow(Matrix *marrix, int row);
void removeMatrixColumn(Matrix *marrix, int column);
int **createMatrix(int row, int column);
Matrix createAdjacencyMatrix();
Matrix createIncidenceMatrix();

int *graph_vertexes;
int graph_vertexes_size;

int main()
{
  Matrix adjacency = createAdjacencyMatrix();
  Matrix incidence = createIncidenceMatrix();
  char main_menu_task;

  graph_vertexes = new int[adjacency.matrix_row];
  graph_vertexes_size = adjacency.matrix_row;
  for (int index = 0; index < graph_vertexes_size; index++)
    graph_vertexes[index] = index + 1;

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
      cout << "Graph bypass in width: " << adjacency.matrix_row << endl;
      printGraphInWidth(adjacency.matrix, adjacency.matrix_row);
      UIPressEnter();
      break;
    }
    case '3':
    {
      cout << "Graph bypass in deep: " << endl;
      printGraphInDepth(adjacency.matrix, adjacency.matrix_row);
      UIPressEnter();
      break;
    }
    case '4':
    {
      int count = 0;

      for (int row_index = 0; row_index < incidence.matrix_row; row_index++)
      {
        int true_count = 0;
        for (int column_index = 0; column_index < incidence.matrix_column; column_index++)
          if (incidence.matrix[row_index][column_index] == 1)
            true_count++;
        if (true_count == 1)
          count++;
      }

      cout << "Count of vertex with one rib: " << count << endl;

      UIPressEnter();
      break;
    }
    case '5':
    {
      int vertex_name;

      cout << "Adding vertex:" << endl;

      do
      {
        cout << "  Enter vertex: ";
        cin >> vertex_name;
      } while (getVertexIndex(vertex_name) != -1);

      // Update adjacency matrix
      int **new_adjacency_matrix = createMatrix(adjacency.matrix_row + 1, adjacency.matrix_column + 1);

      for (int row_index = 0; row_index < adjacency.matrix_row; row_index++)
        for (int column_index = 0; column_index < adjacency.matrix_column; column_index++)
          new_adjacency_matrix[row_index][column_index] = adjacency.matrix[row_index][column_index];

      adjacency.matrix = new_adjacency_matrix;
      adjacency.matrix_row++;
      adjacency.matrix_column++;

      // Update incidence matrix
      int **new_incidence_matrix = createMatrix(incidence.matrix_row + 1, incidence.matrix_column);

      for (int row_index = 0; row_index < incidence.matrix_row; row_index++)
        for (int column_index = 0; column_index < incidence.matrix_column; column_index++)
          new_incidence_matrix[row_index][column_index] = incidence.matrix[row_index][column_index];

      incidence.matrix = new_incidence_matrix;
      incidence.matrix_row++;

      // Update graph vertex names
      int *new_graph_vertexes = new int[adjacency.matrix_row];
      for (int index = 0; index < adjacency.matrix_row - 1; index++)
        new_graph_vertexes[index] = graph_vertexes[index];
      new_graph_vertexes[adjacency.matrix_row - 1] = vertex_name;

      graph_vertexes = new_graph_vertexes;
      graph_vertexes_size = adjacency.matrix_row;

      cout << "New vertex " << getVertexName(adjacency.matrix_row - 1) << " success added" << endl;

      UIPressEnter();
      break;
    }
    case '6':
    {
      int v1, v1_name;
      int v2, v2_name;

      cout << "Adding rib: " << endl;

      do
      {
        cout << "  From vertex: ";
        cin >> v1_name;
        v1 = getVertexIndex(v1_name);
      } while (v1 == -1);

      do
      {
        cout << "  To vertex: ";
        cin >> v2_name;
        v2 = getVertexIndex(v2_name);
      } while (v2 == -1);

      if (adjacency.matrix[v1][v2] == 0 && adjacency.matrix[v2][v1] == 0)
      {
        // Update incidence matrix
        int **new_incidence_matrix = createMatrix(incidence.matrix_row, incidence.matrix_column + 1);

        for (int row_index = 0; row_index < incidence.matrix_row; row_index++)
          for (int column_index = 0; column_index < incidence.matrix_column; column_index++)
            new_incidence_matrix[row_index][column_index] = incidence.matrix[row_index][column_index];

        incidence.matrix = new_incidence_matrix;
        incidence.matrix[v1][incidence.matrix_column] = 1;
        incidence.matrix[v2][incidence.matrix_column] = 1;
        incidence.matrix_column++;

        // Update adjacency matrix
        adjacency.matrix[v1][v2] = 1;
        adjacency.matrix[v2][v1] = 1;

        cout << "New rib " << v1_name << "-" << v2_name << " success added" << endl;
      }
      else
      {
        cout << "The rib " << v2_name << "-" << v2_name << " already exists" << endl;
      }

      UIPressEnter();
      break;
    }
    case '7':
    {
      int vertex, vertex_name;

      cout << "Removing vertex:" << endl;

      do
      {
        cout << "  Enter vertex: ";
        cin >> vertex_name;
        vertex = getVertexIndex(vertex_name);
      } while (vertex == -1);

      // Update adjacency matrix
      removeMatrixRow(&adjacency, vertex);
      removeMatrixColumn(&adjacency, vertex);

      // Update incidence matrix
      for (int column_index = 0; column_index < incidence.matrix_column; column_index++)
      {
        if (incidence.matrix[vertex][column_index] == 1)
        {
          removeMatrixColumn(&incidence, column_index);
          column_index--;
        }
      }

      removeMatrixRow(&incidence, vertex);

      // Update graph vertex names
      int *new_graph_vertexes = new int[adjacency.matrix_row];
      int vertex_index = 0, new_vertex_index = 0;
      for (; vertex_index < adjacency.matrix_row;)
      {
        if (vertex == vertex_index)
        {
          vertex_index++;
          continue;
        }

        new_graph_vertexes[new_vertex_index] = graph_vertexes[vertex_index];

        vertex_index++;
        new_vertex_index++;
      }

      graph_vertexes = new_graph_vertexes;
      graph_vertexes_size = adjacency.matrix_row;

      cout << "Vertex " << vertex_name << " success removed" << endl;

      UIPressEnter();
      break;
    }
    case '8':
    {
      int v1, v1_name;
      int v2, v2_name;

      cout << "Removing rib: " << endl;

      do
      {
        cout << "  From vertex: ";
        cin >> v1_name;
        v1 = getVertexIndex(v1_name);
      } while (v1 == -1);

      do
      {
        cout << "  To vertex: ";
        cin >> v2_name;
        v2 = getVertexIndex(v2_name);
      } while (v2 == -1);

      if (adjacency.matrix[v1][v2] == 1 && adjacency.matrix[v2][v1] == 1)
      {
        // Update incidence matrix
        int column = -1;
        for (int column_index = 0; column_index < incidence.matrix_column; column_index++)
        {
          if (incidence.matrix[v1][column_index] == 1 && incidence.matrix[v2][column_index] == 1)
          {
            column = column_index;
            break;
          }
        }

        removeMatrixColumn(&incidence, column);

        // Update adjacency matrix
        adjacency.matrix[v1][v2] = 0;
        adjacency.matrix[v2][v1] = 0;

        cout << "Rib " << v1_name << "-" << v2_name << " success removed" << endl;
      }
      else
      {
        cout << "The rib " << v1_name << "-" << v2_name << " not exists" << endl;
      }

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
  cout << " 1 - Print adjacency and incidence matrixes" << endl;
  cout << " 2 - Print graph bypass in width" << endl;
  cout << " 3 - Print graph bypass in deep" << endl;
  cout << " 4 - Print count of vertex with one rib" << endl;
  cout << "Actions:" << endl;
  cout << " 5 - Add vertex" << endl;
  cout << " 6 - Add rib" << endl;
  cout << " 7 - Remove vertex" << endl;
  cout << " 8 - Remove rib" << endl;
  cout << "Other:" << endl;
  cout << " e - Exit" << endl;
  cout << "Your answer: ";
  cin >> *input;
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
    int v1, v2;
    graph >> v1 >> v2;
    adjacency.matrix[v1 - 1][v2 - 1] = 1;
    adjacency.matrix[v2 - 1][v1 - 1] = 1;
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
    int v1, v2;
    graph_ribs >> v1 >> v2;
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
    int v1, v2;
    graph >> v1 >> v2;
    incidence.matrix[v1 - 1][currect_rib] = 1;
    incidence.matrix[v2 - 1][currect_rib] = 1;
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

void removeMatrixRow(Matrix *matrix, int row)
{
  int **new_matrix = createMatrix(matrix->matrix_row - 1, matrix->matrix_column);

  for (int column_index = 0; column_index < matrix->matrix_column; column_index++)
  {
    int row_index = 0, new_row_index = 0;
    for (; row_index < matrix->matrix_row;)
    {
      if (row_index == row)
      {
        row_index++;
        continue;
      }

      new_matrix[new_row_index][column_index] = matrix->matrix[row_index][column_index];
      row_index++;
      new_row_index++;
    }
  }

  matrix->matrix = new_matrix;
  matrix->matrix_row--;
}

void removeMatrixColumn(Matrix *matrix, int column)
{
  int **new_matrix = createMatrix(matrix->matrix_row, matrix->matrix_column - 1);
  int column_index = 0, new_column_index = 0;

  for (; column_index < matrix->matrix_column;)
  {
    if (column_index == column)
    {
      column_index++;
      continue;
    }

    for (int row_index = 0; row_index < matrix->matrix_row; row_index++)
      new_matrix[row_index][new_column_index] = matrix->matrix[row_index][column_index];

    column_index++;
    new_column_index++;
  }

  matrix->matrix = new_matrix;
  matrix->matrix_column--;
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

void printGraphInWidth(int **matrix, int matrix_size)
{
  int *FIFO = new int[matrix_size];
  int *label = new int[matrix_size];
  int start_vertex, start_vertex_name, p = 0, k = 1;

  do
  {
    cout << "  Enter start vertex: ";
    cin >> start_vertex_name;
    start_vertex = getVertexIndex(start_vertex_name);
  } while (start_vertex == -1);

  for (int i = 0; i < matrix_size; i++)
  {
    FIFO[i] = 0;
    label[i] = 32767;
  }

  FIFO[p] = start_vertex;
  label[start_vertex] = 0;

  while (p != k)
  {
    int cur = FIFO[p];
    p++;
    for (int index = 0; index < matrix_size; index++)
    {
      if (matrix[cur][index] == 1 && label[index] > label[cur] + 1)
      {
        FIFO[k] = index;
        label[index] = label[cur] + 1;
        k++;
      }
    }
  }

  cout << "  ";
  for (int fifo_index = 0; fifo_index < matrix_size; fifo_index++)
    cout << getVertexName(FIFO[fifo_index]) << " ";
  cout << endl;
}

void printGraphInDepth(int **matrix, int matrix_size)
{
  bool *visited = new bool[matrix_size];
  int start_vertex, start_vertex_name;

  do
  {
    cout << "  Enter start vertex: ";
    cin >> start_vertex_name;
    start_vertex = getVertexIndex(start_vertex_name);
  } while (start_vertex == -1);

  function<void(int **, int, bool *, int)> printGraph = [&](int **matrix, int matrix_size, bool *visited, int start) -> void
  {
    *(visited + start) = true;
    cout << getVertexName(start) << " ";
    for (int i = 0; i < matrix_size; i++)
      if (*(*(matrix + start) + i) && !*(visited + i))
        printGraph(matrix, matrix_size, visited, i);
  };

  cout << "  ";
  printGraph(matrix, matrix_size, visited, start_vertex);
  cout << endl;
}

int getVertexName(int index)
{
  return graph_vertexes[index];
}

int getVertexIndex(int name)
{
  for (int index = 0; index < graph_vertexes_size; index++)
    if (graph_vertexes[index] == name)
      return index;
  return -1;
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
