#include <iostream>
#include "Point.cpp"

using namespace std;

int main()
{
  Point point(10, 25);

  point.print();

  cout << "Distance to OX: " << point.get_length_to_ox() << endl;
  cout << "Distance to OY: " << point.get_length_to_oy() << endl;

  cout << "New: " << endl;

  point.set_x(124);
  point.set_y(-34);

  point.print();

  cout << "New distance to OX: " << point.get_length_to_ox() << endl;
  cout << "New distance to OY: " << point.get_length_to_oy() << endl;
}
