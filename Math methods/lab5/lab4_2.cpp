#include <iostream>
#include <vector>

using namespace std;

bool ExistsItemInList(vector<int> list, int value);

int main()
{
  vector<vector<int>> list;
  int vertex_count;
  int directed_graph;

  do
  {
    cout << "Graph is directed? (0/1): ";
    cin >> directed_graph;
  } while (directed_graph != 0 && directed_graph != 1);

  cout << "Input graph vertex count: ";
  cin >> vertex_count;

  for (int index = 0; index < vertex_count; index++)
    list.push_back({});

  for (int index = 0; index < vertex_count; index++)
  {
    int new_link;

    do
    {
      cout << "V" << index + 1 << " - ";

      for (int item_index = 0; item_index < list[index].size(); item_index++)
        cout << list[index][item_index] << " ";

      cin >> new_link;

      if (new_link != index + 1 && new_link >= 1 && new_link <= vertex_count)
        if (!ExistsItemInList(list[index], new_link))
        {
          list[index].push_back(new_link);

          if (!directed_graph)
            list[new_link - 1].push_back(index + 1);
        }
    } while (new_link != -1);

    cout << endl;
  }

  cout << "Adjacency list: " << endl;
  for (int index = 0; index < vertex_count; index++)
  {
    cout << "V" << index + 1 << " - ";
    for (int item_index = 0; item_index < list[index].size(); item_index++)
      cout << list[index][item_index] << " ";
    cout << endl;
  }
}

bool ExistsItemInList(vector<int> list, int value)
{
  for (int item_index; item_index < list.size(); item_index++)
    if (list[item_index] == value)
      return true;
  return false;
}