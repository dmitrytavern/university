// Lab #4
// Classes.
//
// Task: create a class, that includes the following elements:
// - Hidden fields
// - Constructors
// - Methods for initialization, printing, and computing the distance of a
// point from the x-axis.
// The functional elements of the class should provide a consistent, complete,
// minimal, and convenient interface for the class.
//

#include <iostream>
#include <cmath>
#include "./Point.h"

using namespace std;

Point::Point()
{
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
  cout << "x=";
  cin >> this->x;
  cout << "y=";
  cin >> this->y;
}

Point::~Point()
{
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

  float p1p2 = sqrt(pow(triangle.p2.GetX() - triangle.p1.GetX(), 2) + pow(triangle.p2.GetY() - triangle.p1.GetY(), 2));
  float p1p3 = sqrt(pow(triangle.p3.GetX() - triangle.p1.GetX(), 2) + pow(triangle.p3.GetY() - triangle.p1.GetY(), 2));
  float p2p3 = sqrt(pow(triangle.p3.GetX() - triangle.p2.GetX(), 2) + pow(triangle.p3.GetY() - triangle.p2.GetY(), 2));

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
