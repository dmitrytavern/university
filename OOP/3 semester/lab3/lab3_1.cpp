// Lab #3
// Struct.
//
// Task: This task involves the following steps:
//
// - Create a Point structure template with attributes x and y representing coordinates.
// - Create a Triangle structure template with three Point attributes representing its vertices.
// - Prompt the user to fill in the Triangle structure instance by providing all coordinates.
// - The program should determine and output the type of the triangle as one of the following:
//    - Equilateral (if all sides are equal in length)
//    - Isosceles (if two sides are equal in length)
//    - Scalene (if all sides are of different lengths)
//

#include <iostream>
#include <cmath>

using namespace std;

struct Point
{
  float x;
  float y;

  void inputing()
  {
    cout << "x=";
    cin >> x;
    cout << "y=";
    cin >> y;
  }
};

struct Triangle
{
  Point p1;
  Point p2;
  Point p3;
};

int main()
{
  Triangle triangle;

  triangle.p1.inputing();
  triangle.p2.inputing();
  triangle.p3.inputing();

  float p1p2 = sqrt(pow(triangle.p2.x - triangle.p1.x, 2) + pow(triangle.p2.y - triangle.p1.y, 2));
  float p1p3 = sqrt(pow(triangle.p3.x - triangle.p1.x, 2) + pow(triangle.p3.y - triangle.p1.y, 2));
  float p2p3 = sqrt(pow(triangle.p3.x - triangle.p2.x, 2) + pow(triangle.p3.y - triangle.p2.y, 2));

  cout << "p1p2=" << p1p2 << endl;
  cout << "p1p3=" << p1p3 << endl;
  cout << "p2p3=" << p2p3 << endl;

  if (p1p2 == p1p3 && p1p3 == p2p3)
  {
    cout << "Result: equilateral triangle" << endl;
  }
  else if (p1p2 == p1p3 || p1p3 == p2p3 || p1p2 == p1p3)
  {
    cout << "Result: isosceles triangle" << endl;
  }
  else
  {
    cout << "Result: scalene triangle" << endl;
  }
}
