#include <iostream>
#include <cmath>
#include "Point.h"

using namespace std;

Point::Point(int x, int y)
{
  this->x = x;
  this->y = y;
}

void Point::print()
{
  cout << "Point position:" << endl;
  cout << "x: " << this->x << endl;
  cout << "y: " << this->y << endl;
}

void Point::set_x(int new_x)
{
  this->x = new_x;
}

void Point::set_y(int new_y)
{
  this->y = new_y;
}

int Point::get_length_to_ox()
{
  return abs(this->y);
}

int Point::get_length_to_oy()
{
  return abs(this->x);
}

Point::~Point()
{
}