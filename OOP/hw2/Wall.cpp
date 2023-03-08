#include "Wall.h"

Wall::Wall()
{
  this->id = 0;
  this->height = 0;
  this->width = 0;
  this->color = "";
}

Wall::Wall(int id, float width, float height, string color)
{
  this->id = id;
  this->height = width;
  this->width = height;
  this->color = color;
}

void Wall::SetId(int id)
{
  this->id = id;
}

void Wall::SetWidth(float width)
{
  this->width = width;
}

void Wall::SetHeight(float height)
{
  this->height = height;
}

void Wall::SetColor(string color)
{
  this->color = color;
}

int Wall::GetId()
{
  return this->id;
}

float Wall::GetWidth()
{
  return this->width;
}

float Wall::GetHeight()
{
  return this->height;
}

string Wall::GetColor()
{
  return this->color;
}

float Wall::CalcSquare()
{
  return this->width * this->height;
}

float Wall::CalcPaint()
{
  return this->CalcSquare() / 12;
}

void Wall::Print()
{
  cout << "Wall id: " << this->id << endl;
  cout << "Wall width: " << this->width << endl;
  cout << "Wall height: " << this->height << endl;
  cout << "Wall color: " << this->color << endl;
}
