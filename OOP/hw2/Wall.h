#pragma once

#include <iostream>

using namespace std;

class Wall
{
private:
  int id;
  float width;
  float height;
  string color;

public:
  Wall();
  Wall(int id, float width, float height, string color);

  void SetId(int id);
  void SetWidth(float width);
  void SetHeight(float height);
  void SetColor(string color);

  int GetId();
  float GetWidth();
  float GetHeight();
  string GetColor();

  float CalcSquare();
  float CalcPaint();

  void Print();
};
