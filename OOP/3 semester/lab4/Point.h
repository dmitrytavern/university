#pragma once

class Point
{
private:
  float x;
  float y;

public:
  Point();
  ~Point();

  float GetX();
  float GetY();
  void Input();
};