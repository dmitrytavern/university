#pragma once

class Point
{
private:
  static int instance_count;
  float x;
  float y;

public:
  Point();
  ~Point();

  float GetX();
  float GetY();
  void Input();

  static float CalcLineLength(Point start, Point end);
};