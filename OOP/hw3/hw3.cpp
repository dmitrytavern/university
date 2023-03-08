#include <iostream>
#include <cmath>
#include "./Point.h"

using namespace std;

int Point::instance_count = 0;

Point::Point()
{
  Point::instance_count++;
  this->Input();
}

float Point::GetX()
{
  return this->x;
}

float Point::GetY()
{
  return this->y;
}

void Point::Input()
{
  cout << "Point" << Point::instance_count << ".x=";
  cin >> this->x;
  cout << "Point" << Point::instance_count << ".y=";
  cin >> this->y;
}

float Point::CalcLineLength(Point start, Point end)
{
  return sqrt(pow(end.GetX() - start.GetX(), 2) + pow(end.GetY() - start.GetY(), 2));
}

Point::~Point()
{
  Point::instance_count--;
}

struct Triangle
{
  Point p1;
  Point p2;
  Point p3;
};

int main()
{
  Triangle triangle;

  float p1p2 = Point::CalcLineLength(triangle.p2, triangle.p1);
  float p1p3 = Point::CalcLineLength(triangle.p1, triangle.p3);
  float p2p3 = Point::CalcLineLength(triangle.p2, triangle.p3);

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
