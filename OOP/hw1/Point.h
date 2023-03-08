#ifndef POINT_H
#define POINT_H

class Point
{
private:
  int x;
  int y;

public:
  Point(int x, int y);
  void print();
  void set_x(int new_x);
  void set_y(int new_y);
  int get_length_to_ox();
  int get_length_to_oy();
  ~Point();
};

#endif
